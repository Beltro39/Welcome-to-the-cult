using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Lean.Gui{
public class InvestorScore
{

    public static void Run(Queue<Player> queuePlayer, int currentCycle){
        foreach (Player player in queuePlayer)
        {
            int value = 0;

            int architects = player.getListEmployees().getArchitects().getAmount();
            int seniors = player.getListEmployees().getSeniors().getAmount();
            int servers = player.getListTechnologies().getServers().getAmount();
            int satellites = player.getListTechnologies().getSatellites().getAmount();
            int ia = player.getListTechnologies().getIA().getAmount();
            int hosting = player.getListTechnologies().getHosting().getAmount();
            int research = player.getListAbilities().getResearch().getAmount();
            int recruitment = player.getListAbilities().getRecruitment().getAmount();
            int bargain = player.getListAbilities().getBargain().getAmount();
            int skillful = player.getListAbilities().getSkillful().getAmount();
            List<int> resourceTechnologies = new List<int>() { servers, satellites, ia, hosting};
            List<int> resourceAbilities = new List<int>() { research, recruitment, bargain, skillful };

            int[] valuePointsForProject = new int[]{ 1,2,3 };
            for (int i = 0; i < 3; i++)
            {
                value += player.GetProjects(i).Count * valuePointsForProject[i];   
            }
             
            foreach (int resourceAmount in resourceTechnologies)
            {
               if(resourceAmount >= 9){
                value += (resourceAmount - 8) * 3;
               }
            }

            foreach (int resourceAmount in resourceAbilities)
            {
               if(resourceAmount >= 4){
                    value += 3;
               }else if(resourceAmount >=3){
                    value += 1;
               }
            }

            if (architects > 0){
                value += architects * 3;
            }
            if (seniors > 0){
                value += 1;
            }
            player.Value += value;
        }      
        
    }
}
}