using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class SetDimension : MonoBehaviour
{
    private List<string> dimensiones = new List<string>(){"Organization and people", "Information and technology", "Partners and suppliers", "Value streams and processes"};

    public string setDimension(){
        
        var random = new System.Random();
        var value = random.Next(0, dimensiones.Count);
        string myDimension= "null";
        try{
             myDimension= dimensiones[value];
             dimensiones.RemoveAt(value);
        }
        catch (Exception e)
         {
            Console.WriteLine("{0} Second exception caught.", e);
            Debug.Log(value);
         }
        return myDimension;
    }
}
