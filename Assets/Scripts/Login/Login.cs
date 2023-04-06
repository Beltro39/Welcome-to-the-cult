using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Login : MonoBehaviour
{
    [SerializeField] private Text[] avatarNameText;
    private string avatarName;

    [SerializeField] private GameObject[] personajes;

    private GameObject[][] personajesArray;
    private int[] index_array;

    void Start()
    { 
        personajesArray  = new GameObject[personajes.Length][];
        index_array = new int[personajes.Length];
        for(int i = 0; i < personajes.Length; i++){
            index_array[i] = 0;
            personajesArray[i] = new GameObject[personajes[i].transform.childCount];
            for(int j = 0; j < personajesArray[i].Length; j++){
                personajesArray[i][j] = personajes[i].transform.GetChild(j).gameObject;
                if(j == index_array[i]){
                     personajesArray[i][j].SetActive(true);
                }
                else{
                    GameObject objX =  personajesArray[i][j];
                    objX.SetActive(false);
                }
            }
        }
       
    }
      

    public void btnLeft(int i){ 
        personajesArray[i][index_array[i]].SetActive(false);
        index_array[i]--;
        if(index_array[i] <0){
            index_array[i] = personajesArray[i].Length -1;
        }
        personajesArray[i][index_array[i]].SetActive(true);
    }

    public void btnRight(int i){ 
        personajesArray[i][index_array[i]].SetActive(false);
        index_array[i]++;
        if(index_array[i]==personajesArray[i].Length ){
            index_array[i] = 0;
        }
        personajesArray[i][index_array[i]].SetActive(true);
    }

    public void btnOK(){  
        for(int i = 0; i < avatarNameText.Length; i++){
            PlayerPrefs.SetString($"P{i}AvatarName", avatarNameText[i].text);  
            PlayerPrefs.SetInt($"P{i}AvatarSprite", index_array[i]); 
        }
        SceneManager.LoadScene("GameBoard");
    }

}
