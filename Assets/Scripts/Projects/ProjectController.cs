using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Lean.Gui{
public class ProjectController : MonoBehaviour
{

    public enum Difficulty { Easy, Medium, Hard};

    [SerializeField] GameObject titleBackground;
    [SerializeField] GameObject infoTitle;
    [SerializeField] GameObject infoCard;
    [SerializeField] GameObject handle;
    [SerializeField] GameObject scrollWay;
    [SerializeField] GameObject panel;

    [SerializeField] Sprite[] titleBackgroundArray;
    [SerializeField] Sprite[] infoTitleArray;
    [SerializeField] Sprite[] infoCardArray;
    [SerializeField] Sprite[] handleArray;
    [SerializeField] Sprite[] scrollWayArray;
    [SerializeField] Color[] backgroundColorArray;

    [SerializeField] Text projectGain_txt;
    [SerializeField] Text projectDuration_txt;
    [SerializeField] GameObject cardPrefab;

    [SerializeField] List<ProjectCard> easyProjects = new List<ProjectCard>();
    [SerializeField] List<ProjectCard> normalProjects = new List<ProjectCard>();
    [SerializeField] List<ProjectCard> hardProjects = new List<ProjectCard>();

    [SerializeField] GameObject contentProjects;

    [Space(10)]
    [Header("paneles")]
    [SerializeField] GameObject noSelectedCardAdvice;
    [SerializeField] GameObject selectProjectInfo;

    [Space(10)]
    [Header("cards")]
    [SerializeField] GameObject panelCard;
    [SerializeField] GameObject cardPrefabSelect;
    
    
    private GameObject selectedCardDisplayObject;
    static List<GameObject> cardsDisplay = new List<GameObject>();
    public static ProjectCard selectedCard;

   

    void Start()
    {
        SetProjects(Difficulty.Easy);
    } 

    public void SetProjectsInt(int difficulty){
        SetProjects((Difficulty) difficulty);
    }


    public void SetProjects(Difficulty difficulty){
        List<ProjectCard>[] projectLists = new List<ProjectCard>[]
        {
            easyProjects,
            normalProjects,
            hardProjects
        };
        int intDifficulty = (int) difficulty;
        AssignProyectCards(projectLists[intDifficulty]);
        titleBackground.GetComponent<Image>().sprite = titleBackgroundArray[intDifficulty];
        infoTitle.GetComponent<Image>().sprite = infoTitleArray[intDifficulty];
        infoCard.GetComponent<Image>().sprite = infoCardArray[intDifficulty];
        handle.GetComponent<Image>().sprite = handleArray[intDifficulty];
        scrollWay.GetComponent<Image>().sprite = scrollWayArray[intDifficulty];
        panel.GetComponent<Image>().color = backgroundColorArray[intDifficulty];
        if(difficulty == Difficulty.Easy){
            projectGain_txt.text = "20";
            projectDuration_txt.text = "1";
        }
        if(difficulty == Difficulty.Medium){
            projectGain_txt.text = "50";
            projectDuration_txt.text = "2";
        }
        if(difficulty == Difficulty.Hard){
            projectGain_txt.text = "100";
            projectDuration_txt.text = "3";
        }
    }

    void AssignProyectCards(List<ProjectCard> projectsToAssign){
        cardsDisplay.ForEach(Destroy);
        cardsDisplay.Clear();
        foreach(ProjectCard project in projectsToAssign){
            GameObject extraCard = Instantiate(cardPrefab) as GameObject;
            extraCard.GetComponent<ProjectBigCardDisplay>().projectCard = project;
            extraCard.GetComponent<ProjectBigCardDisplay>().Build();
            extraCard.transform.SetParent(contentProjects.transform);
            extraCard.transform.localScale = new Vector3(1,1,1);
            cardsDisplay.Add(extraCard);
        }
        ProjectController.checkSelectedCard();
    }


    public static void checkSelectedCard(){
        foreach(GameObject cardDisplayObject in cardsDisplay){
            ProjectBigCardDisplay cardDisplay = cardDisplayObject.GetComponent<ProjectBigCardDisplay>();
            if(cardDisplay.projectCard == selectedCard){
                cardDisplay.selectCard();
            }else{
                cardDisplay.unselectCard();
            }
        }
    }

    public void confirmDecline(){
        transform.parent.gameObject.GetComponent<LeanWindow>().TurnOff();
        noSelectedCardAdvice.GetComponent<LeanWindow>().TurnOn();
        selectedCard = null;
    }

    public void Decline(){
        noSelectedCardAdvice.GetComponent<LeanWindow>().TurnOn();
    }

    public void select_button(){
        if(ProjectController.selectedCard){

            if(!selectedCardDisplayObject){
                selectedCardDisplayObject = Instantiate(cardPrefabSelect) as GameObject;
                selectedCardDisplayObject.transform.SetParent(panelCard.transform);
                selectedCardDisplayObject.transform.localScale = new Vector3(1,1,1);
                selectedCardDisplayObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
            }

            ProjectCardDisplay selectedCardDisplay = selectedCardDisplayObject.GetComponent<ProjectCardDisplay>();
            selectedCardDisplay.projectCard = ProjectController.selectedCard;
            selectedCardDisplay.Build();
            selectProjectInfo.GetComponent<LeanWindow>().TurnOn();
        }else{
            Decline();
        }
    }
}
}