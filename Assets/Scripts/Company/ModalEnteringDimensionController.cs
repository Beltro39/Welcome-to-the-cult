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
    private string myDimensionSelected;
    LeanWindow confirmModalLeanWindow;
    LeanWindow modalOrganizationAndPeopleLeanWindow;
    LeanWindow modalInformationAndTechnologyLeanWindow;
    LeanWindow modalPartnersAndSuppliersLeanWindow;
    LeanWindow modalValueStreamsAndProcessesLeanWindow;

   
    void Start()
    {
        confirmModalLeanWindow= modalConfirmDimensional.GetComponent<LeanWindow>();
        modalOrganizationAndPeopleLeanWindow= modalOrganizationAndPeople.GetComponent<LeanWindow>();
        modalInformationAndTechnologyLeanWindow= modalInformationAndTechnology.GetComponent<LeanWindow>();
        modalValueStreamsAndProcessesLeanWindow= modalValueStreamsAndProcesses.GetComponent<LeanWindow>();
        //modalPartnersAndSuppliersLeanWindow= modalPartnersAndSuppliers.GetComponent<LeanWindow>();
       
        
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
        /*
        if(myDimensionSelected== "Partners and suppliers"){
          modalPartnersAndSuppliersLeanWindow.TurnOn();  
        }
        */
        if(myDimensionSelected== "Value streams and processes"){
          modalValueStreamsAndProcessesLeanWindow.TurnOn(); 
        }
    }
    
}
}