using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Get;
using Lean.Gui;
using System.Linq;
using System.ComponentModel;
using UnityEditor.SceneManagement;
using System;
namespace Get
{
    public class ModalExchange : MonoBehaviour
    {
        // Start is called before the first frame update
        // User 1
        [SerializeField] private Image[] images = new Image[2];
        [SerializeField] private Text[] names = new Text[2];
        [SerializeField] private GameObject mainModal;
        [SerializeField] private GameObject modalRefuese;
        [SerializeField] private GameObject sucefullExchange;


        Player playerFirst;
        Player playerSecond;
        Player playerThird;
        SetAvatarSprite setAvatarSprite;
        GameController gameController;

        public void Run(List<Player> players)
        {
            this.playerSecond = players[1];
            this.playerThird = players[2];
            setAvatarSprite = GameObject.Find("UIController").GetComponent<SetAvatarSprite>();
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }
        public void DsiplayValues()
        {
            setAvatarSprite.setImage(images[0], playerSecond.getAvatar());
            setAvatarSprite.setImage(images[1], playerThird.getAvatar());
            names[0].text = playerFirst.getNickname();
            names[1].text = playerSecond.getNickname();
        }

        public void DeclineButton()
        {
            modalRefuese.GetComponent<LeanWindow>().TurnOn();
        }
        public void ExchangeButton(int idPlayer)
        {
            mainModal.GetComponent<LeanWindow>().TurnOff();
        }
        public void succefullExchange()
        {
            sucefullExchange.GetComponent<LeanWindow>().TurnOn();
        }
    }
}

