using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lean.Gui{
public class GameController : MonoBehaviour
{
    private List<string> listaDimensiones = new List<string>(){"Organization and people", "Information and technology", "Partners and suppliers", "Value streams and processes"};
    private List<int> listaOrder = new List<int>(){1,2,3};
    System.Random random = new System.Random();
    private Queue<Player> queuePlayer;
    private Player currentPlayer;
    private int currentCycle = 1;
    private enum Stage { CreatingPlayers, Initiative, Planning, Buying, ProjectRealization, Exchange }
    private Stage currentStage; 
    SetProperties setPropertiesComponent;
    TurnOrderController turnOrderControllerComponent;
    ShowResources showResourcesComponent;
    SpawnCompany spawnCompanyComponent;
    BuyResources buyResourcesComponent;
    DisableButtons disableButtonsComponent;
    SetResources setResourcesComponent;

    void Start()
    {
        GameObject UIControllerGO = GameObject.Find("UIController");  
        setPropertiesComponent = UIControllerGO.GetComponent<SetProperties>();
        turnOrderControllerComponent = gameObject.GetComponent<TurnOrderController>();
        showResourcesComponent = UIControllerGO.GetComponent<ShowResources>();
        spawnCompanyComponent = UIControllerGO.GetComponent<SpawnCompany>();
        buyResourcesComponent= gameObject.GetComponent<BuyResources>();
        disableButtonsComponent = UIControllerGO.GetComponent<DisableButtons>();
        setResourcesComponent = UIControllerGO.GetComponent<SetResources>();
        currentStage = Stage.CreatingPlayers;
        queuePlayer = new Queue<Player>();
        StartCoroutine(GameLoop());
    }

     IEnumerator GameLoop()
    {
        while (currentCycle <= 12)
        {
            // Execute the current stage logic
            yield return StartCoroutine(ExecuteStage());
            // Advance to the next player
            Debug.Log("no deberia");
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
                yield return new WaitUntil(() => turnOrderControllerComponent.Run(queuePlayer)); 
                yield return new WaitUntil(() => showResourcesComponent.Begin(queuePlayer));
                break;
            case Stage.Planning:
                yield return new WaitUntil(() => setPropertiesComponent.Run(queuePlayer)); 
                yield return new WaitUntil(() => spawnCompanyComponent.Run(currentPlayer)); 
                yield return new WaitUntil(() => currentPlayer.getIsActionComplete()); 
                break;
            /*
            case Stage.Buying:
                // Buying stage logic
                yield return StartCoroutine(BuyingStage());
                break;
            */
        }
    }

      

    public void AdvanceToNextPlayer()
    {
        if((currentStage == Stage.CreatingPlayers)  || (currentStage == Stage.Initiative)){
            Debug.Log("tamales");
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
            if(suma==3){
                AdvanceToNextStage();
            }
        }
       
    }

    void AdvanceToNextStage()
    {
        currentStage++;
        Debug.Log("xd");
        Debug.Log(currentStage);
        if (currentStage > Stage.Exchange)
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


    public bool createPlayers(){
        string dimension;      
        int turn_order;
        List<Player> listPlayer = new List<Player>();
        for(int i = 0; i < 3; i++){
            ListEmployees ListEmployees = new ListEmployees();   
            ListTechnologies ListTechnologies = new ListTechnologies();
            ListAbilities ListAbilities = new ListAbilities();
            Itilianos Itilianos = new Itilianos();
            dimension = GetRandomDimension(); 
            turn_order = GetRandomPlayer();
            int j = turn_order - 1;
            ListEmployees = setResourcesComponent.setInitialValuesEmployees(dimension);
            ListTechnologies = setResourcesComponent.setInitialValuesTechnologies(dimension);
            ListAbilities = setResourcesComponent.setInitialValuesAbilities(dimension);
            Itilianos= setResourcesComponent.setInitialValuesItilianos(dimension); 

            Player playerObj = new Player(
                    ListEmployees, 
                    ListTechnologies,
                    ListAbilities, 
                    Itilianos, 
                    turn_order.ToString(), 
                    dimension, 
                    PlayerPrefs.GetString($"P{j}AvatarName"),
                    PlayerPrefs.GetInt($"P{j}AvatarSprite")
            );
            listPlayer.Add(playerObj); 
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
        currentPlayer = queuePlayer.Peek();
        return true;
    }
    

}
}