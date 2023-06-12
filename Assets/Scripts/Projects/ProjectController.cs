using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
    [SerializeField] GameObject projectPanelDestination;
    

    [Space(10)]
    [Header("cards")]
    [SerializeField] GameObject cardSelect;

    private ProjectPanelController panelProjectRigth;
    private Difficulty actualDifficulty;
    
    static List<GameObject> cardsDisplay = new List<GameObject>();
    public static ProjectCard selectedCard;

   

    void Start()
    {
        panelProjectRigth = projectPanelDestination.transform.parent.gameObject.GetComponent<ProjectPanelController>();
        SetProjects(Difficulty.Easy);
        DOTween.Init();
    } 

    public bool Run(){
        SetProjects(Difficulty.Easy);
        transform.parent.gameObject.GetComponent<LeanWindow>().TurnOn();
        return true;
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
        actualDifficulty = difficulty;
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
        noSelectedCardAdvice.GetComponent<LeanWindow>().TurnOff();
        selectProjectInfo.GetComponent<LeanWindow>().TurnOff();
        selectedCard = null;
        ProjectController.checkSelectedCard();
    }

    public void Decline(){
        noSelectedCardAdvice.GetComponent<LeanWindow>().TurnOn();
    }

    public void select_button(){
        if(ProjectController.selectedCard){

            
            cardSelect.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
            ProjectCardDisplay selectedCardDisplay = cardSelect.GetComponent<ProjectCardDisplay>();
            selectedCardDisplay.projectCard = ProjectController.selectedCard;
            selectedCardDisplay.Build();
            selectProjectInfo.GetComponent<LeanWindow>().TurnOn();
            selectProjectInfo.GetComponent<CanvasGroup>().interactable = true;
            cardSelect.SetActive(true);

        }else{
            Decline();
        }
    }

    public void confirm_select(){
        bool cumpleRequisitos = panelProjectRigth.accomplishRequirements();
        if(cumpleRequisitos){
            selectProjectInfo.GetComponent<CanvasGroup>().interactable = false;
            removeCard(selectedCard);
            SetProjects(actualDifficulty);
            cardSelect.transform.DOMove(projectPanelDestination.transform.position, 3)
            .OnComplete(() => finalizeMovement());
        }else{
            //Se abre ventana de no tiene los suficientes recursos
        }
        
    }

    private void finalizeMovement(){
        panelProjectRigth.AddProject(selectedCard);
        cardSelect.SetActive(false);
        StartCoroutine(panelProjectRigth.waitAnimation());
        confirmDecline();
    }

    private void removeCard(ProjectCard card){
        if(card.Difficulty == (int) Difficulty.Easy){
            easyProjects.Remove(card);
        }else if(card.Difficulty == (int) Difficulty.Medium){
            normalProjects.Remove(card);
        }else{
            hardProjects.Remove(card);
        }
    }
}
}