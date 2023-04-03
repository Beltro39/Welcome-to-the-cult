using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

namespace Lean.Gui{
public class SetProperties : MonoBehaviour{


    [SerializeField] private Text centerPlayerName;
    [SerializeField] private Text leftPlayerName;
    [SerializeField] private Text rightPlayerName;

    [SerializeField] private Image centerPlayerImage;
    [SerializeField] private Image leftPlayerImage;
    [SerializeField] private Image rightPlayerImage;

    [SerializeField] private Image centerTurnImage;
    [SerializeField] private Image leftTurnImage;
    [SerializeField] private Image rightTurnImage;

    GameObject uiControllerGO;

    SetAvatarSprite setAvatarSpriteComponent;
    SetImageColor setImageColorComponent;

    [SerializeField] private Text centerTurnOrderText;
    [SerializeField] private Text leftTurnOrderText;
    [SerializeField] private Text rightTurnOrderText;

    [SerializeField] private Text centerEmployeeText;
    [SerializeField] private Text leftEmployeeText;
    [SerializeField] private Text rightEmployeeText;

    [SerializeField] private Text centerTechnologyText;
    [SerializeField] private Text leftTechnologyText;
    [SerializeField] private Text rightTechnologyText;

    [SerializeField] private Text centerAbilityText;
    [SerializeField] private Text leftAbilityText;
    [SerializeField] private Text rightAbilityText;

    [SerializeField] private Text centerItilianos;
    [SerializeField] private Text leftItilianos;
    [SerializeField] private Text rightItilianos;

    
    void Start(){
        uiControllerGO = GameObject.Find("UIController");  
        setAvatarSpriteComponent = uiControllerGO.GetComponent<SetAvatarSprite>();
        setImageColorComponent = uiControllerGO.GetComponent<SetImageColor>();
    }
    
    public bool Run(Queue<Player> queuePlayer)
    { 
        foreach (Player player in queuePlayer)
        {
        if(player.getPosition() == 1){
            //Avatar nombre
            centerPlayerName.text= player.getNickname();
            //Avatar sprite
            setAvatarSpriteComponent.setImage(centerPlayerImage, player.getAvatar());
            //Dimension escogida
            setImageColorComponent.setColor(centerTurnImage, player.getCompanyDimension());
            //Orden de juego
            centerTurnOrderText.text= player.getTurnOrder();  
            //Recursos  
            centerEmployeeText.text= player.getListEmployees().getCountAvailableEmployees() + "/"+ player.getListEmployees().getCountEmployees();
            centerTechnologyText.text= "LEVEL "+ player.getListTechnologies().getAverageAvailableTechnologies() + "/"+ player.getListTechnologies().getAverageTechnologies();
            centerAbilityText.text= "LEVEL "+player.getListAbilities().getAverageAvailableAbilities() + "/"+ player.getListAbilities().getAverageAbilities();
            centerItilianos.text= "$"+player.getItilianos().getAmount().ToString();            
        }
        else if (player.getPosition() == 2){
            leftPlayerName.text = player.getNickname();
            setAvatarSpriteComponent.setImage(leftPlayerImage, player.getAvatar());
            setImageColorComponent.setColor(leftTurnImage, player.getCompanyDimension());
            leftTurnOrderText.text= player.getTurnOrder();
            leftEmployeeText.text= player.getListEmployees().getCountAvailableEmployees() + "/"+ player.getListEmployees().getCountEmployees();
            leftTechnologyText.text= "LVL " +player.getListTechnologies().getAverageAvailableTechnologies() + "/"+ player.getListTechnologies().getAverageTechnologies();
            leftAbilityText.text= "LVL " +player.getListAbilities().getAverageAvailableAbilities() + "/"+ player.getListAbilities().getAverageAbilities();
            leftItilianos.text= "$"+player.getItilianos().getAmount().ToString(); 
        }
        else{
            rightPlayerName.text= player.getNickname();
            setAvatarSpriteComponent.setImage(rightPlayerImage, player.getAvatar());
            setImageColorComponent.setColor(rightTurnImage,  player.getCompanyDimension());
            rightTurnOrderText.text= player.getTurnOrder();
            rightEmployeeText.text= player.getListEmployees().getCountAvailableEmployees() + "/"+ player.getListEmployees().getCountEmployees();
            rightTechnologyText.text= "LVL "+player.getListTechnologies().getAverageAvailableTechnologies() + "/"+ player.getListTechnologies().getAverageTechnologies();
            rightAbilityText.text= "LVL " +player.getListAbilities().getAverageAvailableAbilities() + "/"+ player.getListAbilities().getAverageAbilities();
            rightItilianos.text= "$"+player.getItilianos().getAmount().ToString(); 
        }
        }
        return true;
        
    }  
        

    

    
}
}