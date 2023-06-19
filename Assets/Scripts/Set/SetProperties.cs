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

    [SerializeField] private Image centerPartner;
    [SerializeField] private Image leftPartner;
    [SerializeField] private Image rightPartner;

    [SerializeField] private Image centerSupplier;
    [SerializeField] private Image leftSupplier;
    [SerializeField] private Image rightSupplier;

    [SerializeField] private Image[] centerPartnerStars = new Image[3];
    [SerializeField] private Image[] leftPartnerStars = new Image[3];
    [SerializeField] private Image[] rightPartnerStars = new Image[3];

    [SerializeField] private Image[] centerSupplierStars = new Image[3];
    [SerializeField] private Image[] leftSupplierStars = new Image[3];
    [SerializeField] private Image[] rightSupplierStars = new Image[3];

    [SerializeField] private Text[] descriptionPartnerArray = new Text[3];
    [SerializeField] private Text[] descriptionSupplierArray = new Text[3];

    [SerializeField] private Sprite unknownPartnerOrSupplier;
    [SerializeField] private Text[] valueArray = new Text[3];

    
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

                if(player.GetPartner() != null){
                    centerPartner.sprite = player.GetPartner().ImageStakeholder;
                    SetStars(centerPartnerStars, player.GetPartner().Difficulty);
                }else{
                    centerPartner.sprite = unknownPartnerOrSupplier;
                    SetStars(centerPartnerStars, -1);
                }     
                if(player.GetSupplier() != null){
                    centerSupplier.sprite = player.GetSupplier().ImageStakeholder;
                    SetStars(centerSupplierStars, player.GetSupplier().Difficulty);
                }else{
                    centerSupplier.sprite = unknownPartnerOrSupplier;
                    SetStars(centerSupplierStars, -1);
                } 

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
                if(player.GetPartner() != null){
                    leftPartner.sprite = player.GetPartner().ImageStakeholder;
                    SetStars(leftPartnerStars, player.GetPartner().Difficulty);
                }else{
                    leftPartner.sprite = unknownPartnerOrSupplier;
                    SetStars(leftPartnerStars, -1);
                }
                if(player.GetSupplier() != null){
                    leftSupplier.sprite = player.GetSupplier().ImageStakeholder;
                    SetStars(leftSupplierStars, player.GetSupplier().Difficulty);
                }else{
                    leftSupplier.sprite = unknownPartnerOrSupplier;
                    SetStars(leftSupplierStars, -1);
                } 
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
                if(player.GetPartner() != null){
                    rightPartner.sprite = player.GetPartner().ImageStakeholder;
                    SetStars(rightPartnerStars, player.GetPartner().Difficulty);
                }else{
                    rightPartner.sprite = unknownPartnerOrSupplier;
                    SetStars(rightPartnerStars, -1);
                }
                if(player.GetSupplier() != null){
                    rightSupplier.sprite = player.GetSupplier().ImageStakeholder;
                    SetStars(rightSupplierStars, player.GetSupplier().Difficulty);
                }else{
                    rightSupplier.sprite = unknownPartnerOrSupplier;
                    SetStars(rightSupplierStars, -1);
                } 
            }

            if(player.GetPartner() != null){
                descriptionPartnerArray[player.getPosition()-1].text = $"P-LVL{player.GetPartner().Difficulty+1}";
            }else{
                descriptionPartnerArray[player.getPosition()-1].text = $"LOCKED";
            }

            if(player.GetSupplier() != null){
                descriptionSupplierArray[player.getPosition()-1].text = $"S-LVL{player.GetSupplier().Difficulty+1}";
            }else{
                descriptionSupplierArray[player.getPosition()-1].text = $"LOCKED";
            }

            valueArray[player.getPosition()-1].text = $"{player.Value} PTS";
        }
        return true;
        
    }  

     public void SetStars(Image[] starArray,int difficulty){
        if(difficulty == -1){
            starArray[0].enabled = false;
            starArray[1].enabled = false;
            starArray[2].enabled = false; 
        }
        else if(difficulty == 0){
            starArray[0].enabled = true;
            starArray[1].enabled = false;
            starArray[2].enabled = false;
        }else if(difficulty == 1){
            starArray[0].enabled = false;
            starArray[1].enabled = true;
            starArray[2].enabled = true;
        }else{
            starArray[0].enabled = true;
            starArray[1].enabled = true;
            starArray[2].enabled = true;
        }

    }
}
}