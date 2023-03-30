using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lean.Gui{
public class ShowResources : MonoBehaviour
{
    [SerializeField] private GameObject UIControllerGO;
    [SerializeField] private GameObject modal;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject imageFirstResource;
    [SerializeField] private GameObject imageSecondResource;
    [SerializeField] private GameObject imageThirdResource;
    [SerializeField] private GameObject imageFourthResource;
    [SerializeField] private GameObject textFirstResource;
    [SerializeField] private GameObject textSecondResource;
    [SerializeField] private GameObject textThirdResource;
    [SerializeField] private GameObject textFourthResource;
    [SerializeField] private GameObject textFirstResourceType;
    [SerializeField] private GameObject textSecondResourceType;
    [SerializeField] private GameObject textThirdResourceType;
    [SerializeField] private GameObject textFourthResourceType;
    [SerializeField] private Sprite junior;
    [SerializeField] private Sprite semisenior;
    [SerializeField] private Sprite senior;
    [SerializeField] private Sprite architect;
    [SerializeField] private Sprite servers;
    [SerializeField] private Sprite satellites;
    [SerializeField] private Sprite ia;
    [SerializeField] private Sprite hosting;
    [SerializeField] private Sprite employeeRecruitment;
    [SerializeField] private Sprite skillfulTechnology;
    [SerializeField] private Sprite barganingPower;
    [SerializeField] private Sprite researchProjects;
    Queue<Player> queuePlayer;
    
    private float x,y;                              //para posicion
    private string first, second, third, fourth;    //para cantidad o nivel
    Colors color;

    public bool Begin(Queue<Player> queuePlayer){
       this.queuePlayer = queuePlayer;
       return true;
    }

    public void movePanel(string resourceType, int targetPlayer)
    {
        if(targetPlayer == 1)
        {
            if(resourceType == "employees"){ x = -440; y = 180; }
            else if(resourceType == "technologies"){ x = -325; y = 180; }
            else if(resourceType == "abilities"){ x = -125; y = 180; }
            else{ x = 0; y = 0; }
        }
        else if(targetPlayer == 2)
        {
            x = -340; y = 56;
        }
        else
        {
            x = 340; y = 56;
        }
        panel.transform.localPosition = new Vector3((int)x, (int)y, (int)0);
    }

    public void changeImage(string resourceType)
    {
        if(resourceType == "employees")
        {
            imageFirstResource.GetComponent<Image>().sprite = junior;
            imageSecondResource.GetComponent<Image>().sprite = semisenior;
            imageThirdResource.GetComponent<Image>().sprite = senior;
            imageFourthResource.GetComponent<Image>().sprite = architect;
        } 
        else if(resourceType == "technologies")
        {
            imageFirstResource.GetComponent<Image>().sprite = servers;
            imageSecondResource.GetComponent<Image>().sprite = satellites;
            imageThirdResource.GetComponent<Image>().sprite = ia;
            imageFourthResource.GetComponent<Image>().sprite = hosting;
        }
        else if(resourceType == "abilities")
        {
            imageFirstResource.GetComponent<Image>().sprite = employeeRecruitment;
            imageSecondResource.GetComponent<Image>().sprite = skillfulTechnology;
            imageThirdResource.GetComponent<Image>().sprite = barganingPower;
            imageFourthResource.GetComponent<Image>().sprite = researchProjects;
        }
        
    }

    public void changeTextColor(string resourceType)
    {
        color = UIControllerGO.GetComponent<Colors>();
        if(resourceType == "employees")
        {
            textFirstResource.GetComponent<Text>().color = color.naranja;
            textSecondResource.GetComponent<Text>().color = color.naranja;
            textThirdResource.GetComponent<Text>().color = color.naranja;
            textFourthResource.GetComponent<Text>().color = color.naranja;

            textFirstResourceType.GetComponent<Text>().color = color.naranja;
            textSecondResourceType.GetComponent<Text>().color = color.naranja;
            textThirdResourceType.GetComponent<Text>().color = color.naranja;
            textFourthResourceType.GetComponent<Text>().color = color.naranja;
        } 
        else if(resourceType == "technologies")
        {
            textFirstResource.GetComponent<Text>().color = color.azul;
            textSecondResource.GetComponent<Text>().color = color.azul;
            textThirdResource.GetComponent<Text>().color = color.azul;
            textFourthResource.GetComponent<Text>().color = color.azul;

            textFirstResourceType.GetComponent<Text>().color = color.azul;
            textSecondResourceType.GetComponent<Text>().color = color.azul;
            textThirdResourceType.GetComponent<Text>().color = color.azul;
            textFourthResourceType.GetComponent<Text>().color = color.azul;
        }
        else if(resourceType == "abilities")
        {
            textFirstResource.GetComponent<Text>().color = color.morado;
            textSecondResource.GetComponent<Text>().color = color.morado;
            textThirdResource.GetComponent<Text>().color = color.morado;
            textFourthResource.GetComponent<Text>().color = color.morado;

            textFirstResourceType.GetComponent<Text>().color = color.morado;
            textSecondResourceType.GetComponent<Text>().color = color.morado;
            textThirdResourceType.GetComponent<Text>().color = color.morado;
            textFourthResourceType.GetComponent<Text>().color = color.morado;
        }
        
    }

    public void setTextTypes(string resourceType){
        if(resourceType == "employees")
        {
            textFirstResourceType.GetComponent<Text>().text = "JUNIORS";
            textSecondResourceType.GetComponent<Text>().text = "SEMISENIORS";
            textThirdResourceType.GetComponent<Text>().text = "SENIORS";
            textFourthResourceType.GetComponent<Text>().text = "ARCHITECTS";
        } 
        else if(resourceType == "technologies")
        {
            textFirstResourceType.GetComponent<Text>().text = "SERVERS";
            textSecondResourceType.GetComponent<Text>().text = "SATELLITES";
            textThirdResourceType.GetComponent<Text>().text = "I.A";
            textFourthResourceType.GetComponent<Text>().text = "HOSTING";
        }
        else if(resourceType == "abilities")
        {
            textFirstResourceType.GetComponent<Text>().text = "EMPLOYEE RECRUITMENT";
            textSecondResourceType.GetComponent<Text>().text = "SKILLFUL IN TECHNOLOGY";
            textThirdResourceType.GetComponent<Text>().text = "BARGANING POWER";
            textFourthResourceType.GetComponent<Text>().text = "RESEARCH AND PROJECTS";
        }
    }

    //resourceType (employees, technologies, abilities) ; targetPlayer (local, left, right)
    public void setTextResources(string resourceType, int targetPlayer)
    {
        first= "";
        second= "";
        third= "";
        fourth= "";
        foreach(Player player in queuePlayer){
            if(player.getPosition() == targetPlayer){
               if(resourceType == "employees"){ 
                  first = player.getListEmployees().getJuniors().getCurrentAvailableResource().ToString() 
                  +"/"+player.getListEmployees().getJuniors().getAmount().ToString();
                  Debug.Log("first: "+first);
                  second = player.getListEmployees().getSemiSeniors().getCurrentAvailableResource().ToString() 
                  +"/"+player.getListEmployees().getSemiSeniors().getAmount().ToString();
                   Debug.Log("second: "+second);
                  third = player.getListEmployees().getSeniors().getCurrentAvailableResource().ToString() 
                  +"/"+player.getListEmployees().getSeniors().getAmount().ToString();
                  Debug.Log("third: "+third);
                  fourth = player.getListEmployees().getArchitects().getCurrentAvailableResource().ToString() 
                  +"/"+player.getListEmployees().getArchitects().getAmount().ToString();
                  Debug.Log("fourth: "+fourth);
               } 
               if(resourceType == "technologies"){
                   first = player.getListTechnologies().getServers().getCurrentAvailableResource().ToString()
                   +"/"+player.getListTechnologies().getServers().getAmount().ToString();
                   second =player.getListTechnologies().getSatellites().getCurrentAvailableResource().ToString()
                   +"/"+player.getListTechnologies().getSatellites().getAmount().ToString(); 
                   third = player.getListTechnologies().getIA().getCurrentAvailableResource().ToString()
                   +"/"+player.getListTechnologies().getIA().getAmount();
                   fourth= player.getListTechnologies().getHosting().getCurrentAvailableResource().ToString()
                   +"/"+player.getListTechnologies().getHosting().getAmount().ToString();
               }
               if(resourceType == "abilities"){
                   first = player.getListAbilities().getRecruitment().getCurrentAvailableResource().ToString()
                   +"/"+player.getListAbilities().getRecruitment().getAmount().ToString();
                   second = player.getListAbilities().getSkillful().getCurrentAvailableResource().ToString()
                   +"/"+player.getListAbilities().getSkillful().getAmount().ToString();
                   third = player.getListAbilities().getBargain().getCurrentAvailableResource().ToString()
                   +"/"+player.getListAbilities().getBargain().getAmount().ToString();
                   fourth = player.getListAbilities().getResearch().getCurrentAvailableResource().ToString()
                   +"/"+player.getListAbilities().getResearch().getAmount().ToString();
               }
            }
        }
        
        textFirstResource.GetComponent<Text>().text = first;
        textSecondResource.GetComponent<Text>().text = second;
        textThirdResource.GetComponent<Text>().text = third;
        textFourthResource.GetComponent<Text>().text = fourth;
    }

    //resourceAndTarget = resourceType (employees, technologies, abilities)  _ targetPlayer (local, left, right)
    public void showResources(string resourceAndTarget)
    {
        string[] splitted = resourceAndTarget.Split('_');
        string resourceType = splitted[0];
        int targetPlayer = int.Parse(splitted[1]);
        movePanel(resourceType, targetPlayer);
        changeImage(resourceType);
        changeTextColor(resourceType);
        setTextTypes(resourceType);
        setTextResources(resourceType, targetPlayer);
    }
    
}
}
