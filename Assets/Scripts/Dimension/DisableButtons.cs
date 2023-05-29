using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Lean.Gui{
public class DisableButtons : MonoBehaviour
{
    [SerializeField] Button ButtonMinusJuniors;
    [SerializeField] Button ButtonMinusSemiSeniors;
    [SerializeField] Button ButtonMinusSeniors;
    [SerializeField] Button ButtonMinusArchitects;
    
    [SerializeField] Button ButtonPlusJuniors;
    [SerializeField] Button ButtonPlusSemiSeniors;
    [SerializeField] Button ButtonPlusSeniors;
    [SerializeField] Button ButtonPlusArchitects;

    [SerializeField] Button ButtonMinusServers;
    [SerializeField] Button ButtonMinusSatellites;
    [SerializeField] Button ButtonMinusIA;
    [SerializeField] Button ButtonMinusHosting;

    [SerializeField] Button ButtonPlusServers;
    [SerializeField] Button ButtonPlusSatellites;
    [SerializeField] Button ButtonPlusIA;
    [SerializeField] Button ButtonPlusHosting;

    [SerializeField] Button ButtonMinusRecruitment;
    [SerializeField] Button ButtonMinusSkillful;
    [SerializeField] Button ButtonMinusBargain;
    [SerializeField] Button ButtonMinusResearch;

    [SerializeField] Button ButtonPlusRecruitment;
    [SerializeField] Button ButtonPlusSkillful;
    [SerializeField] Button ButtonPlusBargain;
    [SerializeField] Button ButtonPlusResearch;

    [SerializeField] Button ButtonBuyEmployees;
    [SerializeField] Button ButtonBuyTechnologies;
    [SerializeField] Button ButtonBuyAbilities;

    [SerializeField] Button ButtonSkipEmployees;
    [SerializeField] Button ButtonSkipTechnologies;
    [SerializeField] Button ButtonSkipPartnersSuppliers;
    [SerializeField] Button ButtonSkipAbilities;
    
    private Dictionary<string, Dictionary<string, Button>> diccionarioButtons = new Dictionary<string, Dictionary<string, Button>>();

    void Start(){
        diccionarioButtons = new Dictionary<string, Dictionary<string, Button>>
            {
                { "Juniors", new Dictionary<string, Button> { { "Plus", ButtonPlusJuniors }, {"Minus", ButtonMinusJuniors}}},
                { "SemiSeniors", new Dictionary<string, Button> { { "Plus", ButtonPlusSemiSeniors }, { "Minus", ButtonMinusSemiSeniors}}},
                { "Seniors", new Dictionary<string, Button> { { "Plus", ButtonPlusSeniors }, { "Minus", ButtonMinusSeniors}}},
                { "Architects", new Dictionary<string, Button> { { "Plus", ButtonPlusArchitects }, { "Minus", ButtonMinusArchitects}}},
                { "Servers", new Dictionary<string, Button> { { "Plus", ButtonPlusServers }, { "Minus", ButtonMinusServers}}},
                { "Satellites", new Dictionary<string, Button> { { "Plus", ButtonPlusSatellites }, { "Minus", ButtonMinusSatellites}}},
                { "IA", new Dictionary<string, Button> { { "Plus", ButtonPlusIA }, { "Minus", ButtonMinusIA}}},
                { "Hosting", new Dictionary<string, Button> { { "Plus", ButtonPlusHosting }, { "Minus", ButtonMinusHosting}}},
                { "Recruitment", new Dictionary<string, Button> { { "Plus", ButtonPlusRecruitment }, { "Minus", ButtonMinusRecruitment}}},
                { "Skillful", new Dictionary<string, Button> { { "Plus", ButtonPlusSkillful }, { "Minus", ButtonMinusSkillful}}},
                { "Bargain", new Dictionary<string, Button> { { "Plus", ButtonPlusBargain }, { "Minus", ButtonMinusBargain}}},
                { "Research", new Dictionary<string, Button> { { "Plus", ButtonPlusResearch }, { "Minus", ButtonMinusResearch}}}
            };
    }

    

    private Recruitment Recruitment;
    private Skillful Skillful;
    private Research Research;

    

    public bool Run(Player player){
        Recruitment= player.getListAbilities().getRecruitment();
        Skillful= player.getListAbilities().getSkillful();
        Research= player.getListAbilities().getResearch();
        if(Recruitment.getAmount() < 2){
            ButtonMinusArchitects.interactable= false;
            ButtonPlusArchitects.interactable= false;
            if(Recruitment.getAmount() < 1){
                ButtonMinusSeniors.interactable= false;
                ButtonPlusSeniors.interactable= false;
            }
        }else{
            ButtonMinusArchitects.interactable= true;
            ButtonPlusArchitects.interactable= true;
            ButtonMinusSeniors.interactable= true;
            ButtonPlusSeniors.interactable= true;
        }
        
        return true;
    }

    public void BuyEmployeesDimensionEnabled(){
        ButtonBuyEmployees.interactable= true;
    }

    public void BuyEmployeesDimensionDisabled(){
        ButtonBuyEmployees.interactable= false;
    }

     public void BuyTechnologiesDimensionEnabled(){
        ButtonBuyTechnologies.interactable= true;
    }

    public void BuyTechnologiesDimensionDisabled(){
        ButtonBuyTechnologies.interactable= false;
    }
    public void BuyAbilitiesDimensionEnabled(){
        ButtonBuyAbilities.interactable= true;
    }

    public void BuyAbilitiesDimensionDisabled(){
        ButtonBuyAbilities.interactable= false;
    }


    public void SkipEmployeesDimensionEnabled(){
        ButtonSkipEmployees.interactable= true;
    }

    public void SkipEmployeesDimensionDisabled(){
        ButtonSkipEmployees.interactable= false;
    }

    public void SkipTechnologiesDimensionEnabled(){
        ButtonSkipTechnologies.interactable= true;
    }

    public void SkipTechnologiesDimensionDisabled(){
        ButtonSkipTechnologies.interactable= false;
    }

    public void SkipAbilitiesDimensionDisabled(){
        ButtonSkipAbilities.interactable= false;
    }

    public void SkipAbilitiesDimensionEnabled(){
        ButtonSkipAbilities.interactable= true;
    }




    public void ButtonPlusServersDisable(){
        ButtonPlusServers.interactable = false;
    }

    public void ButtonPlusSatellitesDisable(){
        ButtonPlusSatellites.interactable = false;
    }

    public void ButtonPlusIADisable(){
        ButtonPlusIA.interactable = false;
    }

    public void ButtonPlusHostingDisable(){
        ButtonPlusHosting.interactable = false;
    }

     public void ButtonPlusServersEnable(){
        ButtonPlusServers.interactable = true;
    }

    public void ButtonPlusSatellitesEnable(){
        ButtonPlusSatellites.interactable = true;
    }

    public void ButtonPlusIAEnable(){
        ButtonPlusIA.interactable = true;
    }

    public void ButtonPlusHostingEnable(){
        ButtonPlusHosting.interactable = true;
    }

    public void InteractButton(string resource, string property, bool enable){
        diccionarioButtons[resource][property].interactable = enable;
    }

    
}
}