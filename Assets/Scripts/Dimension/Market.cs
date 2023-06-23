using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace Lean.Gui
{
    public class Market
    {
        private Dictionary<string, int>  resourcesPerRound = new Dictionary<string, int>();
        private Dictionary<string, int>  resourcesPerRoundCopy = new Dictionary<string, int>();
        string[] typesEmployees = { "Juniors", "SemiSeniors", "Seniors", "Architects"};
        string[] typesTechnologies = { "Servers", "Satellites", "IA", "Hosting"};
        string[] typesAbilities = { "Recruitment", "Skillful", "Bargain", "Research"};
        
        Dictionary<string, int[]> costos = new Dictionary<string, int[]>
        {
            { "Juniors", new int[] { 1, 1, 1 }},
            { "SemiSeniors",  new int[] { 1, 1, 1 }},
            { "Seniors", new int[] { 1, 1, 1 }},
            { "Architects", new int[] { 1, 1, 1 }},
            { "Servers", new int[] { 1, 1, 1 }},
            { "Satellites",  new int[] { 1, 1, 1 }},
            { "IA", new int[] { 1, 1, 1 }},
            { "Hosting", new int[] { 1, 1, 1 }},
            { "Recruitment", new int[] { 1, 1, 1, 1 }},
            { "Skillful",  new int[] { 1, 1, 1 }},
            { "Bargain", new int[] { 1, 1, 1 }},
            { "Research", new int[] { 1, 1, 1 }},
        };

        Dictionary<string, int> resourcesPerRoundOriginal = new Dictionary<string, int>
        {
            { "Juniors", 25},
            { "SemiSeniors", 9},
            { "Seniors", 5},
            { "Architects", 1},
            { "Servers", 5},
            { "Satellites", 5},
            { "IA", 5},
            { "Hosting", 5},
            { "Recruitment", 2},
            { "Skillful", 2},
            { "Bargain", 2},
            { "Research", 2}
        };

        public Market()
        {
            resourcesPerRound = DeepCopy(resourcesPerRoundOriginal);
        }

        private Dictionary<string, int>  DeepCopy(Dictionary<string, int>  original)
        {
            Dictionary<string, int>  copy = new Dictionary<string, int>(original);   
            return copy;
        }

        public void ResetToOriginalValues()
        {
            resourcesPerRound = DeepCopy(resourcesPerRoundOriginal);
        }

        public int getIndexDiscount(string resource, Player player){
            int abilitieLVL = 0;
            if (typesEmployees.Contains(resource)){
                abilitieLVL = player.getListAbilities().getRecruitment().getAmount();
            }
            else if (typesTechnologies.Contains(resource)){
                abilitieLVL = player.getListAbilities().getSkillful().getAmount();
            }
            else if(typesAbilities.Contains(resource)){
                abilitieLVL = player.getListAbilities().getResearch().getAmount();
            }
            if(abilitieLVL < 2){
                    return 0;
            }
            if(abilitieLVL == 3){
                return 1;
            }
            if(abilitieLVL == 4){
                return 2;
            }  

            return 0;
        }


        public int getResourcesCost(string resource, Player player){
            int[] lista = costos[resource];
            int index = getIndexDiscount(resource, player);
            return lista[index];
        }

        public int getResourceAvailability(string resource){
            return resourcesPerRound[resource];
        }

        public void addResource(string resource){
            resourcesPerRound[resource]--;
            if(getResourceAvailability(resource) < 0){
                resourcesPerRound[resource] = 0;
            }
            
        }

        public void removeResource(string resource){
            resourcesPerRound[resource]++;
        }


    }
}
