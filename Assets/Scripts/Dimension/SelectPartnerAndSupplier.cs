using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Lean.Gui{
public class SelectPartnerAndSupplier : MonoBehaviour
{
    [SerializeField] private List<Ally>  partnerLevel1;
    [SerializeField] private List<Ally>  partnerLevel2;
    [SerializeField] private List<Ally>  partnerLevel3;
    [SerializeField] private List<Ally>  supplierLevel1;
    [SerializeField] private List<Ally>  supplierLevel2;
    [SerializeField] private List<Ally>  supplierLevel3;    
    private List<Ally>  allies;

    [SerializeField] private Text nameStakeholder;
    [SerializeField] private Text difficulty;
    [SerializeField] private Image imageStakeholder;

    [SerializeField] private Image[] resourceGive = new Image[4];
    [SerializeField] private Image[] resourceGet = new Image[4];

    [SerializeField] private Image resourceGiveExtra;
    [SerializeField] private Image resourceGetExtra;
    
    [SerializeField] private Text[] resourceGiveDescriptions = new Text[4];
    [SerializeField] private Text[] resourceGetDescriptions = new Text[4];

    [SerializeField] private Text resourceGetDescriptionExtra;
    [SerializeField] private Text resourceGiveDescriptionExtra;

    [SerializeField] private Image[] starsImage = new Image[3];

    string[] typesEmployees = { "JUNIOR", "SEMI SENIOR", "SENIOR", "ARCHITECT"};
    string[] typesTechnologies = { "SERVER", "SATELLITE", "IA", "HOSTING"};
    string[] typesAbilities = { "EMPLOYEE RECRUITMENT", "SKILLFUL IN TECHCNOLOGY", "BARGANING POWER", "RESEARCH AND PROJECTS"};
    
    private List<Text> listText;

    int index;

    Colors colors;
    DisableBoardItems disableBoardItemsComponent;

    private Player player;
    private Bargain bargain;
    [SerializeField] Button buttonBuyPartnersSuppliers;

    ValidateExchangeResources validateExchangeResources;


    void Start() {
        GameObject UIControllerGO = GameObject.Find("UIController");
        colors = UIControllerGO.GetComponent<Colors>();
        disableBoardItemsComponent = UIControllerGO.GetComponent<DisableBoardItems>();
        allies = new List<Ally>(); ;
    }

    public bool Run(Player player){
        this.player = player;
        index = 0;
        validateExchangeResources = new ValidateExchangeResources(player);
        DisplayPartnerSupplier(index);
        return true;
    }

    public bool PartnerSupplierRotation(){
        if(partnerLevel1.Count >0){
            allies.Add(GetRandomAlly(partnerLevel1));
        }
        if(supplierLevel1.Count >0){
            allies.Add(GetRandomAlly(supplierLevel1));
        }
        if(partnerLevel2.Count >0){
            allies.Add(GetRandomAlly(partnerLevel2));
        }
        if(supplierLevel2.Count >0){
            allies.Add(GetRandomAlly(supplierLevel2));
        }
        if(partnerLevel3.Count >0){
            allies.Add(GetRandomAlly(partnerLevel3));
        }
        if(supplierLevel3.Count >0){
            allies.Add(GetRandomAlly(supplierLevel3));
        }
        disableBoardItemsComponent.SetAlliesInBoard(allies);
        return true;
    }

    public Ally GetRandomAlly(List<Ally> allies)
    {
        if (allies.Count == 0)
        {
            Debug.LogError("No more available objects!");
            return null;
        }

        int randomIndex = Random.Range(0, allies.Count);
        Ally selectedObject = allies[randomIndex];
        allies.RemoveAt(randomIndex);
        return selectedObject;
    }
    
    public void btnLeft(){
        index--;
        if(index <0){
            index = allies.Count -1;
        }
        DisplayPartnerSupplier(index);
        
    }

    public void btnRight(){
        index++;
        if(index == allies.Count){
            index = 0;
        }
        DisplayPartnerSupplier(index);
    }

    public void Alliance(){
        Ally ally =  allies[index];
        if(ally is Partner){
            Partner partner = (Partner) ally; 
            player.SetPartner(partner);
            string[] requirementList = partner.ResourceTypesGiven;
            int[] amountList = partner.ResourceAmountsGiven;
            for (int i = 0; i < requirementList.Length; i++)
            {
                validateExchangeResources.TakeResourcesFromPlayer(
                    requirementList[i], amountList[i]
                );
            }
            validateExchangeResources.GiveResourcesToPlayer("ITILIANOS", partner.ResourceAmountsReceivedExtra);
        }
        else{
            Supplier supplier = (Supplier) ally;
            player.SetSupplier(supplier);
            string[] requirementList = supplier.ResourceTypesReceived;
            int[] amountList = supplier.ResourceAmountsReceived;
            for (int i = 0; i < requirementList.Length; i++)
            {
                validateExchangeResources.GiveResourcesToPlayer(
                    requirementList[i], amountList[i]
                );
            }
            validateExchangeResources.TakeResourcesFromPlayer("ITILIANOS", supplier.ResourceAmountsGivenExtra);

        }
        disableBoardItemsComponent.SetTransparencyToAlly(ally);
        allies.RemoveAt(index);
    }

    
    private void DisplayPartnerSupplier(int index)
    {
        TurnOffEverything();

        Ally ally = allies[index];

        nameStakeholder.text = ally.NameStakeholder;
        imageStakeholder.sprite = ally.ImageStakeholder;

        // UI elements
        bool isPartner = ally is Partner;
        Image[] resources = isPartner ? resourceGive : resourceGet;
        Text[] resourcesDescriptions = isPartner ? resourceGiveDescriptions : resourceGetDescriptions;
        Image resourceExtra = isPartner ? resourceGetExtra : resourceGiveExtra ;
        Text resourceExtraDescription = isPartner ? resourceGetDescriptionExtra : resourceGiveDescriptionExtra;
        
        // Atributes
        int resourceExtraAmount;
        Sprite[] resourcesSprite;
        string[] resourcesType;
        int[] resourcesAmount;

        if(isPartner){
            Partner partner = (Partner) ally;
            resourcesSprite = partner.ResourceImagesGiven;
            resourcesType = partner.ResourceTypesGiven;
            resourcesAmount = partner.ResourceAmountsGiven;
            resourceExtraAmount = partner.ResourceAmountsReceivedExtra;
            difficulty.text = $"PARTNER LEVEL {ally.Difficulty+1}";
        }else{
            Supplier supplier = (Supplier) ally;
            resourcesSprite = supplier.ResourceImagesReceived;
            resourcesType = supplier.ResourceTypesReceived;
            resourcesAmount = supplier.ResourceAmountsReceived;
            resourceExtraAmount = supplier.ResourceAmountsGivenExtra;
            difficulty.text = $"SUPPLIER LEVEL {ally.Difficulty+1}";
        }
        
        for (int i = 0; i < resourcesType.Length; i++)
        {
            Color color;
            if (typesEmployees.Contains(resourcesType[i])){
                color = colors.naranja;
            }
            else if(typesTechnologies.Contains(resourcesType[i])){
                color = colors.azul;
            }else{
                color = colors.morado;
            }

            if (resourcesSprite[i] != null && !string.IsNullOrEmpty(resourcesType[i]) && resourcesAmount[i] > 0)
            {
                resources[i].enabled = true;
                resources[i].sprite = resourcesSprite[i];
                resourcesDescriptions[i].enabled = true;
                resourcesDescriptions[i].text = $"{resourcesType[i]}\n{resourcesAmount[i]}";
                resourcesDescriptions[i].color = color;
            }
        }

        resourceExtraDescription.enabled = true;
        resourceExtraDescription.text = $"ITILIANOS ${resourceExtraAmount}";
        resourceExtra.enabled = true;

        SetStars(ally.Difficulty);
        if(validateAllyIsAvailable(player, ally)){
            buttonBuyPartnersSuppliers.interactable = true;
        }else{
            buttonBuyPartnersSuppliers.interactable = false;
        }
    }

    public void SetStars(int difficulty){

        if(difficulty == 0){
            starsImage[0].enabled = true;
            starsImage[1].enabled = false;
            starsImage[2].enabled = false;
        }else if(difficulty == 1){
            starsImage[0].enabled = false;
            starsImage[1].enabled = true;
            starsImage[2].enabled = true;
        }else{
            starsImage[0].enabled = true;
            starsImage[1].enabled = true;
            starsImage[2].enabled = true;
        }

    }

    private void TurnOffEverything()
    {
        foreach (Image resource in resourceGive.Concat(resourceGet).Append(resourceGiveExtra).Append(resourceGetExtra))
        {
            resource.enabled = false;
        }

        foreach (Text description in resourceGiveDescriptions.Concat(resourceGetDescriptions).Append(resourceGiveDescriptionExtra).Append(resourceGetDescriptionExtra))
        {
            description.enabled = false;
        }
    }

    private bool validateAllyIsAvailable(Player player, Ally ally){
        int level = ally.Difficulty;
        bargain = player.getListAbilities().getBargain();
        if(bargain.getAmount() >= level){
            bool[] boolArray;
            string[] requirementList;
            int[] amountList;
            if(ally is Partner){
                Partner partner = (Partner)ally;
                boolArray = new bool[partner.ResourceTypesGiven.Length];
                requirementList = partner.ResourceTypesGiven;
                amountList = partner.ResourceAmountsGiven;
                for (int i = 0; i < requirementList.Length; i++)
                {
                    boolArray[i] =  validateExchangeResources.ValidatePlayerHasResources(
                        requirementList[i], amountList[i]
                    );
                }
                bool allTrue = boolArray.All(value => value);
                return allTrue ? true : false;
            }else{
                Supplier supplier = (Supplier) ally;
                return validateExchangeResources.ValidatePlayerHasResources(
                    "ITILIANOS", supplier.ResourceAmountsGivenExtra
                );
            }
        }
        return false;
    }

    
    
}
}