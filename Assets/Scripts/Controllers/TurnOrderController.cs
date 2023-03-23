
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
    public void Begin(List<PlayerClass> PlayerClassList){
        foreach (PlayerClass netPlayer in PlayerClassList)
        {
            if(netPlayer.getTurnOrder() == "1"){
                FirstPlayerName.text = "FIRST: "+ netPlayer.getNickname();
                setAvatarSprite.setImage(FirstPlayerImage, netPlayer.getAvatar());
                SetImageColor.setColor(FirstTurnImage, netPlayer.getCompanyDimension());
            }
            if(netPlayer.getTurnOrder() == "2"){
                SecondPlayerName.text = "SECOND: "+ netPlayer.getNickname();
                setAvatarSprite.setImage(SecondPlayerImage, netPlayer.getAvatar());
                SetImageColor.setColor(SecondTurnImage, netPlayer.getCompanyDimension());
            }
             if(netPlayer.getTurnOrder() == "3"){
                ThirdPlayerName.text = "THIRD: "+ netPlayer.getNickname();
                setAvatarSprite.setImage(ThirdPlayerImage, netPlayer.getAvatar());
                SetImageColor.setColor(ThirdTurnImage, netPlayer.getCompanyDimension());
            }
        }
    }
}
}
