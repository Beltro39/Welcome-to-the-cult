using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAvatarSprite : MonoBehaviour
{
    [SerializeField] Sprite latinaSprite;
    [SerializeField] Sprite japaneseSprite;
    [SerializeField] Sprite americanSprite;
    [SerializeField] Sprite blackSprite;
    [SerializeField] Sprite ukrainSprite;
    [SerializeField] Sprite mexicanSprite;
    [SerializeField] Sprite ugandanSprite;
    [SerializeField] Sprite bobSprite;

     public void setImage(Image image, int i){
       if(i==0){
          image.sprite= latinaSprite;
       }
       if(i==1){
         image.sprite= japaneseSprite;
       }
       if(i==2){
         image.sprite= americanSprite;
       }
       if(i==3){
          image.sprite= blackSprite;
       }
       if(i==4){
          image.sprite= ukrainSprite;
       }
       if(i==5){
          image.sprite= mexicanSprite;
       }
       if(i==6){
          image.sprite= ugandanSprite;
       }
       if(i==7){
          image.sprite= bobSprite;
       }
      
    }
}
