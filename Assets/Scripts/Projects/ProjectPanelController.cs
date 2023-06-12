using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lean.Gui{
public class ProjectPanelController : MonoBehaviour
{
    [SerializeField] GameObject cardObject;
    
    private Player currentPlayer;

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

    public bool accomplishRequirements(){
        // Mi idea es que aqui pregunten por si cumple con los requisitos
        return true;
    }

    public void AddProject(ProjectCard card){
        int difficultyCard = card.Difficulty;
        int newIndexDisplay = currentPlayer.GetProjects(difficultyCard).Count;
        indexesByPlayer[currentPlayer][(int) Difficulty.Difficulty] = difficultyCard;
        indexesByPlayer[currentPlayer][difficultyCard] = newIndexDisplay;
        currentPlayer.addProject(card);
        DisplayProject();
        
    }

    public IEnumerator waitAnimation(){
        yield return new WaitForSeconds(3f);
        currentPlayer.setIsActionComplete(true);
    }

    public void SetProjects(int difficulty){
        indexesByPlayer[currentPlayer][(int) Difficulty.Difficulty] = difficulty;
        DisplayProject();
    }

    



}

}