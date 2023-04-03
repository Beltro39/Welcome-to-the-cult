using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCircleCompany : MonoBehaviour
{
    [SerializeField] Sprite orangeSprite;
    [SerializeField] Sprite blueSprite;
    [SerializeField] Sprite greenSprite;
    [SerializeField] Sprite purpleSprite;
    [SerializeField] Image imageCircle;
    
    public void Run(string dimension){
    	if(dimension=="Organization and people"){
          imageCircle.sprite = orangeSprite;
       }
       if(dimension=="Information and technology"){
          imageCircle.sprite = blueSprite;
       }
       if(dimension=="Partners and suppliers"){
         imageCircle.sprite = greenSprite;
       }
       if(dimension =="Value streams and processes"){
          imageCircle.sprite = purpleSprite;
       }
    }
}

