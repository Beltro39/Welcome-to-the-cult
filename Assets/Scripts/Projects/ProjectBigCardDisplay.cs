using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectBigCardDisplay : MonoBehaviour
{
    public ProjectCard projectCard;

    public Text projectDescription;
    public Text nameStakeholder;
    public Image fondo;
    public Image imageStakeholder;
    public Image fondoTitulo;
    public Image circulo1;
    public Image circulo2;
    public Image circulo3;
    public Image circulo4;
    public Image circulo5;
    public Image resource1;
    public Image resource2;
    public Image resource3;
    public Image resource4;
    public Image resource5;
    public Text amount1;
    public Text amount2;
    public Text amount3;
    public Text amount4;
    public Text amount5;

    public Image requirementBox;
    public Image stakeholderBox;
    public Sprite easyRequirement;
    public Sprite easyStakeholderBackground;
    public Sprite normalRequirement;
    public Sprite normalStakeholderBackground;
    public Sprite hardRequirement;
    public Sprite hardStakeholderBackground;

     // Start is called before the first frame update
    void Start()
    {
        sendUpdate();
    }
    
    public void sendUpdate()
    {
        nameStakeholder.text = projectCard.nameStakeholder;
        imageStakeholder.sprite = projectCard.imageStakeholder;
        projectDescription.text = projectCard.titulo;
        circulo1.sprite = projectCard.circulo;
        circulo2.sprite = projectCard.circulo;
        circulo3.sprite = projectCard.circulo;
        circulo4.sprite = projectCard.circulo;
        circulo5.sprite = projectCard.circulo;
        resource1.sprite = projectCard.resource1;
        resource2.sprite = projectCard.resource2;
        resource3.sprite = projectCard.resource3;
        resource4.sprite = projectCard.resource4;
        resource5.sprite = projectCard.resource5;
        amount1.text = projectCard.amount1;
        amount2.text = projectCard.amount2;
        amount3.text = projectCard.amount3;
        amount4.text = projectCard.amount4;
        amount5.text = projectCard.amount5;

        dificultyDesign();
        //fondoTitulo.sprite = projectCard.fondoTitulo;
        //fondo.sprite = projectCard.fondo;
         
    }


    void dificultyDesign()
    {

        resource1.gameObject.SetActive(true);
        amount1.gameObject.SetActive(true);
        circulo1.gameObject.SetActive(true);
        resource2.gameObject.SetActive(true);
        amount2.gameObject.SetActive(true);
        circulo2.gameObject.SetActive(true);
        resource3.gameObject.SetActive(true);
        amount3.gameObject.SetActive(true);
        circulo3.gameObject.SetActive(true);
        resource4.gameObject.SetActive(true);
        amount4.gameObject.SetActive(true);
        circulo4.gameObject.SetActive(true);
        resource5.gameObject.SetActive(true);
        amount5.gameObject.SetActive(true);
        circulo5.gameObject.SetActive(true);

        if(projectCard.dificulty.Equals("easy")){
             resource1.gameObject.SetActive(false);
             amount1.gameObject.SetActive(false);
             circulo1.gameObject.SetActive(false);
             resource3.gameObject.SetActive(false);
             amount3.gameObject.SetActive(false);
             circulo3.gameObject.SetActive(false);

             resource4.sprite = projectCard.resource1;
             resource2.sprite = projectCard.resource2;
             resource5.sprite = projectCard.resource3;
             amount4.text = projectCard.amount1;
             amount2.text = projectCard.amount2;
             amount5.text = projectCard.amount3;
             gameObject.GetComponent<Image>().color = new Color32(252,230,27,255);
             requirementBox.sprite = easyRequirement;
             stakeholderBox.sprite = easyStakeholderBackground;

            
            
            
        }else if(projectCard.dificulty.Equals("medio")){
             resource2.gameObject.SetActive(false);
             circulo2.gameObject.SetActive(false);
             amount2.gameObject.SetActive(false);

             resource1.sprite = projectCard.resource1;
             resource3.sprite = projectCard.resource2;
             resource4.sprite = projectCard.resource3;
             resource5.sprite = projectCard.resource4;
             amount1.text = projectCard.amount1;
             amount3.text = projectCard.amount2;
             amount4.text = projectCard.amount3;
             amount5.text = projectCard.amount4;
             gameObject.GetComponent<Image>().color = new Color32(93,199,206,255);
             requirementBox.sprite = normalRequirement;
             stakeholderBox.sprite = normalStakeholderBackground;
        }else{
            
            resource1.sprite = projectCard.resource1;
            resource2.sprite = projectCard.resource2;
            resource3.sprite = projectCard.resource3;
            resource4.sprite = projectCard.resource4;
            resource5.sprite = projectCard.resource5;
            amount1.text = projectCard.amount1;
            amount2.text = projectCard.amount2;
            amount3.text = projectCard.amount3;
            amount4.text = projectCard.amount4;
            amount5.text = projectCard.amount5;
            gameObject.GetComponent<Image>().color = new Color32(135,27,38,255);
            requirementBox.sprite = hardRequirement;
            stakeholderBox.sprite = hardStakeholderBackground;
        }
    }
}
