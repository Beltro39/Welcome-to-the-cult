using System.Collections;
using System.Collections.Generic;

namespace Lean.Gui{
public class ValidateExchangeResources
{
    Player player; 
    Dictionary<string, Resources> diccionarioResources;

    public ValidateExchangeResources(Player player){
        this.player = player;
        ListEmployees listEmployees; 
        ListTechnologies listTechnologies;
        ListAbilities listAbilities;
        
        
        listEmployees = player.getListEmployees();
        listTechnologies = player.getListTechnologies();
        listAbilities = player.getListAbilities();


        diccionarioResources = new Dictionary<string, Resources>{
                { "JUNIOR", listEmployees.getJuniors()},
                { "SEMI SENIOR",  listEmployees.getSemiSeniors()},
                { "SENIOR", listEmployees.getSeniors()},
                { "ARCHITECT", listEmployees.getArchitects()},
                { "SERVER", listTechnologies.getServers()},
                { "SATELLITE", listTechnologies.getSatellites()},
                { "IA", listTechnologies.getIA()},
                { "HOSTING", listTechnologies.getHosting()},
                { "EMPLOYEE RECRUITMENT",  listAbilities.getRecruitment()},
                { "SKILLFUL IN TECHNOLOGY", listAbilities.getSkillful()},
                { "BARGANING POWER", listAbilities.getBargain()},
                { "RESEARCH AND PROJECTS",  listAbilities.getResearch()},
                
        };
    }


    public bool ValidatePlayerHasResources(string className, int amount){
        int playerResourceAmount;
        if (className == "ITILIANOS"){
            playerResourceAmount = player.getItilianos().getAmount();
            
        }else if(className == "SUPPLIER" && player.GetSupplier()){
            playerResourceAmount = player.GetSupplier().Difficulty;

        }else if(className == "PARNERT" && player.GetPartner()){
            playerResourceAmount = player.GetPartner().Difficulty;
        }else if((className == "SUPPLIER" || className == "PARNERT") &&  !player.GetSupplier())
            return false;
        else{
            playerResourceAmount = diccionarioResources[className].getAmount();
        }

        if (className == "SUPPLIER" && !player.GetSupplier().Free){
            return false;
        }else if (className == "PARNERT" && !player.GetPartner().Free){
            return false;
        }
        if (playerResourceAmount >= amount){
            return true;
        }else{
            return false;
        }
    }

    public void TakeResourcesFromPlayer(string className, int amount){
        if(ValidatePlayerHasResources(className, amount)){
            if (className == "ITILIANOS"){
                 player.getItilianos().RemoveAmount(amount); 
            
            }else if(className == "SUPPLIER"){
                player.GetSupplier().Occupy();

            }else if(className == "PARNERT"){
                player.GetPartner().Occupy();
            }else{
                diccionarioResources[className].RemoveAmount(amount);   
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
        }
    }

    public void GiveResourcesToPlayer(string className, int amount){
        if (className == "ITILIANOS"){
            player.getItilianos().AddAmount(amount); 
        }else{
            diccionarioResources[className].AddAmount(amount); 
        }
    }
}
}
