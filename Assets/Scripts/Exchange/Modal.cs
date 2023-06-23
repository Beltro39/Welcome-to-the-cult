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
    public class Modal : MonoBehaviour
    {
        // Start is called before the first frame update
        // User 1
        [SerializeField] private Image[] images = new Image[2];
        [SerializeField] private Text[] names = new Text[2];

        Player playerFirst;
        Player playerSecond;
        Player playerThird;
        SetAvatarSprite setAvatarSprite;

        public void Run(List<Player> players)
        {
            this.playerFirst = players[0];
            this.playerSecond = players[1];
            this.playerThird = players[2];
            setAvatarSprite = GameObject.Find("UIController").GetComponent<SetAvatarSprite>();
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

        }
    }
}

