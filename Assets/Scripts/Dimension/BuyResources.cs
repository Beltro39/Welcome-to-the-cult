using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Lean.Gui{
    public class BuyResources : MonoBehaviour
    {
        [SerializeField] GameObject UIControllerGO;
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

        public void Start(){
            DisableButtons= UIControllerGO.GetComponent<DisableButtons>();
        }

        public void Begin(Player player){
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


            JuniorsTextAvailable.text = Juniors.getLimitResourcePerRound().ToString()+ " APPLICANTS";
            SemiSeniorsTextAvailable.text = SemiSeniors.getLimitResourcePerRound().ToString()+ " APPLICANTS";
            SeniorsTextAvailable.text = Seniors.getLimitResourcePerRound().ToString()+ " APPLICANTS";
            ArchitectsTextAvailable.text = Architects.getLimitResourcePerRound().ToString()+ " APPLICANTS";
            ServersTextAvailable.text = Servers.getLimitResourcePerRound().ToString()+ " LEVELS";
            SatellitesTextAvailable.text = Satellites.getLimitResourcePerRound().ToString()+ " LEVELS";
            IATextAvailable.text = IA.getLimitResourcePerRound().ToString()+ " LEVELS";
            HostingTextAvailable.text = Hosting.getLimitResourcePerRound().ToString()+ " LEVELS";
            RecruitmentTextAvailable.text = Recruitment.getLimitResourcePerRound().ToString()+ " LEVELS";
            SkillfulTextAvailable.text = Skillful.getLimitResourcePerRound().ToString()+ " LEVELS";
            BargainTextAvailable.text = Bargain.getLimitResourcePerRound().ToString()+ " LEVELS";
            ResearchTextAvailable.text = Research.getLimitResourcePerRound().ToString()+ " LEVELS";

            JuniorsLevelsToBuy.text = Juniors.getAmount().ToString();
            SemiSeniorsLevelsToBuy.text = SemiSeniors.getAmount().ToString();
            SeniorsLevelsToBuy.text = Seniors.getAmount().ToString();
            ArchitectsLevelsToBuy.text = Architects.getAmount().ToString();
            ServersLevelsToBuy.text= "LEVEL "+Servers.getAmount().ToString();
            SatellitesLevelsToBuy.text = "LEVEL "+ Satellites.getAmount().ToString();
            IALevelsToBuy.text = "LEVEL "+ IA.getAmount().ToString();
            HostingLevelsToBuy.text = "LEVEL "+ Hosting.getAmount().ToString();
            RecruitmentLevelsToBuy.text ="LEVEL "+ Recruitment.getAmount().ToString();
            SkillfulLevelsToBuy.text = "LEVEL "+Skillful.getAmount().ToString();
            BargainLevelsToBuy.text = "LEVEL "+Bargain.getAmount().ToString();
            ResearchLevelsToBuy.text = "LEVEL "+Research.getAmount().ToString();

            InitialJuniors= Juniors.getAmount();
            InitialSemiSeniors= SemiSeniors.getAmount();
            InitialSeniors= Seniors.getAmount();
            InitialArchitects= Architects.getAmount();
            InitialServers= Servers.getAmount();
            InitialSatellites= Satellites.getAmount();
            InitialIA= IA.getAmount();
            InitialHosting= Hosting.getAmount();
            InitialRecruitment= Recruitment.getAmount();
            InitialSkillful= Skillful.getAmount();
            InitialBargain= Bargain.getAmount();
            InitialResearch= Research.getAmount();
        }

        public void updateResource(string resourceAndOperation){
            string[] splitted = resourceAndOperation.Split('_');
            string resource = splitted[0];
            string operation = splitted[1];  
            if(resource =="Servers"){
                SubTotalServers = buyTechnologies(operation, Servers, ServersTextAvailable, ServersLevelsToBuy, ServersSubtotal, SubTotalServers,InitialServers);
            }
            if(resource =="Satellites"){
                SubTotalSatellites = buyTechnologies(operation, Satellites, SatellitesTextAvailable,SatellitesLevelsToBuy, SatellitesSubtotal, SubTotalSatellites, InitialSatellites);
            }
            if(resource =="IA"){
                SubTotalIA= buyTechnologies(operation, IA, IATextAvailable, IALevelsToBuy, IASubtotal, SubTotalIA, InitialIA);
            }
            if(resource =="Hosting"){
                SubTotalHosting = buyTechnologies(operation,Hosting, HostingTextAvailable, HostingLevelsToBuy, HostingSubtotal, SubTotalHosting, InitialHosting);
            }
            if(resource =="Juniors"){
                SubTotalJuniors = buyEmployees(operation, Juniors, JuniorsTextAvailable, JuniorsLevelsToBuy, JuniorsSubTotal, SubTotalJuniors,InitialJuniors);
            }
            if(resource =="SemiSeniors"){
                SubTotalSemiSeniors = buyEmployees(operation, SemiSeniors, SemiSeniorsTextAvailable, SemiSeniorsLevelsToBuy, SemiSeniorsSubTotal, SubTotalSemiSeniors,InitialSemiSeniors);
            }
            if(resource =="Seniors"){
                SubTotalSeniors = buyEmployees(operation, Seniors, SeniorsTextAvailable, SeniorsLevelsToBuy, SeniorsSubTotal, SubTotalSeniors,InitialSeniors);
            }
             if(resource =="Architects"){
                SubTotalArchitects = buyEmployees(operation, Architects, ArchitectsTextAvailable, ArchitectsLevelsToBuy, ArchitectsSubTotal, SubTotalArchitects,InitialArchitects);
            }
            if(resource =="Recruitment"){
                SubTotalRecruitment = buyAbilities(operation, Recruitment, RecruitmentTextAvailable, RecruitmentLevelsToBuy, RecruitmentSubTotal, SubTotalRecruitment,InitialRecruitment);
            }
            if(resource =="Skillful"){
                SubTotalSkillful = buyAbilities(operation, Skillful, SkillfulTextAvailable, SkillfulLevelsToBuy, SkillfulSubTotal, SubTotalSkillful,InitialSkillful);
            }
            if(resource =="Bargain"){
                SubTotalBargain = buyAbilities(operation, Bargain, BargainTextAvailable, BargainLevelsToBuy, BargainSubTotal, SubTotalBargain,InitialBargain);
            }
            if(resource =="Research"){
                SubTotalResearch = buyAbilities(operation, Research, ResearchTextAvailable, ResearchLevelsToBuy, ResearchSubTotal, SubTotalResearch,InitialResearch);
            }

            LookingWhatHaveBeenBuying();

        }

        public void LookingWhatHaveBeenBuying(){
            TotalEmployeesCost= SubTotalJuniors+SubTotalSemiSeniors+SubTotalSeniors+SubTotalArchitects;
            TotalTechnologiesCost= SubTotalServers+SubTotalSatellites+SubTotalIA+SubTotalHosting;
            TotalAbilitiesCost= SubTotalRecruitment+SubTotalSkillful+SubTotalBargain+SubTotalResearch;

            EmployeesTotal.text= "$"+TotalEmployeesCost.ToString();
            TechnologiesTotal.text= "$"+TotalTechnologiesCost.ToString();
            AbilitiesTotal.text= "$"+TotalAbilitiesCost.ToString();

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
        }

        public int buyTechnologies(string operation, Technologies Technologies, Text TechnologiesTextAvailable, Text TechnologiesLevelsToBuy, 
            Text TechnologiesSubtotal, int SubTotalTechnologies, int InitialTechnologies){
            if(operation== "remove"){
                if(Technologies.getLimitResourcePerRound()> 0 && Technologies.getAmount() < Technologies.getLimit()){
                    Technologies.RemoveLimitResourcePerRound(1); 
                    Technologies.AddAmount(1);
                    SubTotalTechnologies+= Technologies.getCostUpdated();
                }
            }
            if(operation == "add"){
                if(Technologies.getLimitResourcePerRound() < Technologies.getOriginalLimitResourcePerRound() && Technologies.getAmount() >= InitialTechnologies){
                    SubTotalTechnologies-= Technologies.getCostUpdated();
                    Technologies.AddLimitResourcePerRound(1);
                    Technologies.RemoveAmount(1);
                }     
            }
            TechnologiesTextAvailable.text = Technologies.getLimitResourcePerRound().ToString()+ " LEVELS";
            TechnologiesLevelsToBuy.text= "LEVEL "+Technologies.getAmount().ToString(); 
            TechnologiesSubtotal.text = "$"+SubTotalTechnologies.ToString();
            return SubTotalTechnologies;
        }

        public int buyEmployees(string operation, Employees Employees, Text EmployeesTextAvailable, Text EmployeesLevelsToBuy, 
            Text EmployeesSubtotal, int SubTotalEmployees, int InitialEmployees){
            if(operation== "remove"){
                if(Employees.getLimitResourcePerRound()> 0 && Employees.getAmount() < Employees.getLimit()){
                    Employees.RemoveLimitResourcePerRound(1); 
                    Employees.AddAmount(1);
                    SubTotalEmployees+= Employees.getCostUpdated();
                }
            }
            if(operation == "add"){
                if(Employees.getLimitResourcePerRound() < Employees.getOriginalLimitResourcePerRound() && Employees.getAmount() >= InitialEmployees){
                    SubTotalEmployees-= Employees.getCostUpdated();
                    Employees.AddLimitResourcePerRound(1);
                    Employees.RemoveAmount(1);
                }     
            }
            EmployeesTextAvailable.text = Employees.getLimitResourcePerRound().ToString()+ " APPLICANTS";
            EmployeesLevelsToBuy.text= Employees.getAmount().ToString(); 
            EmployeesSubtotal.text = "$"+SubTotalEmployees.ToString();
            return SubTotalEmployees;
        }

        public int buyAbilities(string operation, Abilities Abilities, Text AbilitiesTextAvailable, Text AbilitiesLevelsToBuy, 
            Text AbilitiesSubtotal, int SubTotalAbilities, int InitialAbilities){
            if(operation== "remove"){
                if(Abilities.getLimitResourcePerRound()> 0 && Abilities.getAmount() < Abilities.getLimit()){
                    Abilities.RemoveLimitResourcePerRound(1); 
                    Abilities.AddAmount(1);
                    SubTotalAbilities+= Abilities.getCostUpdated();
                }
            }
            if(operation == "add"){
                if(Abilities.getLimitResourcePerRound() < Abilities.getOriginalLimitResourcePerRound() && Abilities.getAmount() >= InitialAbilities){
                    SubTotalAbilities-= Abilities.getCostUpdated();
                    Abilities.AddLimitResourcePerRound(1);
                    Abilities.RemoveAmount(1);
                }     
            }
            AbilitiesTextAvailable.text = Abilities.getLimitResourcePerRound().ToString()+ " LEVELS";
            AbilitiesLevelsToBuy.text= "LEVEL "+Abilities.getAmount().ToString(); 
            AbilitiesSubtotal.text = "$"+SubTotalAbilities.ToString();
            return SubTotalAbilities;
        }

    }
}