/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Lean.Gui{
public class CompanySpawned :  MonoBehaviour
{
    string NickName;
    // Start is called before the first frame update
  
    /*
     public void OnPhotonInstantiate(PhotonMessageInfo info)
     {
      GameObject UIControllerGO= GameObject.Find("UIController"); 
      GameObject panel = GameObject.Find("Panel External Elements");
      SetImageColor SetImageColor=  UIControllerGO.GetComponent<SetImageColor>();
      

       object[] instantiationData = info.photonView.InstantiationData;
      
       foreach (Photon.Realtime.Player netPlayer in PhotonNetwork.PlayerList){
         if(netPlayer.IsLocal){
           ActorNumber= netPlayer.ActorNumber;
           NickName= netPlayer.NickName;
         }
       }
        if(info.Sender.ActorNumber != ActorNumber){
            Destroy((GameObject) info.Sender.TagObject);
            gameObject.transform.parent = panel.transform;
            Destroy(gameObject.GetComponent<LeanDrag>());
        }
        info.Sender.TagObject = gameObject;
        SetImageColor.setColor(gameObject.GetComponent<Image>(), (string)instantiationData[0]);

      } 

      public void InstantiateObject(string objectName, object[] instantiationData, GameObject parentObject)
{
    GameObject UIControllerGO = GameObject.Find("UIController");
    GameObject panel = GameObject.Find("Panel External Elements");
    SetImageColor SetImageColor = UIControllerGO.GetComponent<SetImageColor>();

    // Instantiate the object
    GameObject instantiatedObject = Instantiate(Resources.Load<GameObject>(objectName));

    // Set the parent object if specified
    if (parentObject != null)
    {
        instantiatedObject.transform.SetParent(parentObject.transform);
    }

    // Set the tag object to keep track of the instantiated object
    instantiatedObject.tag = "InstantiatedObject";

    // Set the instantiation data
    SetImageColor.setColor(instantiatedObject.GetComponent<Image>(), (string)instantiationData[0]);
}

}
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Lean.Gui{
public class CompanySpawned :  MonoBehaviour
{
}
}
