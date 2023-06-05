using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Lean.Gui{
public class ProjectBigCardDisplay : MonoBehaviour
{
    public ProjectCard projectCard;

    public Text projectDescription;
    public Text nameStakeholder;
    public Image imageStakeholder;
    public GameObject[] circulos;
    public Image[] resources;
    public Text[] amounts;

    public Image requirementBox;
    public Image stakeholderBox;

    public Sprite[] requirements;
    public Sprite[] stakeholderBackgrounds;
    public Color[] colorBackgrounds;
    public Color[] colorSelect;

     // Start is called before the first frame updat


 
    
    public void Build()
    {
        nameStakeholder.text = projectCard.NameStakeHolder;
        imageStakeholder.sprite = projectCard.ImageStakeHolder;
        //projectDescription.text = projectCard.Title;

        bool[] lista ={true, true, true, true, true};
        if(projectCard.Difficulty == 0){
            lista[0] = false; lista[2] = false;
        }else if(projectCard.Difficulty == 1){
            lista[1] = false;
        }else{

        }
        int j = 0;
        for (int i = 0; i < 5; i++){
            if(lista[i]){
                circulos[i].SetActive(true);
                resources[i].gameObject.SetActive(true);
                amounts[i].gameObject.SetActive(true);
                resources[i].sprite = projectCard.ResourcesSprite[j];
                amounts[i].text =$"LVL {projectCard.ResourcesAmount[j].ToString()}";
                j++;
            }else{
                circulos[i].SetActive(false);
                resources[i].gameObject.SetActive(false);
                amounts[i].gameObject.SetActive(false);
            }
         }
            
        requirementBox.sprite = requirements[projectCard.Difficulty];
        stakeholderBox.sprite = stakeholderBackgrounds[projectCard.Difficulty];
        gameObject.GetComponent<Image>().color = colorBackgrounds[projectCard.Difficulty];
    }


       public void selectCardButton(){

        if(ProjectController.selectedCard == this.projectCard){
            ProjectController.selectedCard = null;
        }else{
            ProjectController.selectedCard = this.projectCard;            
        }

        ProjectController.checkSelectedCard();
        
    }

    public void selectCard(){
        gameObject.GetComponent<Outline>().effectColor = colorSelect[projectCard.Difficulty];
    }

    public void unselectCard(){
        gameObject.GetComponent<Outline>().effectColor = Color.clear;
    }
}
}