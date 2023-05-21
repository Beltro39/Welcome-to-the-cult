using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace Lean.Gui{
public class SelectPartnerAndSupplier : MonoBehaviour
{
    [SerializeField] private List<PartnersAndSuppliers>  partnerLevel1;
    [SerializeField] private List<PartnersAndSuppliers>  partnerLevel2;
    [SerializeField] private List<PartnersAndSuppliers>  partnerLevel3;
    [SerializeField] private List<PartnersAndSuppliers>  supplierLevel1;
    [SerializeField] private List<PartnersAndSuppliers>  supplierLevel2;
    [SerializeField] private List<PartnersAndSuppliers>  supplierLevel3;    
    private List<PartnersAndSuppliers>  partnerSupplierArray;

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

    private Player player;
    private Bargain bargain;
    [SerializeField] Button buttonBuyPartnersSuppliers;

    ValidateExchangeResources validateExchangeResources;


    void Start() {
        GameObject UIControllerGO = GameObject.Find("UIController");
        colors = UIControllerGO.GetComponent<Colors>();
        partnerSupplierArray = new List<PartnersAndSuppliers>(); ;
    }

    public bool Run(Player player){
        this.player = player;
        index = 0;
        validateExchangeResources = new ValidateExchangeResources(player);
        DisplayPartnerSupplier(index);
        return true;
    }

    public bool PartnerSupplierRotation(){
        //for (int i = 0; i < 1; i++){
            partnerSupplierArray.Add(GetRandomPartnerOrSupplier(partnerLevel1));
             partnerSupplierArray.Add(GetRandomPartnerOrSupplier(supplierLevel1));
            partnerSupplierArray.Add(GetRandomPartnerOrSupplier(partnerLevel2));
            partnerSupplierArray.Add(GetRandomPartnerOrSupplier(supplierLevel2));
        //}
        partnerSupplierArray.Add(GetRandomPartnerOrSupplier(partnerLevel3));
        partnerSupplierArray.Add(GetRandomPartnerOrSupplier(supplierLevel3));
        return true;
    }

    public PartnersAndSuppliers GetRandomPartnerOrSupplier(List<PartnersAndSuppliers> partnerSupplierArray)
    {
        if (partnerSupplierArray.Count == 0)
        {
            Debug.LogError("No more available objects!");
            return null;
        }

        int randomIndex = Random.Range(0, partnerSupplierArray.Count);
        PartnersAndSuppliers selectedObject = partnerSupplierArray[randomIndex];
        partnerSupplierArray.RemoveAt(randomIndex);
        return selectedObject;
    }
    
    public void btnLeft(){
        index--;
        if(index <0){
            index = partnerSupplierArray.Count -1;
        }
        DisplayPartnerSupplier(index);
        
    }

    public void btnRight(){
        index++;
        if(index == partnerSupplierArray.Count){
            index = 0;
        }
        DisplayPartnerSupplier(index);
    }

    public void Ally(){
        PartnersAndSuppliers partnerSupplier =  partnerSupplierArray[index];
        if(partnerSupplier.StakeHolderType == "PARTNER"){
            player.SetPartner(partnerSupplier);
        }
        else{
            player.SetSupplier(partnerSupplier);
        }
        partnerSupplierArray.RemoveAt(index);
    }

    
    private void DisplayPartnerSupplier(int index)
    {
        TurnOffEverything();

        PartnersAndSuppliers partnerSupplier = partnerSupplierArray[index];

        nameStakeholder.text = partnerSupplier.NameStakeholder;
        difficulty.text = $"{partnerSupplier.StakeHolderType}: LEVEL {partnerSupplier.Difficulty}";
        imageStakeholder.sprite = partnerSupplier.ImageStakeholder;

        bool isPartner = partnerSupplier.StakeHolderType == "PARTNER";
        Image[] resources = isPartner ? resourceGive : resourceGet;
        Image resourcesExtra = isPartner ? resourceGetExtra : resourceGiveExtra ;
        Text[] resourceDescriptions = isPartner ? resourceGiveDescriptions : resourceGetDescriptions;
        Text resourceExtraDescription = isPartner ? resourceGetDescriptionExtra : resourceGiveDescriptionExtra;
        int resourceExtraAmount = isPartner ? partnerSupplier.ResourceAmountsReceivedExtra: partnerSupplier.ResourceAmountsGivenExtra;

        Sprite[] resourcesPartnersAndSuppliers = isPartner ? partnerSupplier.ResourceImagesGiven : partnerSupplier.ResourceImagesReceived ;
        for (int i = 0; i < resourcesPartnersAndSuppliers.Length; i++)
        {
            Sprite resourceSprite = isPartner ? partnerSupplier.ResourceImagesGiven[i] : partnerSupplier.ResourceImagesReceived[i];
            string resourceType = isPartner ? partnerSupplier.ResourceTypesGiven[i] : partnerSupplier.ResourceTypesReceived[i];
            int resourceAmount = isPartner ? partnerSupplier.ResourceAmountsGiven[i] : partnerSupplier.ResourceAmountsReceived[i];

            Color color;
            if (typesEmployees.Contains(resourceType)){
                color = colors.naranja;
            }
            else if(typesTechnologies.Contains(resourceType)){
                color = colors.azul;
            }else{
                color = colors.morado;
            }

            if (resourceSprite != null && !string.IsNullOrEmpty(resourceType) && resourceAmount > 0)
            {
                resources[i].enabled = true;
                resources[i].sprite = resourceSprite;
                resourceDescriptions[i].enabled = true;
                resourceDescriptions[i].text = $"{resourceType}\n{resourceAmount}";
                resourceDescriptions[i].color = color;
            }
        }

        resourceExtraDescription.enabled = true;
        resourceExtraDescription.text = $"ITILIANOS ${resourceExtraAmount}";
        resourcesExtra.enabled = true;

        SetStars(partnerSupplier.Difficulty);
        if(validatePartnerSupplierIsAvailable(player, partnerSupplier)){
            buttonBuyPartnersSuppliers.interactable = true;
        }else{
            buttonBuyPartnersSuppliers.interactable = false;
        }
    }

    public void SetStars(int difficulty){

        if(difficulty == 1){
            starsImage[0].enabled = true;
            starsImage[1].enabled = false;
            starsImage[2].enabled = false;
        }else if(difficulty == 2){
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

    private bool validatePartnerSupplierIsAvailable(Player player, PartnersAndSuppliers partnerSupplier){
        int level = partnerSupplier.Difficulty;
        bargain= player.getListAbilities().getBargain();
        if(bargain.getAmount() +1 >= level){
            bool[] boolArray;
            string[] requirementList;
            int[] amountList;
            if(partnerSupplier.StakeHolderType == "PARTNER"){
                boolArray = new bool[partnerSupplier.ResourceTypesGiven.Length];
                requirementList = partnerSupplier.ResourceTypesGiven;
                amountList = partnerSupplier.ResourceAmountsGiven;
                for (int i = 0; i < requirementList.Length; i++)
                {
                    boolArray[i] =  validateExchangeResources.ValidatePlayerHasResources(
                        requirementList[i], amountList[i]
                    );
                }
                bool allTrue = boolArray.All(value => value);
                return allTrue ? true : false;
            }else{
                return validateExchangeResources.ValidatePlayerHasResources(
                    "ITILIANOS", partnerSupplier.ResourceAmountsGivenExtra
                );
            }
        }
        return false;
    }

    
    
}
}