using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectController : MonoBehaviour
{

    [SerializeField] GameObject titleBackground;
    [SerializeField] GameObject infoTitle;
    [SerializeField] GameObject infoCard;
    [SerializeField] GameObject handle;
    [SerializeField] GameObject scrollWay;
    [SerializeField] GameObject panel;

    [SerializeField] Sprite easyTitleBackground;
    [SerializeField] Sprite normalTitleBackground;
    [SerializeField] Sprite hardTitleBackground;

    [SerializeField] Sprite easyInfoTitle;
    [SerializeField] Sprite normalInfoTitle;
    [SerializeField] Sprite hardInfoTitle;

    [SerializeField] Sprite easyInfoCard;
    [SerializeField] Sprite normalInfoCard;
    [SerializeField] Sprite hardInfoCard;

    [SerializeField] Sprite easyHandle;
    [SerializeField] Sprite normalHandle;
    [SerializeField] Sprite hardHandle;

    [SerializeField] Sprite easyScrollWay;
    [SerializeField] Sprite normalScrollWay;
    [SerializeField] Sprite hardScrollWay;


    [SerializeField] Color easyBackground;
    [SerializeField] Color normalBackground;
    [SerializeField] Color hardBackground;

    [SerializeField] Text projectGain_txt;
    [SerializeField] Text projectDuration_txt;
    [SerializeField] GameObject cardPrefab;

    [SerializeField] List<ProjectCard> easyProjects = new List<ProjectCard>();
    [SerializeField] List<ProjectCard> normalProjects = new List<ProjectCard>();
    [SerializeField] List<ProjectCard> hardProjects = new List<ProjectCard>();

    [SerializeField] GameObject contentProjects;

    public List<GameObject> cardsDisplay = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        setEasyProjects();
    } 

    public void setEasyProjects(){
        assignProyectCards(easyProjects);
        titleBackground.GetComponent<Image>().sprite = easyTitleBackground;
        infoTitle.GetComponent<Image>().sprite = easyInfoTitle;
        infoCard.GetComponent<Image>().sprite = easyInfoCard;
        handle.GetComponent<Image>().sprite = easyHandle;
        scrollWay.GetComponent<Image>().sprite = easyScrollWay;
        panel.GetComponent<Image>().color = easyBackground;

        projectGain_txt.text = "$20";
        projectDuration_txt.text = "1";

    }


    public void setNormalProjects(){
        assignProyectCards(normalProjects);
        titleBackground.GetComponent<Image>().sprite = normalTitleBackground;
        infoTitle.GetComponent<Image>().sprite = normalInfoTitle;
        infoCard.GetComponent<Image>().sprite = normalInfoCard;
        handle.GetComponent<Image>().sprite = normalHandle;
        scrollWay.GetComponent<Image>().sprite = normalScrollWay;
        panel.GetComponent<Image>().color = normalBackground;

        projectGain_txt.text = "$50";
        projectDuration_txt.text = "2";
    }
    
    public void setHardProjects(){
        assignProyectCards(hardProjects);
        titleBackground.GetComponent<Image>().sprite = hardTitleBackground;
        infoTitle.GetComponent<Image>().sprite = hardInfoTitle;
        infoCard.GetComponent<Image>().sprite = hardInfoCard;
        handle.GetComponent<Image>().sprite = hardHandle;
        scrollWay.GetComponent<Image>().sprite = hardScrollWay;
        panel.GetComponent<Image>().color = hardBackground;

        projectGain_txt.text = "$100";
        projectDuration_txt.text = "3";
    }


    void assignProyectCards(List<ProjectCard> projectsToAssign){
        int numCards = cardsDisplay.Count;
        for(int i = numCards - 1 ; i>=0; i--){
            Destroy(cardsDisplay[i]);
            cardsDisplay.RemoveAt(i);          
        }
        foreach(ProjectCard project in projectsToAssign){
            GameObject extraCard = Instantiate(cardPrefab) as GameObject;
            extraCard.GetComponent<ProjectBigCardDisplay>().projectCard = project;
            extraCard.GetComponent<ProjectBigCardDisplay>().sendUpdate();
            extraCard.transform.SetParent(contentProjects.transform);
            extraCard.transform.localScale = new Vector3(1,1,1);
            cardsDisplay.Add(extraCard);
        }
    }
}
