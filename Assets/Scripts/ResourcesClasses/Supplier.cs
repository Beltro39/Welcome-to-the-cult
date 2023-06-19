using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Supplier Card", menuName ="Supplier Card")] 
public class Supplier : Ally
{
    [SerializeField] private Sprite[] _resourceImagesReceived;
    [SerializeField] private string[] _resourceTypesReceived;
    [SerializeField] private int[] _resourceAmountsReceived;
    [SerializeField] private int _resourceAmountsGivenExtra;
    private bool _free = true;

    public Sprite[] ResourceImagesReceived { get => _resourceImagesReceived; set => _resourceImagesReceived = value; }
    public string[] ResourceTypesReceived { get => _resourceTypesReceived; set => _resourceTypesReceived = value; }
    public int[] ResourceAmountsReceived { get => _resourceAmountsReceived; set => _resourceAmountsReceived = value; }
    
    public int ResourceAmountsGivenExtra { get => _resourceAmountsGivenExtra; set => _resourceAmountsGivenExtra = value; }

    public bool Free{ get => _free; set => _free = value; }
    public void Occupy(){ _free=false;}
    public void Vacate(){ _free=true;}
}

