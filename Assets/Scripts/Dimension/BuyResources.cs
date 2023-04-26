using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;



namespace Lean.Gui{
    public class BuyResources : MonoBehaviour
    {
        [SerializeField] private Text JuniorsTextAvailable;
        [SerializeField] private Text SemiSeniorsTextAvailable;
        [SerializeField] private Text SeniorsTextAvailable;
        [SerializeField] private Text ArchitectsTextAvailable;
        [SerializeField] private Text ServersTextAvailable;
        [SerializeField] private Text SatellitesTextAvailable;
        [SerializeField] private Text IATextAvailable;
        [SerializeField] private Text HostingTextAvailable;
        [SerializeField] private Text RecruitmentTextAvailable;
        [SerializeField] private Text SkillfulTextAvailable;
        [SerializeField] private Text BargainTextAvailable;
        [SerializeField] private Text ResearchTextAvailable; 

        [SerializeField] private Text JuniorsLevelsToBuy;
        [SerializeField] private Text SemiSeniorsLevelsToBuy;
        [SerializeField] private Text SeniorsLevelsToBuy;
        [SerializeField] private Text ArchitectsLevelsToBuy;
        [SerializeField] private Text ServersLevelsToBuy;
        [SerializeField] private Text SatellitesLevelsToBuy;
        [SerializeField] private Text IALevelsToBuy;
        [SerializeField] private Text HostingLevelsToBuy;
        [SerializeField] private Text RecruitmentLevelsToBuy;
        [SerializeField] private Text SkillfulLevelsToBuy;
        [SerializeField] private Text BargainLevelsToBuy;
        [SerializeField] private Text ResearchLevelsToBuy;

        [SerializeField] private Text JuniorsSubTotal;
        [SerializeField] private Text SemiSeniorsSubTotal;
        [SerializeField] private Text SeniorsSubTotal;
        [SerializeField] private Text ArchitectsSubTotal;
        [SerializeField] private Text ServersSubtotal;
        [SerializeField] private Text SatellitesSubtotal;
        [SerializeField] private Text IASubtotal;
        [SerializeField] private Text HostingSubtotal;
        [SerializeField] private Text RecruitmentSubTotal;
        [SerializeField] private Text SkillfulSubTotal;
        [SerializeField] private Text BargainSubTotal;
        [SerializeField] private Text ResearchSubTotal;


        [SerializeField] private Text JuniorsPrice;
        [SerializeField] private Text SemiSeniorsPrice;
        [SerializeField] private Text SeniorsPrice;
        [SerializeField] private Text ArchitectsPrice;
        [SerializeField] private Text ServersPrice;
        [SerializeField] private Text SatellitesPrice;
        [SerializeField] private Text IAPrice;
        [SerializeField] private Text HostingPrice;
        [SerializeField] private Text RecruitmentPrice;
        [SerializeField] private Text SkillfulPrice;
        [SerializeField] private Text BargainPrice;
        [SerializeField] private Text ResearchPrice;

        [SerializeField] private Text EmployeesTotal;
        [SerializeField] private Text TechnologiesTotal;
        [SerializeField] private Text AbilitiesTotal;

        private Player player;
    
        private Itilianos Itilianos;
        private Juniors Juniors;
        private SemiSeniors SemiSeniors;
        private Seniors Seniors;
        private Architects Architects;
        private Servers Servers;
        private Satellites Satellites;
        private IA IA;
        private Hosting Hosting;
        private Recruitment Recruitment;
        private Skillful Skillful;
        private Bargain Bargain;
        private Research Research;

        private int InitialJuniors;
        private int InitialSemiSeniors;
        private int InitialSeniors;
        private int InitialArchitects;
        private int InitialServers;
        private int InitialSatellites;
        private int InitialIA;
        private int InitialHosting;
        private int InitialRecruitment;
        private int InitialSkillful;
        private int InitialBargain;
        private int InitialResearch;

