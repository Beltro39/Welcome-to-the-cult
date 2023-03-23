using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources 
{
     //Cantidad del recurso propio del jugador en total
     int amount;
     // Cantidad del recurso propio del jugador disponible
     protected int currentAvailableResource;
     //Cantidad limite de recursos disponibles por ronda
     private int limitResourcePerRound;
     //Cantidad limite de recursos disponibles por ronda original
     private int originalLimitResourcePerRound;
     //Limite que puede llegar a tener un recurso
     private int limit;
    
     int cost;
    
    public Resources(int limitResourcePerRound, int amount, int cost, int limit){
        this.limitResourcePerRound = limitResourcePerRound;
        this.originalLimitResourcePerRound = limitResourcePerRound;
        this.cost = cost;
        this.limit = limit;
        this.amount= amount;
        this.currentAvailableResource = amount;
    }     
    public Resources(){
    }
         
    public int getAmount(){
         return amount;
    }     

    public int getLimitResourcePerRound(){
        return limitResourcePerRound;
    }
    public int getOriginalLimitResourcePerRound(){
        return originalLimitResourcePerRound;
    }

    public int getLimit(){
        return limit;
    }

      public int getCost(){
        return cost;
    }

     public void setCost(int cost){
        this.cost = cost;
    }


     public void SetAmount(int amount){
         this.amount = amount;
    }     
     public void AddAmount(int amount){
        this.amount += amount;
        if(amount>limit){
            //Mandar un error
            this.amount -= limit;
        }
    }
         
    public void RemoveAmount(int amount){
        this.amount -= amount;
        if(this.amount < 0){
           this.amount = 0;
        }
    }  
   

     

     public int getCurrentAvailableResource(){
         return currentAvailableResource;
     }

     public void RemoveLimitResourcePerRound(int limitResourcePerRound){
         this.limitResourcePerRound -= limitResourcePerRound;
         if(this.limitResourcePerRound < 0){
             this.limitResourcePerRound = 0;
         }
    }

    public void AddLimitResourcePerRound(int limitResourcePerRound){
         this.limitResourcePerRound += limitResourcePerRound;
         if(this.limitResourcePerRound > this.originalLimitResourcePerRound){
             this.limitResourcePerRound = this.originalLimitResourcePerRound;
         }
    }

   
}



