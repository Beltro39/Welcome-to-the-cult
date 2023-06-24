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

namespace Lean.Gui
{
    public enum PositionUser {Left, Right}
    public class UserExchange : MonoBehaviour
    {
        
        // Userr info
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

        private string[] nameResourceSelected = new string[6];
        private Dictionary<string, Resources> dictNameResource;
        private Dictionary<string, Button> dictNameButton;
        private Dictionary<string, Text> dictNameText;
        private bool isAcceptExchange = false;
        private bool isCancelExchange = false;

        // Info class
        [SerializeField] private PositionUser positionUser;
        //Image
        [SerializeField] private Image imageAcceptExchange;
        //Serializer Resources
        [SerializeField] private Text JuniorsTotal;
        [SerializeField] private Text SemiSeniorsTotal;
        [SerializeField] private Text SeniorsTotal;
        [SerializeField] private Text ArchitectsTotal;
        [SerializeField] private Text ServersTotal;
        [SerializeField] private Text SatellitesTotal;
        [SerializeField] private Text IATextTotal;
        [SerializeField] private Text HostingTotal;
        [SerializeField] private Text RecruitmentTotal;
        [SerializeField] private Text SkillfulTotal;
        [SerializeField] private Text BargainTotal;
        [SerializeField] private Text ResearchTotal;
        [SerializeField] private Text ItilianosTotal;

        [SerializeField] private Button JuniorsButton;
        [SerializeField] private Button SemiSeniorsButton;
        [SerializeField] private Button SeniorsButton;
        [SerializeField] private Button ArchitectsButton;
        [SerializeField] private Button ServersButton;
        [SerializeField] private Button SatellitesButton;
        [SerializeField] private Button IAButtonButton;
        [SerializeField] private Button HostingButton;
        [SerializeField] private Button RecruitmentButton;
        [SerializeField] private Button SkillfulButton;
        [SerializeField] private Button BargainButton;
        [SerializeField] private Button ResearchButton;
        [SerializeField] private Button ItilianosButton;


        //Serializer UserInfo
        [SerializeField] private Image UserImage;
        [SerializeField] private Text UserName;

        


        //Serializer Offer
        [SerializeField] private Text[] cants = new Text[6];
        [SerializeField] private Image[] image = new Image[6];


        //Utils class
        SetAvatarSprite setAvatarSprite;
        GameController gameController;


        private StringResouceToSprite stringResouceToSprite;
       //C�digo que se ejecuta con el start
       private Dictionary<string, Button> GetDictionaryNameToButton()
        {

            return new Dictionary<string, Button>
            {
                {"Juniors", JuniorsButton },
                {"SemiSeniors", SemiSeniorsButton },
                {"Seniors", SeniorsButton },
                { "Architects", ArchitectsButton},
                {"Servers", ServersButton},
                {"Satellites", SatellitesButton },
                {"IA", IAButtonButton },
                {"Hosting", HostingButton },
                {"Recruitment", RecruitmentButton },
                {"Skillful", SkillfulButton },
                {"Bargain", BargainButton },
                {"Research", ResearchButton },
                {"Itilianos", ItilianosButton },
            };
        }
        private Dictionary<string, Text> GetDictionaryNameToText()
        {
            return new Dictionary<string, Text>
            {
                {"Juniors", JuniorsTotal },
                {"SemiSeniors", SemiSeniorsTotal },
                {"Seniors", SeniorsTotal },
                { "Architects", ArchitectsTotal},
                {"Servers", ServersTotal},
                {"Satellites", SatellitesTotal },
                {"IA", IATextTotal },
                {"Hosting", HostingTotal },
                {"Recruitment", RecruitmentTotal },
                {"Skillful", SkillfulTotal },
                {"Bargain", BargainTotal },
                {"Research", ResearchTotal },
                {"Itilianos", ItilianosTotal },
            };
        }

        // C�digo que ejecuta el run
        private void SetInfoUser()
        {
            Debug.Log(player.getNickname());
            UserName.text = player.getNickname();
            // Implement Avatar
            setAvatarSprite.setImage(UserImage, player.getAvatar());
        }
        private Dictionary<string, Resources> CreateDictNameResource()
        {
            Dictionary<string, Resources>  dictNameResource = new Dictionary<string, Resources> {
                {"Juniors", Juniors },
                {"SemiSeniors", SemiSeniors },
                {"Seniors", Seniors },
                { "Architects", Architects},
                {"Servers", Servers},
                {"Satellites", Satellites },
                {"IA", IA },
                {"Hosting", Hosting },
                {"Recruitment", Recruitment },
                {"Skillful", Skillful },
                {"Bargain", Bargain },
                {"Research", Research }

            };
            return dictNameResource;
        }

