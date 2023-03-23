using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Lean.Gui{
public class DisableButtons : MonoBehaviour
{
    [SerializeField] Button ButtonMinusSeniors;
    [SerializeField] Button ButtonMinusArchitects;
   // [SerializeField] Button ButtonMinusServers;
   // [SerializeField] Button ButtonMinusSatellites;
  //  [SerializeField] Button ButtonMinusIA;
  //  [SerializeField] Button ButtonMinusHosting;

    [SerializeField] Button ButtonPlusSeniors;
    [SerializeField] Button ButtonPlusArchitects;
 //   [SerializeField] Button ButtonPlusServers;
  //  [SerializeField] Button ButtonPlusSatellites;
  //  [SerializeField] Button ButtonPlusIA;
  //  [SerializeField] Button ButtonPlusHosting;

    [SerializeField] Button ButtonBuyEmployees;
    [SerializeField] Button ButtonBuyTechnologies;
    [SerializeField] Button ButtonBuyAbilities;

    private Recruitment Recruitment;
    private Skillful Skillful;
    private Bargain Bargain;
    private Research Research;

    public void Begin(PlayerClass PlayerClass){
        Recruitment= PlayerClass.getListAbilities().getRecruitment();
        Skillful= PlayerClass.getListAbilities().getSkillful();
        Bargain= PlayerClass.getListAbilities().getBargain();
        Research= PlayerClass.getListAbilities().getResearch();
        if(Recruitment.getAmount() < 2){
            ButtonMinusArchitects.interactable= false;
            ButtonPlusArchitects.interactable= false;
            if(Recruitment.getAmount() < 1){
                ButtonMinusSeniors.interactable= false;
                ButtonPlusSeniors.interactable= false;
            }
        }
        if(Skillful.getAmount() < 2){}
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

}
}