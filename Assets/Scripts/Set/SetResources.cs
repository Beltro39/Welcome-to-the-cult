using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetResources : MonoBehaviour
{

    public ListEmployees setInitialValuesEmployees(string dimension){
         Juniors Juniors;
         SemiSeniors SemiSeniors;
         Seniors Seniors;
         Architects Architects;
        
        if(dimension == "Organization and people"){
            Juniors = new Juniors(15);
            SemiSeniors = new SemiSeniors(5);
            Seniors = new Seniors(2);
            Architects = new Architects(0);
        }else if(dimension == "Information and technology"){
            Juniors = new Juniors(6);
            SemiSeniors = new SemiSeniors(3);
            Seniors = new Seniors(1);
            Architects = new Architects(0);
        }else if(dimension == "Partners and suppliers"){
            Juniors = new Juniors(6);
            SemiSeniors = new SemiSeniors(3);
            Seniors = new Seniors(1);
            Architects = new Architects(0);
        }else if(dimension == "Value streams and processes"){
            Juniors = new Juniors(6);
            SemiSeniors = new SemiSeniors(3);
            Seniors = new Seniors(1);
            Architects = new Architects(0);
        }else{
            Juniors = new Juniors(0);
            SemiSeniors = new SemiSeniors(0);
            Seniors = new Seniors(0);
            Architects = new Architects(0);
        }
        ListEmployees ListEmployees= new ListEmployees(Juniors, SemiSeniors, Seniors, Architects);
        return ListEmployees;
        
    }

    public ListEmployees setInitialValuesEmployees(int juniorsAmount, int semiSeniorsAmount, int seniorsAmount, int architectsAmount){
         Juniors Juniors = new Juniors(juniorsAmount);
         SemiSeniors SemiSeniors= new SemiSeniors(semiSeniorsAmount);
         Seniors Seniors= new Seniors(seniorsAmount);
         Architects Architects= new Architects(architectsAmount);
        ListEmployees ListEmployees= new ListEmployees(Juniors, SemiSeniors, Seniors, Architects);
        return ListEmployees;
    }

    public ListTechnologies setInitialValuesTechnologies(string dimension){

        Servers Servers;
        Satellites Satellites;
        IA IA;
        Hosting Hosting;
        if(dimension == "Organization and people"){
            Servers = new Servers(1);
            Satellites = new Satellites(1);
            IA = new IA(1);
            Hosting = new Hosting(1);
        }else if(dimension == "Information and technology"){
            Servers = new Servers(2);
            Satellites = new Satellites(2);
            IA = new IA(2);
            Hosting = new Hosting(2);
        }else if(dimension == "Partners and suppliers"){
            Servers = new Servers(1);
            Satellites = new Satellites(1);
            IA = new IA(1);
            Hosting = new Hosting(1);
        }else if(dimension == "Value streams and processes"){
            Servers = new Servers(1);
            Satellites = new Satellites(1);
            IA = new IA(1);
            Hosting = new Hosting(1);
        }else{
            Servers = new Servers(0);
            Satellites = new Satellites(0);
            IA = new IA(0);
            Hosting = new Hosting(0);
        }

        ListTechnologies technologiesList = new ListTechnologies(Servers, Satellites, IA, Hosting);
        return technologiesList;
    }
   
     public ListTechnologies setInitialValuesTechnologies(int serversAmount, int satellitesAmount, int IAAmount, int hostingAmount){
         Servers Servers = new Servers(serversAmount);
         Satellites Satellites= new Satellites(satellitesAmount);
         IA IA= new IA(IAAmount);
         Hosting Hosting= new Hosting(hostingAmount);
        ListTechnologies ListTechnologies= new ListTechnologies(Servers, Satellites, IA, Hosting);
        return ListTechnologies;
    }
   
    public ListAbilities setInitialValuesAbilities(string dimension){
        Recruitment Recruitment;
        Skillful Skillful;
        Bargain Bargain;
        Research Research; 
        if(dimension == "Organization and people"){
            Recruitment = new Recruitment(2);
            Skillful = new Skillful(0);
            Bargain = new Bargain(0);
            Research = new Research(0);
        }else if(dimension == "Information and technology"){
            Recruitment = new Recruitment(0);
            Skillful = new Skillful(2);
            Bargain = new Bargain(0);
            Research = new Research(0);
        }else if(dimension == "Partners and suppliers"){
            Recruitment = new Recruitment(0);
            Skillful = new Skillful(0);
            Bargain = new Bargain(2);
            Research = new Research(0);
        }else if(dimension == "Value streams and processes"){
            Recruitment = new Recruitment(0);
            Skillful = new Skillful(0);
            Bargain = new Bargain(0);
            Research = new Research(2);
        }else{
            Recruitment = new Recruitment(0);
            Skillful = new Skillful(0);
            Bargain = new Bargain(0);
            Research = new Research(0);
        }
        ListAbilities ListAbilities= new ListAbilities(Recruitment, Skillful, Bargain, Research);
        return ListAbilities;
        
    }

     public ListAbilities setInitialValuesAbilities(int RecruitmentAmount, int SkillfulAmount, int BargainAmount, int ResearchAmount){
         Recruitment Recruitment = new Recruitment(RecruitmentAmount);
         Skillful Skillful= new Skillful(SkillfulAmount);
         Bargain Bargain= new Bargain(BargainAmount);
         Research Research= new Research(ResearchAmount);
        ListAbilities ListAbilities= new ListAbilities(Recruitment, Skillful, Bargain, Research);
        return ListAbilities;
    }

    public Itilianos setInitialValuesItilianos(string dimension){
        Itilianos Itilianos;
        if(dimension == "Organization and people"){
            Itilianos = new Itilianos(15);
        }else if(dimension == "Information and technology"){
            Itilianos = new Itilianos(15);
        }else if(dimension == "Partners and suppliers"){
            Itilianos = new Itilianos(35);
        }else if(dimension == "Value streams and processes"){
            Itilianos = new Itilianos(36);
        }else{
            Itilianos = new Itilianos(0);
        }
        return Itilianos;
    }

    public Itilianos setInitialValuesItilianos(int itilianosAmount){
        Itilianos Itilianos = new Itilianos(itilianosAmount);
        return Itilianos;
    }


    

}

