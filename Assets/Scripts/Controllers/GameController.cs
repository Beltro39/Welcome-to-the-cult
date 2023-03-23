using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lean.Gui{
public class GameController : MonoBehaviour
{
    [SerializeField] GameObject UIControllerGO;
    [SerializeField] GameObject GameControllerGO;
    SetProperties setProperties;
    TurnOrderController turnOrderController;
    ShowResources showResources;
    SpawnCompany SpawnCompany;
    List<PlayerClass> PlayerClassList;
    BuyResources BuyResources;
    DisableButtons DisableButtons;
    byte setPropertiesEventCode=3;
 

    // Start is called before the first frame update
    void Start()
    {
        setProperties = UIControllerGO.GetComponent<SetProperties>();
        turnOrderController= GameControllerGO.GetComponent<TurnOrderController>();
        showResources = UIControllerGO.GetComponent<ShowResources>();
        SpawnCompany= UIControllerGO.GetComponent<SpawnCompany>();
        BuyResources= GameControllerGO.GetComponent<BuyResources>();
        DisableButtons= UIControllerGO.GetComponent<DisableButtons>();
        StartCoroutine(ExampleCoroutine());
        //setProperties.Begin();
    }

   public List<PlayerClass> getPlayerClassList(){
       return PlayerClassList;
   }


   public void PropertiesHaveBeenSet(){
       PlayerClassList= setProperties.getListPlayerClass();
       turnOrderController.Begin(PlayerClassList); 
       showResources.Begin(PlayerClassList);
       SpawnCompany.Begin();
        foreach (PlayerClass netPlayer in PlayerClassList){
            if(netPlayer.getPosition() == "local"){
                BuyResources.Begin(netPlayer);
                DisableButtons.Begin(netPlayer);
            }
        }
   }

 


     IEnumerator ExampleCoroutine()
    { 
       yield return new WaitForSeconds(0.5f);
       setProperties.Begin();
       //PlayerClassList= setProperties.Begin();
      // turnOrderController.Begin(PlayerClassList); 
      // showResources.Begin(PlayerClassList);
       
    }   

    
}
}