        private void SetInfoExchange()
        {
            // Employees
            JuniorsTotal.text = "EMP " + Juniors.getCurrentAvailableResource().ToString() + "/" + Juniors.getAmount();
            SemiSeniorsTotal.text = "EMP " + SemiSeniors.getCurrentAvailableResource().ToString() + "/" + SemiSeniors.getAmount().ToString();
            SeniorsTotal.text = "EMP " + Seniors.getCurrentAvailableResource().ToString() + "/" + Seniors.getAmount().ToString();
            ArchitectsTotal.text = "EMP " + Architects.getCurrentAvailableResource().ToString() + "/" + Architects.getAmount().ToString();
            //Technologies
            ServersTotal.text = "LVL " + Servers.getCurrentAvailableResource().ToString() + "/" + Servers.getAmount().ToString();
            SatellitesTotal.text = "LVL " + Satellites.getCurrentAvailableResource().ToString() + "/" + Satellites.getAmount().ToString();
            IATextTotal.text = "LVL " + IA.getCurrentAvailableResource() + "/" + IA.getAmount().ToString();
            HostingTotal.text = "LVL " + Hosting.getCurrentAvailableResource().ToString() + "/" + Hosting.getAmount().ToString();
            //habilities
            ResearchTotal.text = "LVL " + Research.getCurrentAvailableResource().ToString() + "/" + Research.getAmount().ToString();
            SkillfulTotal.text = "LVL " + Skillful.getCurrentAvailableResource().ToString() + "/" + Skillful.getAmount().ToString();
            BargainTotal.text  = "LVl " + Bargain.getCurrentAvailableResource().ToString() + "/" + Bargain.getAmount().ToString();
            RecruitmentTotal.text = "LVL " + Recruitment.getCurrentAvailableResource().ToString() + "/" + Recruitment.getAmount().ToString();
            // Itilianos
            ItilianosTotal.text = "$ " + Itilianos.getAmount();
        }
        public void RestartValues()
        {
            for (int i = 0; i<6; i++)
            {
                cants[i].text = "0";
                image[i].sprite = null;
            }
        }
        public void Run(Player player)
        {
            this.player = player;
            setAvatarSprite = GameObject.Find("UIController").GetComponent<SetAvatarSprite>();
            stringResouceToSprite = GameObject.Find("UIController").GetComponent<StringResouceToSprite>();  
            //Restart Variables
            nameResourceSelected = new string[6]; // Restart nameResourceSelected
            isAcceptExchange = false; // Restart isAcceptExchange
            isCancelExchange = false;
            imageAcceptExchange.enabled = false;
            RestartValues();
            // Configuration varibles owner
            Juniors = player.getListEmployees().getJuniors();
            SemiSeniors = player.getListEmployees().getSemiSeniors();
            Seniors = player.getListEmployees().getSeniors();
            Architects = player.getListEmployees().getArchitects();
            Servers = player.getListTechnologies().getServers();
            Satellites = player.getListTechnologies().getSatellites();
            IA = player.getListTechnologies().getIA();
            Hosting = player.getListTechnologies().getHosting();
            Recruitment = player.getListAbilities().getRecruitment();
            Skillful = player.getListAbilities().getSkillful();
            Bargain = player.getListAbilities().getBargain();
            Research = player.getListAbilities().getResearch();
            Itilianos = player.getItilianos();
            // Save all in dict
            dictNameResource = CreateDictNameResource();

            // render user info
            SetInfoUser();
            SetInfoExchange();
            dictNameButton = GetDictionaryNameToButton();
            dictNameText = GetDictionaryNameToText();
        }
        //Funcionalidades de botones
        public void SetResources(string resource)
        {
            int idCellAviable = GetIdCellAviable();
            if (idCellAviable != -1 && VerififedResource(resource, 1) && !isAcceptExchange) // Se sume a la oferta siempre y cuando no se ha dado aceptar
            {
                Button button = dictNameButton[resource];
                image[idCellAviable].sprite = stringResouceToSprite.GetStripte(resource);
                button.enabled = false;
                nameResourceSelected[idCellAviable] = resource;
                AddCantResource(idCellAviable);
            }
        }
        private bool VerififedResource(string resourceString, int total)
        {
            int currentResource;
            if (resourceString.Equals("Itilianos"))
            {
                currentResource = Itilianos.getAmount();
            }
            else
            {
                Resources resource = dictNameResource[resourceString];
                currentResource = resource.getCurrentAvailableResource();
            }

            if (total <= currentResource)
            {
                return true;
            }
            return false;
        }
        private void ChangesCurrentValues(string resourceString, int totalExchange)
        {

            Text textRateResource = dictNameText[resourceString];
            if (resourceString.Equals("Itilianos"))
            {
                int newCurrent = Itilianos.getAmount() - totalExchange;
                textRateResource.text = "$ " + newCurrent.ToString();
            }
            else
            {
                string CONST_STRING = textRateResource.text.Split("/")[0].Split(" ")[0];
                Resources resource = dictNameResource[resourceString];
                int newCurret = resource.getCurrentAvailableResource() - totalExchange;
                textRateResource.text = CONST_STRING + " " + newCurret + "/" + resource.getAmount();
            }
            
        }
        public void AddCantResource(int id_cell)
        {
            string resourceString = nameResourceSelected[id_cell];
            if (resourceString != null && !isAcceptExchange) // Para que se suman recursos no se debe aceptar la transacci�n
            {
                string textTotal = cants[id_cell].text;
                int total = int.Parse(textTotal);
                total += 1;
                if (VerififedResource(resourceString, total))
                {
                    cants[id_cell].text = total.ToString();
                    ChangesCurrentValues(resourceString, total);
                }
            }
        }
        public void MinusCantResource(int id_cell)
        {
            string resourceString = nameResourceSelected[id_cell];
            if (resourceString != null && !isAcceptExchange) //  Para que se resten recursos no se debe aceptar la transacci�n
            {
                string textTotal = cants[id_cell].text;
                int total = int.Parse(textTotal);
                total -= 1;
                if (total == 0)
                {
                    string resourceCell = nameResourceSelected[id_cell];
                    Button button = dictNameButton[resourceCell];
                    button.enabled = true;
                    nameResourceSelected[id_cell] = null;
                    image[id_cell].sprite = null;

                }
                cants[id_cell].text = total.ToString();
                ChangesCurrentValues(resourceString, total);
            }
        }
        private int GetIdCellAviable()
        {
            for (int i = 0; i < nameResourceSelected.Length; i++)
            {
                if (nameResourceSelected[i] == null){ return i; }
            }
            return -1;
        }

