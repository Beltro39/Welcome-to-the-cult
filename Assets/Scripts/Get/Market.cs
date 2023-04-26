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
            { "Juniors", new int[] { 3, 2, 1 }},
            { "SemiSeniors",  new int[] { 5, 4, 3 }},
            { "Seniors", new int[] { 7, 6, 5 }},
            { "Architects", new int[] { 10, 9, 8 }},
            { "Servers", new int[] { 5, 7, 10 }},
            { "Satellites",  new int[] { 5, 7, 10 }},
            { "IA", new int[] { 5, 7, 10 }},
            { "Hosting", new int[] { 9, 7, 5 }},
            { "Recruitment", new int[] { 9, 7, 5, 1 }},
            { "Skillful",  new int[] { 9, 7, 5 }},
            { "Bargain", new int[] { 9, 7, 5 }},
            { "Research", new int[] { 9, 7, 5 }},
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
            resourcesPerRoundCopy = DeepCopy(resourcesPerRoundOriginal);
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

        public void ResetCopy()
        {
            resourcesPerRoundCopy = DeepCopy(resourcesPerRound);
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

        public int getResourceAvailabilityCopy(string resource){
            return resourcesPerRoundCopy[resource];
        }

        public int getResourceAvailability(string resource){
            return resourcesPerRound[resource];
        }

        public void addResourceCopy(string resource){
            resourcesPerRoundCopy[resource]--;
            if(getResourceAvailabilityCopy(resource) < 0){
                resourcesPerRoundCopy[resource] = 0;
            }
        }


        public void removeResourceCopy(string resource){
            resourcesPerRoundCopy[resource]++;
            if(getResourceAvailabilityCopy(resource) > getResourceAvailability(resource)){
                resourcesPerRoundCopy[resource] = getResourceAvailability(resource);
            }
        }

        public void addResource(string resource){
            resourcesPerRound[resource]--;
            
        }

        public void removeResource(string resource){
            resourcesPerRound[resource]++;
        }


    }
}
