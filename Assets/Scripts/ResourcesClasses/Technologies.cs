using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Technologies : Resources
{
    public Technologies(int amount) : base(amount,10){
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

    public ListTechnologies(Servers Servers, Satellites Satellites, IA IA, Hosting Hosting){
        this.Servers = Servers;
        this.Satellites = Satellites;
        this.IA = IA;
        this.Hosting = Hosting;
    }
    
    public int getAverageAvailableTechnologies(){
        int total = Servers.getCurrentAvailableResource() + Satellites.getCurrentAvailableResource() +
        IA.getCurrentAvailableResource() +Hosting.getCurrentAvailableResource();
        return (int) total/4;
    }
    public int getAverageTechnologies(){
        int total = Servers.getAmount() + Satellites.getAmount() +
        IA.getAmount() +Hosting.getAmount();
        return (int) total/4;
    }

    public ListTechnologies(){
    }

    public Servers getServers(){return Servers;}
    public Satellites getSatellites(){return Satellites;}
    public IA getIA(){return IA;}
    public Hosting getHosting(){return Hosting;}
}
