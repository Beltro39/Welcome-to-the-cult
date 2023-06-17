using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Lean.Gui{
public class ProjectToken : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard};
    [SerializeField] Sprite[] imagesToken;
    private List<Transform> pointsWay = new List<Transform>();
    [SerializeField] GameObject imageToken;

    private ProjectCard project;
    private Player playerCompany;



    //movility
    private enum Station {InitialStation, secondStation, MediumStation, thirdStation, finalStation};
    private  Dictionary<Station, int> StationPoints = new Dictionary<Station,int>()
    {
        {Station.InitialStation, 1},
        {Station.secondStation, 3},
        {Station.MediumStation, 4},
        {Station.thirdStation, 6},
        {Station.finalStation, 10}
    };

    private Queue<Transform> tokenWay = new Queue<Transform>();
    private Queue<Station> tokenStations = new Queue<Station>();
     
    public ProjectCard Project { get => project; set => project = value; }
    public Player Company { get => playerCompany; set => playerCompany = value; }

    public void create(ProjectCard project, Player company, List<Transform> pointsWay)
    {
        this.pointsWay = pointsWay;
        this.project = project;
        Difficulty projectDifficulty = (Difficulty) project.Difficulty;
        imageToken.GetComponent<Image>().sprite = imagesToken[(int) projectDifficulty];
        foreach (Transform point in pointsWay){
            tokenWay.Enqueue(point);
        }
        Transform spawnPoint = tokenWay.Dequeue();
        transform.position = spawnPoint.position;
        tokenStations.Enqueue(Station.InitialStation);
        if(projectDifficulty == Difficulty.Medium){
            tokenStations.Enqueue(Station.MediumStation);
        }else if(projectDifficulty == Difficulty.Hard){
            
            tokenStations.Enqueue(Station.secondStation);
            tokenStations.Enqueue(Station.thirdStation);
        }
        tokenStations.Enqueue(Station.finalStation);   

        imageToken.SetActive(false);     
    }

    public void advance(){

    }


    
}
}