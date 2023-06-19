using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Lean.Gui{
public class ProjectPanelController : MonoBehaviour
{
    [SerializeField] GameObject cardObject;


    //Animation
    [SerializeField] LeanWindow modalProjectAnimation;
    [SerializeField] GameObject tokenPrefab;
    [SerializeField] GameObject tokenParent;
    [SerializeField] List<Transform> pointsWay = new List<Transform>();
    [SerializeField] ProjectToken generalProjectToken;
    
    private Player currentPlayer;
    ValidateExchangeResources validateExchangeResources;
 
    

    public enum Difficulty { Easy, Medium, Hard, Difficulty};

    Dictionary<Player, Dictionary<int, int>> indexesByPlayer = new Dictionary<Player, Dictionary<int, int>>(); 
    /*{
        {"easy", new Dictionary<string, object>() {
            {"0", 2},
            {"1", 0},
            {"2", 0},
            {"difficulty", 1}
        }},
        {"medium", new Dictionary<string, object>() {
            {"max", 4},
            {"first_index", 0},
            {"actual_index", 0},
            {"last_index", 3}
        }},
        {"hard", new Dictionary<string, object>() {
            {"max", 2},
            {"first_index", 0},
            {"actual_index", 0},
            {"last_index", 2}
        }}
    };*/

    



    public void DisplayProject()
    {
        
        int actualDifficulty = indexesByPlayer[currentPlayer][(int) Difficulty.Difficulty];
        List<ProjectCard> projects = currentPlayer.GetProjects(actualDifficulty);

        GameObject panelCardObject = cardObject.transform.parent.gameObject;

        if(projects.Count > 0){
            panelCardObject.SetActive(true);
            ProjectCardDisplay cardDisplay = cardObject.GetComponent<ProjectCardDisplay>();
            int indexProjectList = indexesByPlayer[currentPlayer][actualDifficulty];
            cardDisplay.projectCard = projects[indexProjectList];
            cardDisplay.Build();
        }else{panelCardObject.SetActive(false);}
        
    }

    public void leftBtn(){
        int actualDifficulty = indexesByPlayer[currentPlayer][(int) Difficulty.Difficulty];
        int indexProjectList = indexesByPlayer[currentPlayer][actualDifficulty];
        int countProjects = currentPlayer.GetProjects(actualDifficulty).Count;

        if((indexProjectList - 1) < 0){
            indexesByPlayer[currentPlayer][actualDifficulty] = countProjects-1;
        }else{
            indexesByPlayer[currentPlayer][actualDifficulty]= indexProjectList-1;
        }
    }

     public void rightBtn(){

        int actualDifficulty = indexesByPlayer[currentPlayer][(int) Difficulty.Difficulty];
        int indexProjectList = indexesByPlayer[currentPlayer][actualDifficulty];
        int countProjects = currentPlayer.GetProjects(actualDifficulty).Count;

        if((indexProjectList + 1) >= countProjects){
            indexesByPlayer[currentPlayer][actualDifficulty] = 0;
        }else{
            indexesByPlayer[currentPlayer][actualDifficulty]= indexProjectList+1;
        }

        DisplayProject();
    }

    public void Run(Player currentPlayer)
    {
        this.currentPlayer = currentPlayer;
        validateExchangeResources = new ValidateExchangeResources(currentPlayer);

        if(!indexesByPlayer.ContainsKey(currentPlayer))
        {
            Dictionary<int, int> barajas = new Dictionary<int, int>()
            {
                {(int) Difficulty.Easy, 0},
                {(int) Difficulty.Hard, 0},
                {(int) Difficulty.Medium, 0},
                {(int) Difficulty.Difficulty, 0}
            };
            indexesByPlayer.Add(currentPlayer, barajas);
        }
        DisplayProject();
        
    }


    public void Begin()
    {
        
        modalProjectAnimation.TurnOn();
        generalProjectToken.RunAnimation();
        
    }

    public bool accomplishRequirements(ProjectCard projectEvaluate){
        // Mi idea es que aqui pregunten por si cumple con los requisitos;
        string[] requirementList = projectEvaluate.ResourceType;
        int[] amountList = projectEvaluate.ResourcesAmount;
        bool cumpleUno = true;
        int acum = 0;
        while (acum < requirementList.Length && cumpleUno)
        {
            cumpleUno =  validateExchangeResources.ValidatePlayerHasResources(
                requirementList[acum], amountList[acum]
            );
            acum++;
        }

        return cumpleUno;
    }

    public void AddProject(ProjectCard card){

        PayResources(card);


        int difficultyCard = card.Difficulty;
        int newIndexDisplay = currentPlayer.GetProjects(difficultyCard).Count;
        indexesByPlayer[currentPlayer][(int) Difficulty.Difficulty] = difficultyCard;
        indexesByPlayer[currentPlayer][difficultyCard] = newIndexDisplay;
        currentPlayer.addProject(card);
        CreateToken(card);  
        DisplayProject();
    }

    private void PayResources(ProjectCard projectEvaluate){
        string[] requirementList = projectEvaluate.ResourceType;
        int[] amountList = projectEvaluate.ResourcesAmount;
        int acum = 0;
        while (acum < requirementList.Length )
        {
            validateExchangeResources.TakeResourcesFromPlayer(
                requirementList[acum], amountList[acum]
            );
            acum++;
        }
    }

    public void SetProjects(int difficulty){
        indexesByPlayer[currentPlayer][(int) Difficulty.Difficulty] = difficulty;
        DisplayProject();
    }

    public void CreateToken(ProjectCard card){
        GameObject extraToken = Instantiate(tokenPrefab) as GameObject;
        extraToken.GetComponent<ProjectToken>().Create(card, currentPlayer, pointsWay);
        extraToken.transform.SetParent(tokenParent.transform);
        extraToken.transform.localScale = new Vector3(1,1,1);
                
    }

    



}

}