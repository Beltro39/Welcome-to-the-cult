using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources 
{
     //Cantidad del recurso propio del jugador en total
     int amount;
     // Cantidad del recurso propio del jugador disponible
     protected int currentAvailableResource;
     //Limite que puede llegar a tener un recurso
     private int limit;
    
    public Resources(int amount, int limit){
        this.limit = limit;
        this.amount= amount;
        this.currentAvailableResource = amount;
    }     
    public Resources(){
    }
         
    public int getAmount(){
         return amount;
    }     

    public int getLimit(){
        return limit;
    }

    public void SetAmount(int amount){
         this.amount = amount;
    }     
    public void AddAmount(int amount){
        this.amount += amount;
        AddCurrentAvailableResource(amount);
        if(amount>limit){
            //Mandar un error
            this.amount -= limit;
        }
    }
         
    public void RemoveAmount(int amount){
        this.amount -= amount;
        RemoveCurrentAvailableResource(amount);
        if(this.amount < 0){
           this.amount = 0;
        }
    }  

    public void AddCurrentAvailableResource(int currentAvailableResource){
        this.currentAvailableResource += currentAvailableResource;
        if(currentAvailableResource>limit){
            //Mandar un error
            this.currentAvailableResource -= currentAvailableResource;
        }
    }

    public void RemoveCurrentAvailableResource(int currentAvailableResource){
        this.currentAvailableResource -= currentAvailableResource;
        if(this.currentAvailableResource < 0){
           this.currentAvailableResource = 0;
        }
    }  

    public int getCurrentAvailableResource(){
         return currentAvailableResource;
    }

}



