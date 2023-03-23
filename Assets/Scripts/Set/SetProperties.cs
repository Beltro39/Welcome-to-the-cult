using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

namespace Lean.Gui{
public class SetProperties : MonoBehaviour{

    PlayerClass PlayerClass_obj;

    [SerializeField] private Text localPlayerName;
    [SerializeField] private Text leftPlayerName;
    [SerializeField] private Text rightPlayerName;

    [SerializeField] private Image localPlayerImage;
    [SerializeField] private Image leftPlayerImage;
    [SerializeField] private Image rightPlayerImage;

    [SerializeField] private Image localTurnImage;
    [SerializeField] private Image leftTurnImage;
    [SerializeField] private Image rightTurnImage;

    [SerializeField] GameObject UIControllerGO;
    [SerializeField] GameObject GameControllerGO;
    SetAvatarSprite setAvatarSprite;
    SetImageColor SetImageColor;
    SetResources setResources;
    SetDimension setDimension;
    SetTurnOrder setTurnOrder;
    GameController GameController;

    [SerializeField] private Text localTurnOrderText;
    [SerializeField] private Text leftTurnOrderText;
    [SerializeField] private Text rightTurnOrderText;

    [SerializeField] private Text localEmployeeText;
    [SerializeField] private Text localTechnologyText;
    [SerializeField] private Text leftEmployeeText;
    [SerializeField] private Text rightEmployeeText;
    [SerializeField] private Text leftTechnologyText;
    [SerializeField] private Text rightTechnologyText;
    [SerializeField] private Text localAbilityText;
    [SerializeField] private Text leftAbilityText;
    [SerializeField] private Text rightAbilityText;

    [SerializeField] private Text localItilianos;
    [SerializeField] private Text leftItilianos;
    [SerializeField] private Text rightItilianos;

    string myDimension;
    int myTurn;
    int ActorNumber;
    bool v;
    string position= "";
    int avatar= -1;
    string myNickname= "";
    public List<PlayerClass> ListPlayerClass= new List<PlayerClass>();
    
    void Start(){
        setAvatarSprite = UIControllerGO.GetComponent<SetAvatarSprite>();
        SetImageColor = UIControllerGO.GetComponent<SetImageColor>();
        setResources= UIControllerGO.GetComponent<SetResources>();
        setDimension= UIControllerGO.GetComponent<SetDimension>();
        setTurnOrder= UIControllerGO.GetComponent<SetTurnOrder>();
        GameController = GameControllerGO.GetComponent<GameController>();
    }

    public List<PlayerClass> getListPlayerClass(){
        return ListPlayerClass;
    }
    // Start is called before the first frame update
    public void Begin()
    { 
        //El usuario local avisa en el server su nombre
        for(int i = 0; i < 3; i++){
            ListEmployees ListEmployees= new ListEmployees();   
            ListTechnologies ListTechnologies = new ListTechnologies();
            ListAbilities ListAbilities = new ListAbilities();
            Itilianos Itilianos= new Itilianos();
            myDimension = setDimension.setDimension();
            myTurn = setTurnOrder.setTurnOrder();
            ListEmployees = setResources.setInitialValuesEmployees(myDimension);
            ListTechnologies = setResources.setInitialValuesTechnologies(myDimension);
            ListAbilities = setResources.setInitialValuesAbilities(myDimension);
            Itilianos= setResources.setInitialValuesItilianos(myDimension);  
            if(i == 0){
                position= "local";
                localPlayerName.text= PlayerPrefs.GetString($"P{i}AvatarName");
                //Avatar escogido
                setAvatarSprite.setImage(localPlayerImage,  PlayerPrefs.GetInt($"P{i}AvatarSprite"));
                //Dimension escogida
                SetImageColor.setColor(localTurnImage, myDimension);
                //Orden de juego
                localTurnOrderText.text= myTurn.ToString();   
                //Recursos
                localTurnOrderText.text= myTurn.ToString();     
                localEmployeeText.text= ListEmployees.getCountAvailableEmployees() + "/"+ ListEmployees.getCountEmployees();
                localTechnologyText.text= "LEVEL "+ ListTechnologies.getAverageAvailableTechnologies() + "/"+ ListTechnologies.getAverageTechnologies();
                localAbilityText.text= "LEVEL "+ListAbilities.getAverageAvailableAbilities() + "/"+ ListAbilities.getAverageAbilities();
                localItilianos.text= "$"+Itilianos.getAmount().ToString();            
            }
            else if (i==1){
                position= "left";
                leftPlayerName.text = PlayerPrefs.GetString($"P{i}AvatarName");
                setAvatarSprite.setImage(leftPlayerImage, PlayerPrefs.GetInt($"P{i}AvatarSprite"));
                SetImageColor.setColor(leftTurnImage, myDimension);
                leftTurnOrderText.text= myTurn.ToString();
                leftEmployeeText.text= ListEmployees.getCountAvailableEmployees() + "/"+ ListEmployees.getCountEmployees();
                leftTechnologyText.text= "LVL " +ListTechnologies.getAverageAvailableTechnologies() + "/"+ ListTechnologies.getAverageTechnologies();
                leftAbilityText.text= "LVL " +ListAbilities.getAverageAvailableAbilities() + "/"+ ListAbilities.getAverageAbilities();
                leftItilianos.text= "$"+Itilianos.getAmount().ToString(); 
                
            }
            else{
                position= "right";
                rightPlayerName.text= PlayerPrefs.GetString($"P{i}AvatarName");
                setAvatarSprite.setImage(rightPlayerImage, PlayerPrefs.GetInt($"P{i}AvatarSprite"));
                SetImageColor.setColor(rightTurnImage, myDimension);
                rightTurnOrderText.text= myTurn.ToString();
                rightEmployeeText.text= ListEmployees.getCountAvailableEmployees() + "/"+ ListEmployees.getCountEmployees();
                rightTechnologyText.text= "LVL "+ListTechnologies.getAverageAvailableTechnologies() + "/"+ ListTechnologies.getAverageTechnologies();
                rightAbilityText.text= "LVL " +ListAbilities.getAverageAvailableAbilities() + "/"+ ListAbilities.getAverageAbilities();
                rightItilianos.text= "$"+Itilianos.getAmount().ToString(); 
            }

            PlayerClass_obj = new PlayerClass(
                    ListEmployees, 
                    ListTechnologies,
                    ListAbilities, 
                    Itilianos, 
                    position, 
                    myTurn.ToString(), 
                    myDimension, 
                    PlayerPrefs.GetString($"P{i}AvatarName"),
                    PlayerPrefs.GetInt($"P{i}AvatarSprite"));
            ListPlayerClass.Add(PlayerClass_obj);   

        }   
        GameController.PropertiesHaveBeenSet();
    }
    
   
}
}