        public void AcceptExchange()
        {
            // Esta es la l�gica cuando se da aceptar
            isAcceptExchange = true;
            imageAcceptExchange.enabled = true;
        }
        public void CancelExchange()
        {
            if (isAcceptExchange)
            {
                isAcceptExchange = false;
                imageAcceptExchange.enabled = false;
            }
            else
            {
                Debug.Log("Transacci�n Cancelada");
                isCancelExchange= true;
            }
        }
        public Dictionary<string, int>  TransferResourceExchenge()
        {
            Dictionary<string, int>  dictReturn  = new Dictionary<string, int>();
            for (int i = 0; i< nameResourceSelected.Length; i++) {
                string resourseString = nameResourceSelected[i];
                if (resourseString != null) {
                    Text cantText = cants[i];
                    int cant = int.Parse(cantText.text);
                    dictReturn.Add(resourseString, cant);
                    if(resourseString.Equals("Itilianos"))
                    {
                        Itilianos.SetAmount(Itilianos.getAmount() - cant);
                    }
                    else
                    {
                        Resources resource = dictNameResource[resourseString];
                        resource.SetAmount(resource.getCurrentAvailableResource() - cant);
                    }
                }
            }
            return dictReturn;
        }
        public void SetResourceExchange(Dictionary<string, int> newResources)
        {
            foreach(KeyValuePair<string, int> kvp in newResources)
            {
                string resourceString = kvp.Key;
                int cant = kvp.Value;
                if (resourceString.Equals("Itilianos"))
                {
                    Itilianos.SetAmount(Itilianos.getAmount() + cant);
                }
                else
                {
                    Resources resource = dictNameResource[resourceString];
                    resource.SetAmount(resource.getCurrentAvailableResource() + cant);
                }
            }
        }
        public PositionUser GetPositionUser()
        {
            return positionUser;
        }
       public bool GetIscancell()
        {
            return isCancelExchange;
        }
        public bool GetIsAcceptExchange()
        {
            return isAcceptExchange;
        }
    }
    
   
}
