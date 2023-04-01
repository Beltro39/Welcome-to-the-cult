using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lean.Gui{
public class GameController : MonoBehaviour
{
    private List<string> listaDimensiones = new List<string>(){"Organization and people", "Information and technology", "Partners and suppliers", "Value streams and processes"};
    private List<int> listaOrder;
    private List<Player> listPlayer = new List<Player>();
    System.Random random = new System.Random();
    private Queue<Player> queuePlayer = new Queue<Player>();
    private Player currentPlayer;
    private int currentCycle = 1;
    private enum Stage { CreatingPlayers, Initiative, Planning, ProjectRealization}
    private Stage currentStage; 
    
    SetProperties setPropertiesComponent;
    TurnOrderController turnOrderControllerComponent;
    ShowResources showResourcesComponent;
    SpawnCompany spawnCompanyComponent;
    BuyResources buyResourcesComponent;
    DisableButtons disableButtonsComponent;
    SetResources setResourcesComponent;

    LeanWindow initiativeAssignmentModalLeanWindow;

    void Start()
    {
        GameObject UIControllerGO = GameObject.Find("UIController");
        GameObject initiativeAssignmentGO = GameObject.Find("Modal Initiative Assignment");  
        setPropertiesComponent = UIControllerGO.GetComponent<SetProperties>();
        turnOrderControllerComponent = gameObject.GetComponent<TurnOrderController>();
        showResourcesComponent = UIControllerGO.GetComponent<ShowResources>();
        spawnCompanyComponent = UIControllerGO.GetComponent<SpawnCompany>();
        buyResourcesComponent= gameObject.GetComponent<BuyResources>();
        disableButtonsComponent = UIControllerGO.GetComponent<DisableButtons>();
        setResourcesComponent = UIControllerGO.GetComponent<SetResources>();
        initiativeAssignmentModalLeanWindow = initiativeAssignmentGO.GetComponent<LeanWindow>();

        currentStage = Stage.CreatingPlayers;
        StartCoroutine(GameLoop());
    }

     IEnumerator GameLoop()
    {
        while (currentCycle <= 12)
        {
            // Execute the current stage logic
            yield return StartCoroutine(ExecuteStage());
            // Advance to the next player
            AdvanceToNextPlayer();
        }

        // End the game
        EndGame();
    }

     IEnumerator ExecuteStage()
    {
        // Stage-specific logic
        switch (currentStage)
        {
           
            case Stage.CreatingPlayers:
                yield return new WaitUntil(() => createPlayers());
                break;
            case Stage.Initiative:
                yield return new WaitUntil(() => resetTurnOrder()); 
                Debug.Log("Initiative");
                Debug.Log(currentCycle);
                yield return new WaitUntil(() => turnOrderControllerComponent.Run(queuePlayer)); 
                initiativeAssignmentModalLeanWindow.TurnOn();
                break;
            case Stage.Planning:
                yield return new WaitUntil(() => showResourcesComponent.Begin(queuePlayer));
                yield return new WaitUntil(() => setPropertiesComponent.Run(queuePlayer)); 
                yield return new WaitUntil(() => spawnCompanyComponent.Run(currentPlayer)); 
                yield return new WaitUntil(() => currentPlayer.getIsActionComplete()); 
                spawnCompanyComponent.destroyCompany();
                changePosition();
                break;
            case Stage.ProjectRealization:
                changeAllPlayerIsActionComplete();
                break;
        }
    }

      

    public void AdvanceToNextPlayer()
    {
        if((currentStage == Stage.CreatingPlayers)  || (currentStage == Stage.Initiative)  || (currentStage == Stage.ProjectRealization)){
            AdvanceToNextStage();
        }else{
            currentPlayer = queuePlayer.Dequeue(); 
            queuePlayer.Enqueue(currentPlayer);
            int suma = 0;
            foreach (Player player in queuePlayer){
                if (player.getIsActionComplete()){
                    suma++;
                }
            }
            Debug.Log("Suma");
            Debug.Log(suma);
            if(suma==3){
                AdvanceToNextStage();
            }
        }
       
    }

    void AdvanceToNextStage()
    {
        currentStage++;
        if (currentStage > Stage.ProjectRealization)
        {
            currentStage = Stage.Initiative;
            currentCycle++;
        }
    }

    void EndGame()
    {
        // End game logic (display scores, declare winner, etc.)
    }

    public Queue<Player> getQueuePlayer(){
        return queuePlayer;
    }

   private string GetRandomDimension(){
        int value = random.Next(0, listaDimensiones.Count);
        string dimension;
        dimension = listaDimensiones[value];
        listaDimensiones.RemoveAt(value);
        return dimension;
    }


    private int GetRandomPlayer(){
        int value = random.Next(0, listaOrder.Count);
        int turn_order;
        turn_order = listaOrder[value];
        listaOrder.RemoveAt(value);
        return turn_order;
    }

    public void changeCurrentPlayerIsActionComplete(){
        currentPlayer.setIsActionComplete(true);
    }

    public void changeAllPlayerIsActionComplete(){
        foreach(Player player in queuePlayer){
            player.setIsActionComplete(false);
        }
    }

    public void changePosition(){
        foreach(Player player in queuePlayer){
            if(player.getPosition() == 1){
                player.setPosition(3);
            }
            else {
                player.setPosition(player.getPosition()-1);
            }
        }
    }

    public bool resetTurnOrder(){
        listaOrder = new List<int>(){1,2,3};
        foreach(Player player in queuePlayer){
            int turn_order = GetRandomPlayer();
            player.setTurnOrder(turn_order.ToString());
        }
        int k = 0; 
        while(true){
            if(k==3){
                k = 0;
            }
            if(this.queuePlayer.Count == 3){
                break;
            }
            if(listPlayer[k].getTurnOrder() == "1" && this.queuePlayer.Count == 0){
                this.queuePlayer.Enqueue(listPlayer[k]);
                listPlayer[k].setPosition(1);
            }else if(listPlayer[k].getTurnOrder() == "2" && this.queuePlayer.Count == 1){
                this.queuePlayer.Enqueue(listPlayer[k]);
                listPlayer[k].setPosition(2);
            }else if(listPlayer[k].getTurnOrder() == "3" && this.queuePlayer.Count == 2){
                this.queuePlayer.Enqueue(listPlayer[k]);
                listPlayer[k].setPosition(3);
            }
            k++;
        }
        currentPlayer = queuePlayer.Dequeue();
        queuePlayer.Enqueue(currentPlayer);
        return true;
    }

    public bool createPlayers(){
        string dimension;      
        for(int i = 0; i < 3; i++){
            ListEmployees ListEmployees = new ListEmployees();   
            ListTechnologies ListTechnologies = new ListTechnologies();
            ListAbilities ListAbilities = new ListAbilities();
            Itilianos Itilianos = new Itilianos();
            dimension = GetRandomDimension(); 
            ListEmployees = setResourcesComponent.setInitialValuesEmployees(dimension);
            ListTechnologies = setResourcesComponent.setInitialValuesTechnologies(dimension);
            ListAbilities = setResourcesComponent.setInitialValuesAbilities(dimension);
            Itilianos= setResourcesComponent.setInitialValuesItilianos(dimension); 

            Player playerObj = new Player(
                    ListEmployees, 
                    ListTechnologies,
                    ListAbilities, 
                    Itilianos, 
                    dimension, 
                    PlayerPrefs.GetString($"P{i}AvatarName"),
                    PlayerPrefs.GetInt($"P{i}AvatarSprite")
            );
            listPlayer.Add(playerObj); 
 
        }
        return true;
    }
    

}
}