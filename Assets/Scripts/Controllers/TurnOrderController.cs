
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Lean.Gui{
public class TurnOrderController : MonoBehaviour
{
    [SerializeField] GameObject UIControllerGO;

    [SerializeField] private Text FirstPlayerName;
    [SerializeField] private Text SecondPlayerName;
    [SerializeField] private Text ThirdPlayerName;

    [SerializeField] private Image FirstPlayerImage;
    [SerializeField] private Image SecondPlayerImage;
    [SerializeField] private Image ThirdPlayerImage;

    [SerializeField] private Image FirstTurnImage;
    [SerializeField] private Image SecondTurnImage;
    [SerializeField] private Image ThirdTurnImage;

    SetImageColor SetImageColor;
    SetAvatarSprite setAvatarSprite;

    public void Start(){
        setAvatarSprite = UIControllerGO.GetComponent<SetAvatarSprite>();
        SetImageColor = UIControllerGO.GetComponent<SetImageColor>();
    }

    // Start is called before the first frame update
    public bool Run(Queue<Player> queuePlayer){
        foreach (Player player in queuePlayer)
        {
            Debug.Log(player.getNickname());
            if(player.getTurnOrder() == "1"){
                FirstPlayerName.text = "FIRST: "+ player.getNickname();
                setAvatarSprite.setImage(FirstPlayerImage, player.getAvatar());
                SetImageColor.setColor(FirstTurnImage, player.getCompanyDimension());
            }
            if(player.getTurnOrder() == "2"){
                SecondPlayerName.text = "SECOND: "+ player.getNickname();
                setAvatarSprite.setImage(SecondPlayerImage, player.getAvatar());
                SetImageColor.setColor(SecondTurnImage, player.getCompanyDimension());
            }
             if(player.getTurnOrder() == "3"){
                ThirdPlayerName.text = "THIRD: "+ player.getNickname();
                setAvatarSprite.setImage(ThirdPlayerImage, player.getAvatar());
                SetImageColor.setColor(ThirdTurnImage, player.getCompanyDimension());
            }
        }
        return true;
    }
}
}
