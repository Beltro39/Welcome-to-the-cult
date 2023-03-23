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

    [SerializeField] private GameObject[] cambiarPersonaje;

    private GameObject[][] cambiarPersonajesArray;
    private int[] index_array;

    void Start()
    { 
        cambiarPersonajesArray  = new GameObject[cambiarPersonaje.Length][];
        index_array = new int[cambiarPersonaje.Length];
        for(int i = 0; i < cambiarPersonaje.Length; i++){
            index_array[i] = 0;
            cambiarPersonajesArray[i] = new GameObject[cambiarPersonaje[i].transform.childCount];
            for(int j = 0; j < cambiarPersonajesArray[i].Length; j++){
                cambiarPersonajesArray[i][j] = cambiarPersonaje[i].transform.GetChild(j).gameObject;
                if(j == index_array[i]){
                     cambiarPersonajesArray[i][j].SetActive(true);
                }
                else{
                    GameObject objX =  cambiarPersonajesArray[i][j];
                    objX.SetActive(false);
                }
            }
        }
       
    }
      

    public void btnLeft(int i){ 
        cambiarPersonajesArray[i][index_array[i]].SetActive(false);
        index_array[i]--;
        if(index_array[i] <0){
            index_array[i] = cambiarPersonajesArray[i].Length -1;
        }
        cambiarPersonajesArray[i][index_array[i]].SetActive(true);
    }

    public void btnRight(int i){ 
        cambiarPersonajesArray[i][index_array[i]].SetActive(false);
        index_array[i]++;
        if(index_array[i]==cambiarPersonajesArray[i].Length ){
            index_array[i] = 0;
        }
        cambiarPersonajesArray[i][index_array[i]].SetActive(true);
    }

    public void btnOK(){  
        for(int i = 0; i < avatarNameText.Length; i++){
            PlayerPrefs.SetString($"P{i}AvatarName", avatarNameText[i].text);  
            PlayerPrefs.SetInt($"P{i}AvatarSprite", index_array[i]); 
        }
        SceneManager.LoadScene("GameBoard");
    }

}