        private int SubTotalJuniors;
        private int SubTotalSemiSeniors;
        private int SubTotalSeniors;
        private int SubTotalArchitects;
        private int SubTotalServers;
        private int SubTotalSatellites;
        private int SubTotalIA;
        private int SubTotalHosting;
        private int SubTotalRecruitment;
        private int SubTotalSkillful;
        private int SubTotalBargain;
        private int SubTotalResearch;

        private int TotalEmployeesCost;
        private int TotalTechnologiesCost;
        private int TotalAbilitiesCost;

        DisableButtons DisableButtons;

        private Market market;
        private Dictionary<string, Dictionary<string, Text>> diccionarioText;
        private Dictionary<string, Resources> diccionarioResources;
        private Dictionary<string, int> dictResourcesQuantityToBuy; 


        string[] typesEmployees = { "Juniors", "SemiSeniors", "Seniors", "Architects"};
        string[] typesTechnologies = { "Servers", "Satellites", "IA", "Hosting"};
        string[] typesAbilities = { "Recruitment", "Skillful", "Bargain", "Research"};

        public void Start(){
            GameObject UIControllerGO = GameObject.Find("UIController");
            DisableButtons= UIControllerGO.GetComponent<DisableButtons>();
        }

        public void ReturnMarketsToOriginal(){
            market.ResetToOriginalValues();
        }

