using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectCardDisplay : MonoBehaviour
{
    public ProjectCard projectCard;
    public Image projectDescription;
    public Text nameStakeholder;
    public Image imageStakeholder;

    public GameObject[] circulos;
    public Image[] resources;
    public Text[] amounts;

    public Image BackgroundBox;
    public Image titleBox;

    public Sprite[] titles;
    public Sprite[] Backgrounds;


    // Start is called before the first frame update
    public void Build()
    {
        nameStakeholder.text = projectCard.NameStakeHolder;
        imageStakeholder.sprite = projectCard.ImageStakeHolder;
        projectDescription.sprite = projectCard.DescriptionSprite;

        bool[] lista ={true, true, true, true, true};
        if(projectCard.Difficulty == 0){
            lista[0] = false; lista[2] = false;
        }else if(projectCard.Difficulty == 1){
            lista[1] = false;
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
            
        titleBox.sprite = titles[projectCard.Difficulty];
        BackgroundBox.sprite = Backgrounds[projectCard.Difficulty];
    }
}
