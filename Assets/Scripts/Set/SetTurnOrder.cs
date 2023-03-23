using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SetTurnOrder : MonoBehaviour
{
    private List<int> turnOrder = new List<int>(){1,2,3};
    // Start is called before the first frame update
    public int setTurnOrder(){
        var random = new System.Random();
        var value = random.Next(0, turnOrder.Count);
        int myTurn = 0;
        try{
            myTurn = turnOrder[value];
            turnOrder.RemoveAt(value);
        }
        catch (Exception e)
         {
            Console.WriteLine("{0} Second exception caught.", e);
            Debug.Log(value);
         }
        return myTurn;
    }
 
}