        public bool Run(Player player){
            this.player = player;

            TotalEmployeesCost = 0;
            TotalTechnologiesCost= 0;
            TotalAbilitiesCost = 0;

            EmployeesTotal.text= "$"+TotalEmployeesCost.ToString();
            TechnologiesTotal.text= "$"+TotalTechnologiesCost.ToString();
            AbilitiesTotal.text= "$"+TotalAbilitiesCost.ToString();

            this.player= player;
            Itilianos= player.getItilianos();
            Juniors= player.getListEmployees().getJuniors();
            SemiSeniors= player.getListEmployees().getSemiSeniors();
            Seniors= player.getListEmployees().getSeniors();
            Architects= player.getListEmployees().getArchitects();
            Servers= player.getListTechnologies().getServers();
            Satellites= player.getListTechnologies().getSatellites();
            IA= player.getListTechnologies().getIA();
            Hosting= player.getListTechnologies().getHosting(); 
            Recruitment= player.getListAbilities().getRecruitment();
            Skillful= player.getListAbilities().getSkillful();
            Bargain= player.getListAbilities().getBargain();
            Research= player.getListAbilities().getResearch();

            diccionarioText = new Dictionary<string, Dictionary<string, Text>>
            {
                { "Juniors", new Dictionary<string, Text> { { "TextAvailable", JuniorsTextAvailable }, {"LevelsToBuy", JuniorsLevelsToBuy}, {"SubTotal", JuniorsSubTotal}, {"Price", JuniorsPrice}} },
                { "SemiSeniors", new Dictionary<string, Text> { { "TextAvailable", SemiSeniorsTextAvailable }, { "LevelsToBuy", SemiSeniorsLevelsToBuy}, {"SubTotal", SemiSeniorsSubTotal}, {"Price", SemiSeniorsPrice}} },
                { "Seniors", new Dictionary<string, Text> { { "TextAvailable", SeniorsTextAvailable }, { "LevelsToBuy", SeniorsLevelsToBuy}, {"SubTotal", SeniorsSubTotal}, {"Price", SeniorsPrice}} },
                { "Architects", new Dictionary<string, Text> { { "TextAvailable", ArchitectsTextAvailable }, { "LevelsToBuy", ArchitectsLevelsToBuy}, {"SubTotal", ArchitectsSubTotal}, {"Price", ArchitectsPrice}} },
                { "Servers", new Dictionary<string, Text> { { "TextAvailable", ServersTextAvailable }, { "LevelsToBuy", ServersLevelsToBuy}, {"SubTotal", ServersSubtotal}, {"Price", ServersPrice}} },
                { "Satellites", new Dictionary<string, Text> { { "TextAvailable", SatellitesTextAvailable }, { "LevelsToBuy", SatellitesLevelsToBuy}, {"SubTotal", SatellitesSubtotal}, {"Price", SatellitesPrice}} },
                { "IA", new Dictionary<string, Text> { { "TextAvailable", IATextAvailable }, { "LevelsToBuy", IALevelsToBuy}, {"SubTotal", IASubtotal}, {"Price", IAPrice} } },
                { "Hosting", new Dictionary<string, Text> { { "TextAvailable", HostingTextAvailable }, { "LevelsToBuy", HostingLevelsToBuy}, {"SubTotal", HostingSubtotal}, {"Price", HostingPrice} } },
                { "Recruitment", new Dictionary<string, Text> { { "TextAvailable", RecruitmentTextAvailable }, { "LevelsToBuy", RecruitmentLevelsToBuy}, {"SubTotal", RecruitmentSubTotal}, {"Price", RecruitmentPrice} } },
                { "Skillful", new Dictionary<string, Text> { { "TextAvailable", SkillfulTextAvailable }, { "LevelsToBuy", SkillfulLevelsToBuy}, {"SubTotal", SkillfulSubTotal}, {"Price", SkillfulPrice} } },
                { "Bargain", new Dictionary<string, Text> { { "TextAvailable", BargainTextAvailable }, { "LevelsToBuy", BargainLevelsToBuy}, {"SubTotal", BargainSubTotal}, {"Price", BargainPrice} } },
                { "Research", new Dictionary<string, Text> { { "TextAvailable", ResearchTextAvailable }, { "LevelsToBuy", ResearchLevelsToBuy}, {"SubTotal", ResearchSubTotal}, {"Price", ResearchPrice} } }
            };

            diccionarioResources = new Dictionary<string, Resources>{
                { "Juniors",  Juniors},
                { "SemiSeniors",  SemiSeniors},
                { "Seniors", Seniors},
                { "Architects", Architects},
                { "Servers", Servers},
                { "Satellites", Satellites},
                { "IA", IA},
                { "Hosting", Hosting},
                { "Recruitment",  Recruitment},
                { "Skillful", Skillful},
                { "Bargain", Bargain},
                { "Research",  Research}
           };

           dictResourcesQuantityToBuy = new Dictionary<string, int>{
                { "Juniors",  0},
                { "SemiSeniors",  0},
                { "Seniors", 0},
                { "Architects", 0},
                { "Servers", 0},
                { "Satellites", 0},
                { "IA", 0},
                { "Hosting", 0},
                { "Recruitment",  0},
                { "Skillful", 0},
                { "Bargain", 0},
                { "Research",  0}
           };
            

            market = new Market();
            
            foreach (KeyValuePair<string, Dictionary<string, Text>> outerPair in diccionarioText)
            {
                int resourceQuantity = diccionarioResources[outerPair.Key].getAmount() + dictResourcesQuantityToBuy[outerPair.Key];
                if (typesEmployees.Contains(outerPair.Key)){
                     diccionarioText[outerPair.Key]["TextAvailable"].text = market.getResourceAvailabilityCopy(outerPair.Key).ToString() + " APPLICANTS";
                     diccionarioText[outerPair.Key]["LevelsToBuy"].text = resourceQuantity.ToString();
                    diccionarioText[outerPair.Key]["Price"].text = "$"+market.getResourcesCost(outerPair.Key, player).ToString();
                }
                if (typesTechnologies.Contains(outerPair.Key) || typesAbilities.Contains(outerPair.Key)){
                     diccionarioText[outerPair.Key]["TextAvailable"].text = market.getResourceAvailabilityCopy(outerPair.Key).ToString() + " LEVELS";
                     diccionarioText[outerPair.Key]["LevelsToBuy"].text = "LEVEL "+resourceQuantity.ToString();
                }

                
            }   
            DisableUIButtons();
            return true;
        }

