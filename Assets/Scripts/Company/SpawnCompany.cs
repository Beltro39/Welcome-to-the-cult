using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lean.Gui{
public class SpawnCompany : MonoBehaviour
{

    [SerializeField] private GameObject companyModal;
    [SerializeField] private GameObject confirmModal;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject GameControllerGO;
     [SerializeField] private GameObject companyPrefab;
    GameController GameController;
    GameObject company;
    object[] myCustomInitData= new object[1];
   
    void Start(){
        GameController= GameControllerGO.GetComponent<GameController>();
    }


    // Start is called ;before the first frame update
   public void Begin(){
       myCustomInitData[0]= "";
       List<PlayerClass> ListPlayerClass= GameController.getPlayerClassList();
       foreach(PlayerClass netPlayer in ListPlayerClass){
            netPlayer.getCompanyDimension();
            company = Instantiate(companyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            company.transform.SetParent(companyModal.transform);
            company.transform.localScale =  new Vector3(0.8f, 0.8f, 1f);
            company.transform.position  = new Vector3(0,0.5f,0);
           
       }

       LeanDrag comapanyLeanDrag= company.GetComponent<LeanDrag>();
       comapanyLeanDrag.OnBegin.AddListener(changeCompanyParent);
       comapanyLeanDrag.OnEnd.AddListener(OpenConfirmModal);

   }

     public void changeCompanyParent(){
        company.transform.parent = panel.transform;
        LeanWindow companyModalLean= companyModal.GetComponent<LeanWindow>();
        companyModalLean.TurnOff();
    }

    public void OpenConfirmModal(){
       LeanWindow confirmModalLeanWindow= confirmModal.GetComponent<LeanWindow>();
       confirmModalLeanWindow.TurnOn();
    }

      
}
}