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
    [SerializeField] GameObject imageFlower;
    [SerializeField] int[] rewards;
    [SerializeField] LeanWindow modalAnim;
    [SerializeField] LeanWindow modalReward;

    private ProjectCard project;
    private Player playerCompany;
    
    static Queue<ProjectToken> initialProjects = new Queue<ProjectToken>();


    //movility
    private bool movement = false;
    private bool dificcultyMovement = false;
    static public bool individualMovement = false;
    static public bool finalizeAnim = false;

    private enum Station {InitialStation, secondStation, MediumStation, thirdStation, finalStation};
    private  Dictionary<Station, int> StationPoints = new Dictionary<Station,int>()
    {
        {Station.InitialStation, 1},
        {Station.secondStation, 3},
        {Station.MediumStation, 4},
        {Station.thirdStation, 6},
        {Station.finalStation, 10}
    };
    static Dictionary<Station, Queue<ProjectToken>> projectByStation = new Dictionary<Station, Queue<ProjectToken>>()
    {
        {Station.InitialStation, new Queue<ProjectToken>()},
        {Station.secondStation, new Queue<ProjectToken>()},
        {Station.MediumStation, new Queue<ProjectToken>()},
        {Station.thirdStation, new Queue<ProjectToken>()},
        {Station.finalStation, new Queue<ProjectToken>()}
    };

    private Queue<ProjectToken> actualIterateQueue;

    private Queue<Transform> tokenWay = new Queue<Transform>();
    private Queue<Station> tokenStations = new Queue<Station>();
     
    public ProjectCard Project { get => project; set => project = value; }
    public Player Company { get => playerCompany; set => playerCompany = value; }


    

    public void Create(ProjectCard project, Player company, List<Transform> pointsWay)
    {
        this.pointsWay = pointsWay;
        this.project = project;
        playerCompany = company;
        Difficulty projectDifficulty = (Difficulty) project.Difficulty;
        initialProjects.Enqueue(this);
        setColor();
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
        imageFlower.SetActive(false);   
    }

    public void advance(){
        imageToken.SetActive(true);
        imageFlower.SetActive(true);
        StartCoroutine(DoMovement());
    }

    public void setColor(){
       if(playerCompany.getCompanyDimension()=="Organization and people"){
          imageFlower.GetComponent<Image>().color = imageFlower.GetComponent<Colors>().naranja;
       }
       if(playerCompany.getCompanyDimension()=="Information and technology"){
         imageFlower.GetComponent<Image>().color = imageFlower.GetComponent<Colors>().azul;
       }
       if(playerCompany.getCompanyDimension()=="Partners and suppliers"){
         imageFlower.GetComponent<Image>().color = imageFlower.GetComponent<Colors>().verde;
       }
       if(playerCompany.getCompanyDimension()=="Value streams and processes"){
          imageFlower.GetComponent<Image>().color = imageFlower.GetComponent<Colors>().morado;
       }
    }

    IEnumerator DoMovement(){
        Station nextStation = tokenStations.Dequeue();
        int indexNextPointStation = StationPoints[nextStation];
        Transform nextPointStation = pointsWay[indexNextPointStation];
        Transform nextPoint = tokenWay.Dequeue();
        
        while (nextPoint != nextPointStation)
        {
            movement = false;
            transform.DOMove(nextPoint.position, 1f)
            .OnComplete(() => finalizeMovement());
            yield return new WaitUntil(() => getMovement());
            nextPoint = tokenWay.Dequeue();
        }
        
        if(projectByStation[nextStation].Count>0){
            int numTokens = projectByStation[nextStation].Count + 1;
            
            float radius = 0.3f;
            int acum = 0;
            Vector3 newPos;
            float angle; 


            foreach(ProjectToken tokenInvade in projectByStation[nextStation])
            {
                angle = acum * Mathf.PI*2f / numTokens;
                newPos = new Vector3(Mathf.Cos(angle)*radius, Mathf.Sin(angle)*radius,0);
                movement = false;
                tokenInvade.transform.DOMove(nextPoint.position + newPos, 0.5f)
                .OnComplete(() => finalizeMovement());
                yield return new WaitUntil(() => getMovement());
                acum++;
            }
            angle = acum * Mathf.PI*2f / numTokens;
            newPos = new Vector3(Mathf.Cos(angle)*radius, Mathf.Sin(angle)*radius,0);
            movement = false;
            transform.DOMove(nextPoint.position, 1f)
            .OnComplete(() => finalizeMovement());
            yield return new WaitUntil(() => getMovement());
            movement = false;
            transform.DOMove(nextPoint.position + newPos, 0.5f)
            .OnComplete(() => finalizeMovement());
            yield return new WaitUntil(() => getMovement());



        }else{
            movement = false;
            transform.DOMove(nextPoint.position, 1f)
            .OnComplete(() => finalizeMovement());
            yield return new WaitUntil(() => getMovement());
        }
        
        ProjectToken.individualMovement = true;
        projectByStation[nextStation].Enqueue(this);
    }

    private void finalizeMovement(){
        movement = true;
    }

    public void RunAnimation(){
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation(){
        ProjectToken.finalizeAnim = false;
        actualIterateQueue = projectByStation[Station.thirdStation];
        StartCoroutine(iterateQueue());
        yield return new WaitUntil(() => getDificcultyMovement());
        actualIterateQueue = projectByStation[Station.MediumStation];
        StartCoroutine(iterateQueue());
        yield return new WaitUntil(() => getDificcultyMovement());
        actualIterateQueue = projectByStation[Station.secondStation];
        StartCoroutine(iterateQueue());
        yield return new WaitUntil(() => getDificcultyMovement());
        actualIterateQueue = projectByStation[Station.InitialStation];
        StartCoroutine(iterateQueue());
        yield return new WaitUntil(() => getDificcultyMovement());
        actualIterateQueue = initialProjects;
        StartCoroutine(iterateQueue());
        yield return new WaitUntil(() => getDificcultyMovement());
        yield return new WaitForSeconds(3f);
        modalAnim.TurnOff();
        if(projectByStation[Station.finalStation].Count>0){
            //Dar premio no sé si lo alcance hacer
            
            while(projectByStation[Station.finalStation].Count > 0)
            {
                ProjectToken tokenFinish = projectByStation[Station.finalStation].Dequeue();
                int projectFinishDifficulty = tokenFinish.Project.Difficulty;
                tokenFinish.Company.getItilianos().AddAmount(rewards[projectFinishDifficulty]);
                Destroy(tokenFinish.gameObject);
            }

            modalReward.TurnOn();



        }else{
            AnimationFinish();
        }
    }

    IEnumerator iterateQueue(){
        dificcultyMovement = false;
        while (actualIterateQueue.Count > 0)
        {
            ProjectToken projectToMove = actualIterateQueue.Dequeue();
            projectToMove.advance();
            yield return new WaitUntil(() => ProjectToken.getIndividualMovement());
            ProjectToken.individualMovement = false;
        }
        dificcultyMovement = true;

        
    }

    static public bool getIndividualMovement(){return ProjectToken.individualMovement;}
    static public bool getFinalizeAnim(){return ProjectToken.finalizeAnim;}
    private bool getDificcultyMovement(){return dificcultyMovement;}
    private bool getMovement(){return movement;}

    public void AnimationFinish(){
        ProjectToken.finalizeAnim = true;
    }
}
}