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

    public void changeRanges()
    {
        int indice = (int)diccionario[panel_active]["actual_index"];
        GameObject panel = (GameObject) diccionario[panel_active]["panel"];
        panel.transform.GetChild(indice).gameObject.SetActive(false);
        foreach (KeyValuePair<string, Dictionary<string, object>> entrada in diccionario) {
            string dificulty = entrada.Key;
            int first_index = (int)diccionario[dificulty]["first_index"];
            int max = (int) diccionario[dificulty]["max"];
            int last_index = (int) diccionario[dificulty]["last_index"];
            first_index += max;
            last_index = first_index+max-1;
            if(first_index >= ((GameObject)diccionario[dificulty]["panel"]).transform.childCount || last_index >= ((GameObject)diccionario[dificulty]["panel"]).transform.childCount){
                first_index = 0;
                last_index = first_index + max - 1;
            }
            diccionario[dificulty]["first_index"] = first_index;
            diccionario[dificulty]["last_index"] = last_index;
        }
        panel.transform.GetChild((int)diccionario[panel_active]["first_index"]).gameObject.SetActive(true);
        diccionario[panel_active]["actual_index"] = diccionario[panel_active]["first_index"];
    }

}
