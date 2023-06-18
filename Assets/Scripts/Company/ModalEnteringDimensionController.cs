using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lean.Gui{
public class ModalEnteringDimensionController : MonoBehaviour
{
    [SerializeField] GameObject modalConfirmDimensional;
    [SerializeField] GameObject modalOrganizationAndPeople;
    [SerializeField] GameObject modalInformationAndTechnology;
    [SerializeField] GameObject modalPartnersAndSuppliers;
    [SerializeField] GameObject modalValueStreamsAndProcesses;
    [SerializeField] GameObject modalProjects;
    private string myDimensionSelected;
    LeanWindow confirmModalLeanWindow;
    LeanWindow modalOrganizationAndPeopleLeanWindow;
    LeanWindow modalInformationAndTechnologyLeanWindow;
    LeanWindow modalPartnersAndSuppliersLeanWindow;
    LeanWindow modalValueStreamsAndProcessesLeanWindow;
    LeanWindow modalProjectsLeanWindow;
    SpawnCompany spawnCompanyComponent;
    DisableButtons disableButtonsComponent;

    void Start()
    {
        confirmModalLeanWindow= modalConfirmDimensional.GetComponent<LeanWindow>();
        modalOrganizationAndPeopleLeanWindow= modalOrganizationAndPeople.GetComponent<LeanWindow>();
        modalInformationAndTechnologyLeanWindow= modalInformationAndTechnology.GetComponent<LeanWindow>();
        modalValueStreamsAndProcessesLeanWindow= modalValueStreamsAndProcesses.GetComponent<LeanWindow>();
        modalPartnersAndSuppliersLeanWindow= modalPartnersAndSuppliers.GetComponent<LeanWindow>();
        modalProjectsLeanWindow = modalProjects.GetComponent<LeanWindow>();
        GameObject UIControllerGO = GameObject.Find("UIController");
        spawnCompanyComponent = UIControllerGO.GetComponent<SpawnCompany>();
        disableButtonsComponent = UIControllerGO.GetComponent<DisableButtons>();
    }
     
    public void setMyDimensionSelected(string myDimensionSelected){
        this.myDimensionSelected = myDimensionSelected;
    }

    public void Begin(){
        if(myDimensionSelected== "Organization and people"){
           modalOrganizationAndPeopleLeanWindow.TurnOn();
        }
        if(myDimensionSelected== "Information and technology"){
          modalInformationAndTechnologyLeanWindow.TurnOn();
        }
        
        if(myDimensionSelected== "Partners and suppliers"){
          modalPartnersAndSuppliersLeanWindow.TurnOn();  
        }
      
        if(myDimensionSelected== "Value streams and processes"){
          modalValueStreamsAndProcessesLeanWindow.TurnOn(); 
        }
         spawnCompanyComponent.destroyCompany();
         disableButtonsComponent.ButtonDimensionEnable();
    }

    public void TurnOff(){
      if(myDimensionSelected== "Organization and people"){
           modalOrganizationAndPeopleLeanWindow.TurnOff();
        }
        if(myDimensionSelected== "Information and technology"){
          modalInformationAndTechnologyLeanWindow.TurnOff();
        }
        
        if(myDimensionSelected== "Partners and suppliers"){
          modalPartnersAndSuppliersLeanWindow.TurnOff();  
        }
        
        if(myDimensionSelected== "Value streams and processes"){
          modalValueStreamsAndProcessesLeanWindow.TurnOff(); 
        }
    }

    public void ProjectModal(){
        if(modalProjectsLeanWindow.On){
          modalProjectsLeanWindow.TurnOff();
        }else{
          modalProjectsLeanWindow.TurnOn();
        }
        TurnOff();
    }

    public void DimensionModal(){
      if( modalOrganizationAndPeopleLeanWindow.On || modalInformationAndTechnologyLeanWindow.On || modalPartnersAndSuppliersLeanWindow.On || modalValueStreamsAndProcessesLeanWindow.On){
        TurnOff();
      }else{
        if(myDimensionSelected== "Organization and people"){
           modalOrganizationAndPeopleLeanWindow.TurnOn();
        }
        if(myDimensionSelected== "Information and technology"){
          modalInformationAndTechnologyLeanWindow.TurnOn();
        }
        
        if(myDimensionSelected== "Partners and suppliers"){
          modalPartnersAndSuppliersLeanWindow.TurnOn();  
        }
      
        if(myDimensionSelected== "Value streams and processes"){
          modalValueStreamsAndProcessesLeanWindow.TurnOn(); 
        }
      }
       modalProjectsLeanWindow.TurnOff();
    }
    
}
}