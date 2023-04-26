using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Lean.Gui{
public class DisableButtons : MonoBehaviour
{
    [SerializeField] Button ButtonMinusSeniors;
    [SerializeField] Button ButtonMinusArchitects;
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

    [SerializeField] Button ButtonBuyEmployees;
    [SerializeField] Button ButtonBuyTechnologies;
    [SerializeField] Button ButtonBuyAbilities;

    [SerializeField] Button ButtonSkipEmployees;
    [SerializeField] Button ButtonSkipTechnologies;
    [SerializeField] Button ButtonSkipPartnersSuppliers;
    [SerializeField] Button ButtonSkipAbilities;
    

    private Recruitment Recruitment;
    private Skillful Skillful;
    private Bargain Bargain;
    private Research Research;

    public bool Run(Player player){
        Recruitment= player.getListAbilities().getRecruitment();
        Skillful= player.getListAbilities().getSkillful();
        Bargain= player.getListAbilities().getBargain();
        Research= player.getListAbilities().getResearch();
        if(Recruitment.getAmount() < 2){
            ButtonMinusArchitects.interactable= false;
            ButtonPlusArchitects.interactable= false;
            if(Recruitment.getAmount() < 1){
                ButtonMinusSeniors.interactable= false;
                ButtonPlusSeniors.interactable= false;
            }
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

    public void SkipPartnersSuppliersDimensionDisabled(){
        ButtonSkipPartnersSuppliers.interactable= false;
    }

    public void SkipPartnersSuppliersDimensionEnabled(){
        ButtonSkipPartnersSuppliers.interactable= true;
    }

    public void SkipAbilitiesDimensionDisabled(){
        ButtonSkipAbilities.interactable= false;
    }

    public void SkipAbilitiesDimensionEnabled(){
        ButtonSkipAbilities.interactable= true;
    }

    
}
}