using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Lean.Gui{
public class KnowDimension : MonoBehaviour
{
    private GameObject confirmModal;
    private Text modalText;
    GameObject uiControllerGO;
    ModalEnteringDimensionController ModalEnteringDimensionController;
    // Start is called before the first frame update
    void Start()
    {
        confirmModal= GameObject.Find("Modal Confirm Dimension"); 
        modalText = GameObject.Find("Modal Confirm Text").GetComponent<Text>();
        uiControllerGO = GameObject.Find("UIController");
        ModalEnteringDimensionController= uiControllerGO.GetComponent<ModalEnteringDimensionController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Organization and people"){
            modalText.text = "Organization and people";
            ModalEnteringDimensionController.setMyDimensionSelected("Organization and people");
        }
        if (col.gameObject.tag == "Information and technology"){
             modalText.text ="Information and technology";
             ModalEnteringDimensionController.setMyDimensionSelected("Information and technology");
        }
        if (col.gameObject.tag == "Value streams and processes"){
             modalText.text = "Value streams and processes";
             ModalEnteringDimensionController.setMyDimensionSelected("Value streams and processes");
        }
        if (col.gameObject.tag == "Partners and suppliers"){
             modalText.text = "Partners and suppliers";
             ModalEnteringDimensionController.setMyDimensionSelected("Partners and suppliers");
        } 
    }
}

}