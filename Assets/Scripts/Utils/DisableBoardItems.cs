using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Lean.Gui
{
public class DisableBoardItems : MonoBehaviour
{
    public float transparent = 0.6f; 
    public float total = 1.0f; 

    [SerializeField] private Image[] juniorRequirementsImages1;
    [SerializeField] private Image[] semiSeniorRequirementsImages1;
    [SerializeField] private Image[] seniorRequirementsImages1;
    [SerializeField] private Image[] architectRequirementsImages1;

    [SerializeField] private Image[] juniorRequirementsImages2;
    [SerializeField] private Image[] semiSeniorRequirementsImages2;
    [SerializeField] private Image[] seniorRequirementsImages2;
    [SerializeField] private Image[] architectRequirementsImages2;
    
    [SerializeField] private Image[] techonlogiesImages0;
    [SerializeField] private Image[] techonlogiesImages1;
    [SerializeField] private Image[] techonlogiesImages2;
    [SerializeField] private Image[] techonlogiesImages3;
    [SerializeField] private Image[] techonlogiesImages4;

    [SerializeField] private Text[] techonlogiesText0;
    [SerializeField] private Text[] techonlogiesText1;
    [SerializeField] private Text[] techonlogiesText2;
    [SerializeField] private Text[] techonlogiesText3;
    [SerializeField] private Text[] techonlogiesText4;

    [SerializeField] private Image[] abilitiesImages0;
    [SerializeField] private Image[] abilitiesImages1;
    [SerializeField] private Image[] abilitiesImages2;
    [SerializeField] private Image[] abilitiesImages3;
    [SerializeField] private Image[] abilitiesImages4;

    [SerializeField] private Text[] abilitiesText0;
    [SerializeField] private Text[] abilitiesText1;
    [SerializeField] private Text[] abilitiesText2;
    [SerializeField] private Text[] abilitiesText3;
    [SerializeField] private Text[] abilitiesText4;

    [SerializeField] private Image[] alliesImages0;
    [SerializeField] private Image[] alliesImages1;
    [SerializeField] private Image[] alliesImages2;
    [SerializeField] private Image[] alliesImages3;
    [SerializeField] private Image[] alliesImages4;
    [SerializeField] private Image[] alliesImages5;

    [SerializeField] private Text[] alliesText0;
    [SerializeField] private Text[] alliesText1;
    [SerializeField] private Text[] alliesText2;
    [SerializeField] private Text[] alliesText3;
    [SerializeField] private Text[] alliesText4;
    [SerializeField] private Text[] alliesText5;

    [SerializeField] private Text[] juniorRequirementsText1;
    [SerializeField] private Text[] semiSeniorRequirementsText1;
    [SerializeField] private Text[] seniorRequirementsText1;
    [SerializeField] private Text[] architectRequirementsText1;

    [SerializeField] private Text[] juniorRequirementsText2;
    [SerializeField] private Text[] semiSeniorRequirementsText2;
    [SerializeField] private Text[] seniorRequirementsText2;
    [SerializeField] private Text[] architectRequirementsText2;
    
    private Dictionary<string, Dictionary<int, Image[]>> imageDictionary;
    private Dictionary<string, Dictionary<int, Text[]>> textDictionary;
    private List<Image[]> allImages;
    private List<Text[]> allText;
    string[] resources = 
        { "Juniors", "SemiSeniors", "Seniors", "Architects", "Technologies", "Abilities"
        ,"Ally0","Ally1","Ally2","Ally3","Ally4","Ally5"
    };

    List<Ally> alliesToTransparent;
        
   
    void Start(){
        imageDictionary = new Dictionary<string, Dictionary<int, Image[]>>
            {
                { "Juniors", new Dictionary<int, Image[]> { { 0, juniorRequirementsImages1 }, {1, juniorRequirementsImages1}, {2, juniorRequirementsImages1}, {3, juniorRequirementsImages2}, {4, juniorRequirementsImages2}} },
                { "SemiSeniors", new Dictionary<int, Image[]> { { 0, semiSeniorRequirementsImages1 }, { 1, semiSeniorRequirementsImages1}, {2, semiSeniorRequirementsImages1}, {3, semiSeniorRequirementsImages2}, {4, semiSeniorRequirementsImages2}} },
                { "Seniors", new Dictionary<int, Image[]> { { 0, null }, { 1, seniorRequirementsImages1}, {2, seniorRequirementsImages1}, {3, seniorRequirementsImages1}, {4, seniorRequirementsImages2}} },
                { "Architects", new Dictionary<int, Image[]> { { 0, null }, { 1, null}, {2, architectRequirementsImages1}, {3, architectRequirementsImages1}, {4, architectRequirementsImages2}} },
                { "Technologies", new Dictionary<int, Image[]> { { 0, techonlogiesImages0 }, { 1, techonlogiesImages1}, {2, techonlogiesImages2}, {3, techonlogiesImages3}, {4, techonlogiesImages4}} },
                { "Abilities", new Dictionary<int, Image[]> { { 0, abilitiesImages0 }, { 1, abilitiesImages1}, {2, abilitiesImages2}, {3, abilitiesImages3}, {4, abilitiesImages4}} },
                { "Ally0", new Dictionary<int, Image[]> { { 0, alliesImages0 }, { 1, alliesImages0}, {2, alliesImages0}, {3, alliesImages0}, {4, alliesImages0}} },
                { "Ally1", new Dictionary<int, Image[]> { { 0, alliesImages1 }, { 1, alliesImages1}, {2, alliesImages1}, {3, alliesImages1}, {4, alliesImages1}} },
                { "Ally2", new Dictionary<int, Image[]> { { 0, null }, { 1, alliesImages2}, {2, alliesImages2}, {3, alliesImages2}, {4, alliesImages2}} },
                { "Ally3", new Dictionary<int, Image[]> { { 0, null }, { 1, alliesImages3}, {2, alliesImages3}, {3, alliesImages3}, {4, alliesImages3}} },
                { "Ally4", new Dictionary<int, Image[]> { { 0, null }, { 1, null}, {2, alliesImages4}, {3, alliesImages4}, {4, alliesImages4}} },
                { "Ally5", new Dictionary<int, Image[]> { { 0, null }, { 1, null}, {2, alliesImages5}, {3, alliesImages5}, {4, alliesImages5}} },
            };

        textDictionary = new Dictionary<string, Dictionary<int, Text[]>>
            {
                { "Juniors", new Dictionary<int, Text[]> { { 0, juniorRequirementsText1 }, {1, juniorRequirementsText1}, {2, juniorRequirementsText1}, {3, juniorRequirementsText2}, {4, juniorRequirementsText2}} },
                { "SemiSeniors", new Dictionary<int, Text[]> { { 0, semiSeniorRequirementsText1 }, { 1, semiSeniorRequirementsText1}, {2, semiSeniorRequirementsText1}, {3, semiSeniorRequirementsText2}, {4, semiSeniorRequirementsText2}} },
                { "Seniors", new Dictionary<int, Text[]> { { 0, null }, { 1, seniorRequirementsText1}, {2, seniorRequirementsText1}, {3, seniorRequirementsText1}, {4, seniorRequirementsText2}} },
                { "Architects", new Dictionary<int, Text[]> { { 0, null }, { 1, null}, {2, architectRequirementsText1}, {3, architectRequirementsText1}, {4, architectRequirementsText2}} },
                { "Technologies", new Dictionary<int, Text[]> { { 0, techonlogiesText0 }, { 1, techonlogiesText1}, {2, techonlogiesText2}, {3, techonlogiesText3}, {4, techonlogiesText4}} },
                { "Abilities", new Dictionary<int, Text[]> { { 0, abilitiesText0 }, { 1, abilitiesText1}, {2, abilitiesText2}, {3, abilitiesText3}, {4, abilitiesText4}} },
                { "Ally0", new Dictionary<int, Text[]> { { 0, alliesText0 }, { 1, alliesText0}, {2, alliesText0}, {3, alliesText0}, {4, alliesText0}} },
                { "Ally1", new Dictionary<int, Text[]> { { 0, alliesText1 }, { 1, alliesText1}, {2, alliesText1}, {3, alliesText1}, {4, alliesText1}} },
                { "Ally2", new Dictionary<int, Text[]> { { 0, null }, { 1, alliesText2}, {2, alliesText2}, {3, alliesText2}, {4, alliesText2}} },
                { "Ally3", new Dictionary<int, Text[]> { { 0, null }, { 1, alliesText3}, {2, alliesText3}, {3, alliesText3}, {4, alliesText3}} },
                { "Ally4", new Dictionary<int, Text[]> { { 0, null }, { 1, null}, {2, alliesText4}, {3, alliesText4}, {4, alliesText4}} },
                { "Ally5", new Dictionary<int, Text[]> { { 0, null }, { 1, null}, {2, alliesText5}, {3, alliesText5}, {4, alliesText5}} },
            };

        allImages = new List<Image[]>{
            juniorRequirementsImages1,
            semiSeniorRequirementsImages1,
            seniorRequirementsImages1,
            architectRequirementsImages1,
            juniorRequirementsImages2,
            semiSeniorRequirementsImages2,
            seniorRequirementsImages2,
            architectRequirementsImages2,
            techonlogiesImages0,
            techonlogiesImages1,
            techonlogiesImages2,
            techonlogiesImages3,
            techonlogiesImages4,
            abilitiesImages0,
            abilitiesImages1,
            abilitiesImages2,
            abilitiesImages3,
            abilitiesImages4,
            alliesImages0,
            alliesImages1,
            alliesImages2,
            alliesImages3,
            alliesImages4,
            alliesImages5        
        };

        allText = new List<Text[]>{
            juniorRequirementsText1,
            semiSeniorRequirementsText1,
            seniorRequirementsText1,
            architectRequirementsText1,
            juniorRequirementsText2,
            semiSeniorRequirementsText2,
            seniorRequirementsText2,
            architectRequirementsText2,
            techonlogiesText0,
            techonlogiesText1,
            techonlogiesText2,
            techonlogiesText3,
            techonlogiesText4,
            abilitiesText0,
            abilitiesText1,
            abilitiesText2,
            abilitiesText3,
            abilitiesText4,
            alliesText0,
            alliesText1,
            alliesText2,
            alliesText3,
            alliesText4,
            alliesText5
        };

    alliesToTransparent = new List<Ally>();


        DisableEverything();
    }

    public void DisableEverything(){
        foreach(Image[] images in allImages){
            foreach (Image image in images){
                Color originalColor = image.color;
                Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, transparent);
                image.color = newColor;
            }
        }

        foreach(Text[] Text in allText){
            foreach (Text text in Text){
                Color originalColor = text.color;
                Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, transparent);
                text.color = newColor;
            }
        }
    }

    public bool Run(Player player){
        DisableEverything();

        int recruitmentLVL = player.getListAbilities().getRecruitment().getAmount();
        int skillfulLVL = player.getListAbilities().getSkillful().getAmount();
        int bargainLVL = player.getListAbilities().getBargain().getAmount();
        int researchLVL = player.getListAbilities().getResearch().getAmount();

        foreach(string resource in resources){
            int resourceLVL;
            if(resource == "Technologies"){
                resourceLVL = skillfulLVL;
            }else if(resource == "Abilities"){
                resourceLVL = researchLVL;
            }else if(resource.StartsWith("Ally")){
                resourceLVL = bargainLVL;
            }
            else{
                resourceLVL = recruitmentLVL;
            }
            Image[] images = imageDictionary[resource][resourceLVL];
            if(images != null){
                foreach (Image image in images){
                    Color originalColor = image.color;
                    Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, total);
                    image.color = newColor;
                }
            }
            Text[] texts = textDictionary[resource][resourceLVL];
            if(texts != null){
                foreach (Text text in texts){
                    Color originalColor = text.color;
                    Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, total);
                    text.color = newColor;
                }
            }
            setTransparencyToAllies();
        }
        return true;

    }

    public void SetAlliesInBoard(List<Ally> allies){
        foreach(Ally ally in allies){
            Image[] images;
            Text[] texts;
            if (ally.Difficulty == 0 && ally is Partner){
                images = alliesImages0;
                texts = alliesText0;
            }else if (ally.Difficulty == 0 && ally is Supplier){
                images = alliesImages1;
                texts = alliesText1;
            }else if (ally.Difficulty == 1  && ally is Partner){
                images = alliesImages2;
                texts = alliesText2;
            }else if (ally.Difficulty == 1  && ally is Supplier){
                images = alliesImages3;
                texts = alliesText3;
            }else if (ally.Difficulty == 2  && ally is Partner){
                images = alliesImages4;
                texts = alliesText4;
            }else if (ally.Difficulty == 2  && ally is Supplier){
                images = alliesImages5;
                texts = alliesText5;
            }else{
                images = alliesImages5;
                texts = alliesText5;
            }
            images[0].sprite = ally.ImageStakeholder;
            texts[0].text = ally.NameStakeholder;
        }
    }

    public void SetTransparencyToAlly(Ally allyToTransparent){
        alliesToTransparent.Add(allyToTransparent);
        setTransparencyToAllies();
    }

    public void setTransparencyToAllies(){
        Image[] images;
        Text[] texts;
        foreach(Ally ally in alliesToTransparent){
            if (ally.Difficulty == 0 && ally is Partner){
                images = alliesImages0;
                texts = alliesText0;
            }else if (ally.Difficulty == 0 && ally is Supplier){
                images = alliesImages1;
                texts = alliesText1;
            }else if (ally.Difficulty == 1  && ally is Partner){
                images = alliesImages2;
                texts = alliesText2;
            }else if (ally.Difficulty == 1  && ally is Supplier){
                images = alliesImages3;
                texts = alliesText3;
            }else if (ally.Difficulty == 2  && ally is Partner){
                images = alliesImages4;
                texts = alliesText4;
            }else if (ally.Difficulty == 2  && ally is Supplier){
                images = alliesImages5;
                texts = alliesText5;
            }else{
                images = alliesImages5;
                texts = alliesText5;
            }
            if(images != null){
                   foreach (Image image in images){
                       Color originalColor = image.color;
                       Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, transparent);
                       image.color = newColor;
                   }
               }
            if(texts != null){
                foreach (Text text in texts){
                    Color originalColor = text.color;
                    Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, transparent);
                    text.color = newColor;
                }
            }
        }
    }
}
}