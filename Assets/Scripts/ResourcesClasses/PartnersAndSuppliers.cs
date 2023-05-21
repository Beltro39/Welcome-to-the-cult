using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New PartnerSupplier Card", menuName ="PartnerSupplier Card")] 
public class PartnersAndSuppliers : ScriptableObject
{
    [SerializeField] private string _stakeHolderType;
    [SerializeField] private string _nameStakeholder;
    [SerializeField] private int _difficulty;
    [SerializeField] private Sprite _imageStakeholder;

    [SerializeField] private Sprite[] _resourceImagesGiven;
    [SerializeField] private string[] _resourceTypesGiven;
    [SerializeField] private int[] _resourceAmountsGiven;

    [SerializeField] private Sprite[] _resourceImagesReceived;
    [SerializeField] private string[] _resourceTypesReceived;
    [SerializeField] private int[] _resourceAmountsReceived;

    [SerializeField] private int _resourceAmountsGivenExtra;
    [SerializeField] private int _resourceAmountsReceivedExtra;

    public string StakeHolderType { get => _stakeHolderType; set => _stakeHolderType = value; }
    public string NameStakeholder { get => _nameStakeholder; set => _nameStakeholder = value; }
    public int Difficulty { get => _difficulty; set => _difficulty = value; }
    public Sprite ImageStakeholder { get => _imageStakeholder; set => _imageStakeholder = value; }

    public Sprite[] ResourceImagesGiven { get => _resourceImagesGiven; set => _resourceImagesGiven = value; }
    public string[] ResourceTypesGiven { get => _resourceTypesGiven; set => _resourceTypesGiven = value; }
    public int[] ResourceAmountsGiven { get => _resourceAmountsGiven; set => _resourceAmountsGiven = value; }

    public Sprite[] ResourceImagesReceived { get => _resourceImagesReceived; set => _resourceImagesReceived = value; }
    public string[] ResourceTypesReceived { get => _resourceTypesReceived; set => _resourceTypesReceived = value; }
    public int[] ResourceAmountsReceived { get => _resourceAmountsReceived; set => _resourceAmountsReceived = value; }

    public int ResourceAmountsGivenExtra { get => _resourceAmountsGivenExtra; set => _resourceAmountsGivenExtra = value; }
    public int ResourceAmountsReceivedExtra { get => _resourceAmountsReceivedExtra; set => _resourceAmountsReceivedExtra = value; }
}

