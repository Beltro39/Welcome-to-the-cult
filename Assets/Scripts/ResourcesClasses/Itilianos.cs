using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itilianos 
{
    private int amount;

    public Itilianos(int amount){
        this.amount = amount;
    }

    public Itilianos(){
    }

    public int getAmount(){
        return amount;
    }     
    public void SetAmount(int amount){
        this.amount = amount;
    }     
    public void AddAmount(int amount){
        this.amount += amount;
    }
         
    public void RemoveAmount(int amount){
        this.amount -= amount;
        if(this.amount < 0){
            this.amount += amount;
            throw new ArgumentException("Resulting amount cannot be less than 0.");
        }
    }  
   
}
