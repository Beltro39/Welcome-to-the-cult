using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Lean.Gui{
public class SpawnCompany : MonoBehaviour
{

    [SerializeField] private GameObject companyModal;
    [SerializeField] private GameObject confirmModal;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject companyPrefab;

    GameController GameController;
    GameObject company;
    SetImageColor SetImageColor;
   
    void Start(){
        GameObject GameControllerGO= GameObject.Find("GameController"); 
        GameObject UIControllerGO = GameObject.Find("UIController"); 
        GameController = GameControllerGO.GetComponent<GameController>();
        SetImageColor=  UIControllerGO.GetComponent<SetImageColor>();
    }

   public bool Run(Player player){
        LeanWindow companyModalLean= companyModal.GetComponent<LeanWindow>();
        companyModalLean.TurnOn();
        company = Instantiate(companyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        company.transform.SetParent(companyModal.transform);
        company.transform.localScale =  new Vector3(0.8f, 0.8f, 1f);
        company.transform.position  = new Vector3(0,0.5f,0);
        SetImageColor.setColor(company.gameObject.GetComponent<Image>(), player.getCompanyDimension());
        LeanDrag comapanyLeanDrag= company.GetComponent<LeanDrag>();
       comapanyLeanDrag.OnBegin.AddListener(changeCompanyParent);
       comapanyLeanDrag.OnEnd.AddListener(OpenConfirmModal);
        return true;
   }

     public void changeCompanyParent(){
        company.transform.parent = panel.transform;
        Transform companyTransform = panel.transform.Find("Company(Clone)");
        int childCount = panel.transform.childCount;
        companyTransform.SetSiblingIndex(0);

        LeanWindow companyModalLean= companyModal.GetComponent<LeanWindow>();
        companyModalLean.TurnOff();
    }

    public void OpenConfirmModal(){
       LeanWindow confirmModalLeanWindow= confirmModal.GetComponent<LeanWindow>();
       confirmModalLeanWindow.TurnOn();
       //Destroy(company);
    }

    public void destroyCompany(){
        Destroy(company);
        LeanWindow confirmModalLeanWindow= confirmModal.GetComponent<LeanWindow>();
        confirmModalLeanWindow.TurnOff();
    }

      
}
}