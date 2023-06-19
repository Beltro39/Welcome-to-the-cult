using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ally : ScriptableObject
{
    [SerializeField] private string _nameStakeholder;
    [SerializeField] private int _difficulty;
    [SerializeField] private Sprite _imageStakeholder;

   

    public string NameStakeholder { get => _nameStakeholder; set => _nameStakeholder = value; }
    public int Difficulty { get => _difficulty; set => _difficulty = value; }
    public Sprite ImageStakeholder { get => _imageStakeholder; set => _imageStakeholder = value; }
    

}

