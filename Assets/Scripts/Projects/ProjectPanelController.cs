using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectPanelController : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    private int[] index_array;
    private string panel_active = "easy";

    Dictionary<string, Dictionary<string, object>> diccionario = new Dictionary<string, Dictionary<string, object>>() 
    {
        {"easy", new Dictionary<string, object>() {
            {"max", 2},
            {"first_index", 0},
            {"actual_index", 0},
            {"last_index", 1}
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
    };


    

     void Start()
    { 
        int i = 0;
        foreach (KeyValuePair<string, Dictionary<string, object>> entrada in diccionario) {
            string dificulty = entrada.Key;
            diccionario[dificulty]["panel"] = panels[i];
            i++;
        }
    }

/*
    public void debugProperties()
    {
        Debug.Log("Funciona?");
    }

    public List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i< Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }

    public void showChilds(){
        List<GameObject> childsPanel = GetAllChilds(PanelEasy);
        foreach (GameObject child in childsPanel)
          {
              //sirven:
              //child.gameObject.SetActive(false);
              //Debug.Log(child.name);  

              //hace lo mismo xdd:
              //ProjectCardDisplay cardDisplay = child.GetComponent<ProjectCardDisplay>();
              //Debug.Log(cardDisplay.name);

                // funca
              //ProjectCardDisplay cardDisplay = child.GetComponent<ProjectCardDisplay>();
              //Debug.Log(cardDisplay.nameStakeholder.text);
            // Asi se accede a las propiedades del GameObject
            //ProjectCardDisplay cardDisplay = child.GetComponent<ProjectCardDisplay>();
            //Debug.Log(cardDisplay.projectCard.resource2Type);

          }
    }
*/
    public void changeDisplayedProjects(string dificulty)
    {
        ((GameObject)diccionario["easy"]["panel"]).SetActive(false);
        ((GameObject)diccionario["medium"]["panel"]).SetActive(false);
        ((GameObject)diccionario["hard"]["panel"]).SetActive(false);
        ((GameObject)diccionario[dificulty]["panel"]).SetActive(true);
        this.panel_active = dificulty;
    }


    public void leftBtn(){
        int indice = (int)diccionario[panel_active]["actual_index"];
        GameObject panel = (GameObject) diccionario[panel_active]["panel"];
        panel.transform.GetChild(indice).gameObject.SetActive(false);
        int new_indice = indice-1; 
        if(new_indice < (int) diccionario[panel_active]["first_index"]){
            new_indice = (int) diccionario[panel_active]["last_index"];
        }
        panel.transform.GetChild(new_indice).gameObject.SetActive(true);
        diccionario[panel_active]["actual_index"] = new_indice; 
    }

     public void rightBtn(){
        int indice = (int)diccionario[panel_active]["actual_index"];
        GameObject panel = (GameObject) diccionario[panel_active]["panel"];
        panel.transform.GetChild(indice).gameObject.SetActive(false);
        int new_indice = indice+1; 
        if(new_indice > (int) diccionario[panel_active]["last_index"]){
            new_indice = (int) diccionario[panel_active]["first_index"];
        }
        panel.transform.GetChild(new_indice).gameObject.SetActive(true);
        diccionario[panel_active]["actual_index"] = new_indice; 
    }
/*
    public void scrollProjectCards(string direction)
    {


        // Look for the actual active card and the target card, then switches between
        for (int i = inicio; i <= final; i++)
        {
            actualProjectCard = activeProjectsGroup.transform.GetChild(i).gameObject;
            if(actualProjectCard.activeSelf)
            {
                if(direction == "left")
                {
                    int indexBefore = i-1;

                    // If out of range
                    if(indexBefore < inicio)
                    {
                        indexBefore = final;
                    }
                    targetProjectCard = activeProjectsGroup.transform.GetChild(indexBefore).gameObject;
                    actualProjectCard.SetActive(false);
                    targetProjectCard.SetActive(true);
                } else 
                {
                    int indexAfter = i+1;
                    
                    // If out of range
                    if(indexAfter > final)
                    {
                        indexAfter = inicio;
                    }
                    targetProjectCard = activeProjectsGroup.transform.GetChild(indexAfter).gameObject;
                    actualProjectCard.SetActive(false);
                    targetProjectCard.SetActive(true);
                }
                break;
            }
        }
          
    }

    public void changeRanges()
    {
        // change easy index to next max range
        firstIndexEasy = firstIndexEasy + maxEasy;
        lastIndexEasy = firstIndexEasy + maxEasy-1;
        if(firstIndexEasy >= PanelEasy.transform.childCount || lastIndexEasy >= PanelEasy.transform.childCount){
            firstIndexEasy = 0;
            lastIndexEasy = firstIndexEasy + maxEasy -1;
        }

        // change medio index to next max range
        firstIndexMedio = firstIndexMedio + maxMedio;
        lastIndexMedio = firstIndexMedio + maxMedio -1;
        if(firstIndexMedio >= PanelMedio.transform.childCount || lastIndexMedio >= PanelMedio.transform.childCount){
            firstIndexMedio = 0;
            lastIndexMedio = firstIndexMedio + maxMedio -1;
        }

        // change hard index to next max range
        firstIndexHard = firstIndexHard + maxHard;
        lastIndexHard = firstIndexHard + maxHard-1;
        if(firstIndexHard >= PanelHard.transform.childCount || lastIndexHard >= PanelHard.transform.childCount){
            firstIndexHard = 0;
            lastIndexHard = firstIndexHard + maxHard-1;
        }

        setFirstProjects();
    }

    public void setFirstProjects(){

        // Disable all cards
        List<GameObject> childsPanel = GetAllChilds(PanelEasy);
        foreach (GameObject card in childsPanel)
        {
            card.gameObject.SetActive(false);
        }
        childsPanel.Clear();
        childsPanel = GetAllChilds(PanelMedio);
        foreach (GameObject card in childsPanel)
        {
            card.gameObject.SetActive(false);
        }
        childsPanel.Clear();
        childsPanel = GetAllChilds(PanelHard);
        foreach (GameObject card in childsPanel)
        {
            card.gameObject.SetActive(false);
        }
        childsPanel.Clear();

        // Enable first card of range
        PanelEasy.transform.GetChild(firstIndexEasy).gameObject.SetActive(true);
        PanelMedio.transform.GetChild(firstIndexMedio).gameObject.SetActive(true);
        PanelHard.transform.GetChild(firstIndexHard).gameObject.SetActive(true);
    }

    public void projectsActived()
    {
        Debug.Log("Easy projects are: ");
        Debug.Log(PanelEasy.activeSelf);
        Debug.Log("Medio projects are: ");
        Debug.Log(PanelMedio.activeSelf);
        Debug.Log("Hard projects are: ");
        Debug.Log(PanelHard.activeSelf);
    }
    */
}
