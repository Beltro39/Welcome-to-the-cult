using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Partner Card", menuName ="Partner Card")] 
public class Partner : Ally
{
    [SerializeField] private Sprite[] _resourceImagesGiven;
    [SerializeField] private string[] _resourceTypesGiven;
    [SerializeField] private int[] _resourceAmountsGiven;

    [SerializeField] private int _resourceAmountsReceivedExtra;

    private bool _free = true;

    public Sprite[] ResourceImagesGiven { get => _resourceImagesGiven; set => _resourceImagesGiven = value; }
    public string[] ResourceTypesGiven { get => _resourceTypesGiven; set => _resourceTypesGiven = value; }
    public int[] ResourceAmountsGiven { get => _resourceAmountsGiven; set => _resourceAmountsGiven = value; }

    public int ResourceAmountsReceivedExtra { get => _resourceAmountsReceivedExtra; set => _resourceAmountsReceivedExtra = value; }
    
    public bool Free{ get => _free; set => _free = value; }
    public void Occupy(){ _free=false;}
    public void Vacate(){ _free=true;}
}

