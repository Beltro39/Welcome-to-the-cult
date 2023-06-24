using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private enum Stage { CreatingPlayers, Initiative, Planning, ProjectRealization, ProjectAnimation, Exchange, InvestorScore}
    private Stage currentStage; 
    
    SetProperties setPropertiesComponent;
    TurnOrderController turnOrderControllerComponent;
    [SerializeField] ProjectPanelController projectPanelControllerComponent;
    [SerializeField] ProjectController projectControllerComponent;
    ShowResources showResourcesComponent;
    SpawnCompany spawnCompanyComponent;
    BuyResources buyResourcesComponent;
    DisableButtons disableButtonsComponent;
    DisableBoardItems disableBoardItemsComponent;
    SetResources setResourcesComponent;
    SetCircleCompany setCircleCompanyComponent;
    SelectPartnerAndSupplier selectPartnerAndSupplierComponent; 

    LeanWindow initiativeAssignmentModalLeanWindow;

    [SerializeField] Text currentTurn;
    [SerializeField] Text currentTurnTitle;
    [SerializeField] LeanWindow currentTurnPanel;

    [SerializeField] LeanWindow modalExchangeLeanWindow;
    [SerializeField] LeanWindow modalExchange2LeanWindow;
    [SerializeField] Text playerTextIZQ;
    [SerializeField] Text playerTextDER;
    [SerializeField] Image playerImageIZQ;
    [SerializeField] Image playerImageDER;

    private UserExchange leftUserExchange;
    private UserExchange rightUserExchange;

    SetAvatarSprite setAvatarSprite;

    void Start()
    {
        GameObject UIControllerGO = GameObject.Find("UIController");
        GameObject initiativeAssignmentGO = GameObject.Find("Modal Initiative Assignment");  
        setPropertiesComponent = UIControllerGO.GetComponent<SetProperties>();
        turnOrderControllerComponent = gameObject.GetComponent<TurnOrderController>();
        showResourcesComponent = UIControllerGO.GetComponent<ShowResources>();
        spawnCompanyComponent = UIControllerGO.GetComponent<SpawnCompany>();
        buyResourcesComponent = gameObject.GetComponent<BuyResources>();
        disableButtonsComponent = UIControllerGO.GetComponent<DisableButtons>();
        disableBoardItemsComponent = UIControllerGO.GetComponent<DisableBoardItems>();
        setResourcesComponent = UIControllerGO.GetComponent<SetResources>();
        selectPartnerAndSupplierComponent = gameObject.GetComponent<SelectPartnerAndSupplier>();
        setCircleCompanyComponent = UIControllerGO.GetComponent<SetCircleCompany>();
        initiativeAssignmentModalLeanWindow = initiativeAssignmentGO.GetComponent<LeanWindow>();
        setAvatarSprite = UIControllerGO.GetComponent<SetAvatarSprite>();

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
                // Setting UI resources in the modal initiative
                yield return new WaitUntil(() => turnOrderControllerComponent.Run(queuePlayer, currentCycle)); 
                initiativeAssignmentModalLeanWindow.TurnOn();
                break;
            
            case Stage.Planning:
                disableButtonsComponent.ButtonDimensionDisable();
                disableButtonsComponent.ButtonProjectsEnable();
                yield return StartCoroutine(SetBoardUI());
                // Setting script with the player information for buying logic 
                yield return new WaitUntil(() => buyResourcesComponent.Run(currentPlayer));
                if (currentPlayer.getTurnOrder() == "1"){
                    yield return new WaitUntil(() => buyResourcesComponent.ReturnMarketToOriginalAvailability());
                }
                // Setting everything of the allies
                if (currentCycle%2!=0 && currentPlayer.getTurnOrder() == "1"){
                    yield return new WaitUntil(() => selectPartnerAndSupplierComponent.PartnerSupplierRotation());
                }
                yield return new WaitUntil(() => selectPartnerAndSupplierComponent.Run(currentPlayer));
                // Muestra de turno
                currentTurnPanel.TurnOn();
                currentTurnTitle.text = $"{currentPlayer.getNickname()}!";
                //Inicia Planning
                yield return new WaitUntil(() => spawnCompanyComponent.Run(currentPlayer)); 
                yield return new WaitUntil(() => currentPlayer.getIsActionComplete());
                changePlayerPosition();
                break;
            case Stage.ProjectRealization:
                disableButtonsComponent.ButtonDimensionDisable();
                disableButtonsComponent.ButtonSelectInProjectModalEnable();
                disableButtonsComponent.ButtonFinalizeInProjectModalEnable();
                if (currentPlayer.getTurnOrder() == "1"){
                    yield return new WaitUntil(() => projectControllerComponent.showStartStage());
                }
                yield return StartCoroutine(SetBoardUI());
                // Muestra de turno
                currentTurnPanel.TurnOn();
                currentTurnTitle.text = $"{currentPlayer.getNickname()}!";
                yield return new WaitUntil(() => projectControllerComponent.Run());
                yield return new WaitUntil(() => currentPlayer.getIsActionComplete());
                yield return new WaitForSeconds(3f);
                yield return new WaitUntil(() => projectControllerComponent.CloseModal());
                //ProjectToken.finalizeAnim = false;
                changePlayerPosition();
                break;
            case Stage.ProjectAnimation:
                projectPanelControllerComponent.Begin();
                yield return new WaitUntil(() => ProjectToken.getFinalizeAnim());  
                ProjectToken.finalizeAnim = false; 
                break;
            case Stage.Exchange:
                //Buscar modal donde estan los jugadores para intercambiar
                
                yield return StartCoroutine(SetBoardUI());
                yield return new WaitUntil(() => SetModalForExchange());
                yield return new WaitUntil(() => currentPlayer.getIsActionComplete());
                changePlayerPosition();
                break;
            case Stage.InvestorScore:
                if (currentPlayer.getTurnOrder() == "1"){
                    InvestorScore.Run(queuePlayer, currentCycle);
                }
                break;
            
        }
    }

      

    public void AdvanceToNextPlayer()
    {
        if((currentStage == Stage.CreatingPlayers)  || (currentStage == Stage.Initiative) || (currentStage == Stage.ProjectAnimation || (currentStage == Stage.InvestorScore))) {
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
        if((currentStage == Stage.Planning) || (currentStage == Stage.ProjectRealization || (currentStage == Stage.Exchange))){
            changeAllPlayerIsActionCompleteToFalse();
        }
        currentStage++;
        if (currentStage > Stage.InvestorScore)
        {
            currentStage = Stage.Initiative;
            currentCycle++;
        }
    }

    void EndGame()
    {
        // End game logic (display scores, declare winner, etc.)
    }

    IEnumerator SetBoardUI(){
        currentTurn.text = $"{currentPlayer.getTurnOrder()}/3";
        projectPanelControllerComponent.Run(currentPlayer);
        setCircleCompanyComponent.Run(currentPlayer.getCompanyDimension());                
        // Setting UI resources, the ones when you click in the top, left or right of the gameboard
        yield return new WaitUntil(() => showResourcesComponent.Begin(queuePlayer));
        // Setting UI resources, the ones from the top, left or right of the gameboard 
        yield return new WaitUntil(() => setPropertiesComponent.Run(queuePlayer)); 
        // Disabling buttons (Gameboard images turn gray, or some buttons become not interactable)
        yield return new WaitUntil(() => disableButtonsComponent.Run(currentPlayer));
        yield return new WaitUntil(() => disableBoardItemsComponent.Run(currentPlayer));

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

    public void changeAllPlayerIsActionCompleteToFalse(){
        foreach(Player player in queuePlayer){
            player.setIsActionComplete(false);
        }
    }

    public void changePlayerPosition(){
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
        queuePlayer.Clear();
        foreach(Player player in listPlayer){
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

    public bool SetModalForExchange(){
        bool v= true;
        foreach (Player player in queuePlayer){
            if(currentPlayer != player){
                if(v){
                    v =  false;
                    setAvatarSprite.setImage(playerImageIZQ, player.getAvatar());
                }else{
                     setAvatarSprite.setImage(playerImageDER, player.getAvatar());
                }

            }
        }
        modalExchangeLeanWindow.TurnOn();
        return true;

    }

    public void StartExchange(int i)
        {
            leftUserExchange = GameObject.Find("LeftResource").GetComponent<UserExchange>();
            rightUserExchange = GameObject.Find("RightResource").GetComponent<UserExchange>(); 
            Player playerToExchange = currentPlayer;
            bool v= false;
            foreach (Player player in queuePlayer){
                if(currentPlayer != player){
                    if(i == 1){
                        rightUserExchange.Run(player); 
                        break;
                    }
                    if (v){
                       rightUserExchange.Run(player); 
                       break; 
                    }
                    v = true;
                }
            }
             
            
            leftUserExchange.Run(currentPlayer);
        }

        public void AcceptExchange()
        {
            if(leftUserExchange.GetIsAcceptExchange() && rightUserExchange.GetIsAcceptExchange()){ 
            Dictionary<string, int> leftResource = leftUserExchange.TransferResourceExchenge();
            Dictionary<string, int> rightResource = rightUserExchange.TransferResourceExchenge();
            leftUserExchange.SetResourceExchange(rightResource);
            rightUserExchange.SetResourceExchange(leftResource);
            Debug.Log("Los dos han aceptado el intercambio");
            changeCurrentPlayerIsActionComplete();
            modalExchange2LeanWindow.TurnOff();
            modalExchangeLeanWindow.TurnOff();
            }
        }
        public void CancelExchange()
        {
           
        }
    

}
}