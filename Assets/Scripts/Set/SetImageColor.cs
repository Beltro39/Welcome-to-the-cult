using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImageColor : MonoBehaviour
{
    [SerializeField] GameObject UIControllerGO;
     Colors color;
    public void setColor(Image image, string dimension){
         color = UIControllerGO.GetComponent<Colors>();
       if(dimension=="Organization and people"){
          image.color= color.naranja;
       }
       if(dimension=="Information and technology"){
         image.color= color.azul;
       }
       if(dimension=="Partners and suppliers"){
         image.color= color.verde;
       }
       if(dimension=="Value streams and processes"){
          image.color= color.morado;
       }
    }
}
