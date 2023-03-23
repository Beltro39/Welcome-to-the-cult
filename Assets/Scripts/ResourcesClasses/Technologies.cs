using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Technologies : Resources
{
    public Technologies(int amount) : base(5, amount,5, 10){
    }
    public void updateCost(){
        if(getAmount() <= 5){
            setCost(5);
        }else if(getAmount()<=8){
            setCost(7);
        }else{
            setCost(10);
        }
    }

    public int getCostUpdated(){
        updateCost();
        return getCost();
    }
}

public class Servers : Technologies{
    public Servers(int amount) : base(amount){
    }
}
public class Satellites : Technologies{
    public Satellites(int amount) : base(amount){
    }
}
public class IA : Technologies{
    public IA(int amount) : base(amount){
    }
}
public class Hosting : Technologies{
    public Hosting(int amount) : base(amount){
    }
}

public class ListTechnologies{
        Servers Servers;
        Satellites Satellites;
        IA IA;
        Hosting Hosting;    
        private int countTechnologies;
        private int countAvailableTechnologies;
        private int averageTechnologies;
        private int averageAvailableTechnologies;

    public ListTechnologies(Servers Servers, Satellites Satellites, IA IA, Hosting Hosting){
        this.Servers = Servers;
        this.Satellites = Satellites;
        this.IA = IA;
        this.Hosting = Hosting;
        AddTechnologies(Servers); AddTechnologies(Satellites); AddTechnologies(IA); AddTechnologies(Hosting);
        calculateAverageTechnologies();
    }
    public void AddTechnologies(Technologies technologies){
        int amount= technologies.getAmount();  
        countTechnologies+= amount;
        countAvailableTechnologies+= amount;
    }
    public void calculateAverageTechnologies(){
        averageTechnologies= (int) (countAvailableTechnologies)/4;
         averageAvailableTechnologies= (int) (countAvailableTechnologies)/4;
    }
    public int getAverageAvailableTechnologies(){
        return averageAvailableTechnologies;
    }
    public int getAverageTechnologies(){
        return averageTechnologies;
    }

    public ListTechnologies(){
    }

    public Servers getServers(){return Servers;}
    public Satellites getSatellites(){return Satellites;}
    public IA getIA(){return IA;}
    public Hosting getHosting(){return Hosting;}
}
