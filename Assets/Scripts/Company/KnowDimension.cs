using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Lean.Gui{
public class KnowDimension : MonoBehaviour
{
    private GameObject confirmModal;
    private Text modalText;
    private Outline outline;
    GameObject uiControllerGO;
    Colors color;
    ModalEnteringDimensionController ModalEnteringDimensionController;
    // Start is called before the first frame update
    void Start()
    {
        confirmModal= GameObject.Find("Modal Confirm Dimension"); 
        modalText = GameObject.Find("Modal Confirm Text").GetComponent<Text>();
        uiControllerGO = GameObject.Find("UIController");
        ModalEnteringDimensionController= uiControllerGO.GetComponent<ModalEnteringDimensionController>();
        color = uiControllerGO.GetComponent<Colors>();
        outline = GameObject.Find("Modal Confirm Text").GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Organization and people"){
            modalText.text = "ORGANIZATION AND PEOPLE";
            modalText.color = color.naranja;
            outline.effectColor = color.naranja;
            ModalEnteringDimensionController.setMyDimensionSelected("Organization and people");
        }
        if (col.gameObject.tag == "Information and technology"){
             modalText.text ="INFORMATION AND TECHNOLOGY";
             modalText.color= color.azul;
             outline.effectColor = color.azul;
             ModalEnteringDimensionController.setMyDimensionSelected("Information and technology");
        }
        if (col.gameObject.tag == "Value streams and processes"){
             modalText.text = "VALUE STREAMS AND PROCESSES";
             ModalEnteringDimensionController.setMyDimensionSelected("Value streams and processes");
             modalText.color = color.morado;
             outline.effectColor = color.morado;
        }
        if (col.gameObject.tag == "Partners and suppliers"){
             modalText.text = "PARTNERS AND SUPPLIERS";
             ModalEnteringDimensionController.setMyDimensionSelected("Partners and suppliers");
            modalText.color = color.verde;
            outline.effectColor = color.verde;
        } 
    }
}

}