        public void updateResource(string resourceAndOperation){
            string[] splitted = resourceAndOperation.Split('_');
            string resource = splitted[0];
            string operation = splitted[1];  
            string units = "";
            string units2 = "";
            if (typesEmployees.Contains(resource)){
                units = " APPLICANTS";
                units2= "";
            }else{
                units = " LEVELS";
                units2= "LEVEL ";
            }
            int totalBuy = TotalEmployeesCost + TotalTechnologiesCost +TotalAbilitiesCost;
            int cost = market.getResourcesCost(resource, player);
            if(operation=="remove"){
                if(totalBuy+cost>Itilianos.getAmount()){
                    return;
                }
                market.addResource(resource);
                if(typesEmployees.Contains(resource)){
                    TotalEmployeesCost += cost;
                    EmployeesTotal.text= "$"+TotalEmployeesCost.ToString();
                }else if(typesTechnologies.Contains(resource)){
                    TotalTechnologiesCost += cost;
                    TechnologiesTotal.text= "$"+TotalTechnologiesCost.ToString();
                }else if(typesAbilities.Contains(resource)){
                    TotalAbilitiesCost += cost;
                    AbilitiesTotal.text= "$"+TotalAbilitiesCost.ToString();
                }
                dictResourcesQuantityToBuy[resource] += 1;
            }
            else if(operation == "add"){
                if(dictResourcesQuantityToBuy[resource] == 0){
                    return;
                }
                market.removeResource(resource);
                if(typesEmployees.Contains(resource)){
                    TotalEmployeesCost -= cost;
                    EmployeesTotal.text = "$"+TotalEmployeesCost.ToString();
                }else if(typesTechnologies.Contains(resource)){
                    TotalTechnologiesCost -= cost;
                    TechnologiesTotal.text = "$"+TotalTechnologiesCost.ToString();
                }else if(typesAbilities.Contains(resource)){
                    TotalAbilitiesCost -= cost;
                    AbilitiesTotal.text = "$"+TotalAbilitiesCost.ToString();
                }
                dictResourcesQuantityToBuy[resource] -= 1;
            }
            int resourceQuantity = diccionarioResources[resource].getAmount() + dictResourcesQuantityToBuy[resource];
            diccionarioText[resource]["TextAvailable"].text = market.getResourceAvailabilityCopy(resource).ToString() + units;
            diccionarioText[resource]["LevelsToBuy"].text = units2+resourceQuantity.ToString();
            DisableUIButtons();
        }
    
        public void DisableUIButtons(){

            if(TotalEmployeesCost > Itilianos.getAmount()){ 
                DisableButtons.BuyEmployeesDimensionDisabled();
            }else{
                DisableButtons.BuyEmployeesDimensionEnabled();
            }
            if(TotalTechnologiesCost > Itilianos.getAmount()){
                DisableButtons.BuyTechnologiesDimensionDisabled();
            }else{
                DisableButtons.BuyTechnologiesDimensionEnabled();
            }
            if(TotalAbilitiesCost > Itilianos.getAmount()){
                DisableButtons.BuyAbilitiesDimensionDisabled();
            }else{
                DisableButtons.BuyAbilitiesDimensionEnabled();
            }

        

            if(TotalEmployeesCost+TotalTechnologiesCost+TotalAbilitiesCost == 0){
                DisableButtons.BuyEmployeesDimensionDisabled();
                DisableButtons.BuyTechnologiesDimensionDisabled();
                DisableButtons.BuyAbilitiesDimensionDisabled();
                
                DisableButtons.SkipEmployeesDimensionEnabled();
                DisableButtons.SkipTechnologiesDimensionEnabled();
                DisableButtons.SkipAbilitiesDimensionEnabled();

            }else{
                DisableButtons.SkipEmployeesDimensionDisabled();
                DisableButtons.SkipTechnologiesDimensionDisabled();
                DisableButtons.SkipPartnersSuppliersDimensionEnabled();
                DisableButtons.SkipAbilitiesDimensionDisabled();

            }

            Debug.Log(TotalAbilitiesCost);

        }

        public void Buy(){
            foreach (KeyValuePair<string, int> item in dictResourcesQuantityToBuy)
            {
                string resource = item.Key;
                int quantity = item.Value;
                if(quantity > 0){
                    Itilianos.RemoveAmount(quantity * market.getResourcesCost(resource, player));
                    diccionarioResources[resource].AddAmount(quantity);
                }
            }

        }
        
    }
    
}