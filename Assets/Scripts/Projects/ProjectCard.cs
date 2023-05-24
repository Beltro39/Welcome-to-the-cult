using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Project Card", menuName ="Project Card")] 
public class ProjectCard : ScriptableObject
{
    [SerializeField] private string _nameStakeHolder;
    [SerializeField] private int _difficulty;
    //[SerializeField] private string _title;
    [SerializeField] private Sprite _imageStakeHolder;
    [SerializeField] private Sprite _descriptionSprite;

    [SerializeField] private Sprite[] _resourcesSprite;
    [SerializeField] private string[] _resourcesType;
    [SerializeField] private int[] _resourcesAmount;


    public string NameStakeHolder { get => _nameStakeHolder; set => _nameStakeHolder = value; }
    //public string Title { get => _title; set => _title = value; }
    public int Difficulty { get => _difficulty; set => _difficulty = value; }
    public Sprite ImageStakeHolder { get => _imageStakeHolder; set => _imageStakeHolder = value; }
    public Sprite DescriptionSprite { get => _descriptionSprite; set => _descriptionSprite = value; }

    public Sprite[] ResourcesSprite { get => _resourcesSprite; set => _resourcesSprite = value; }
    public string[] ResourceType { get => _resourcesType; set => _resourcesType = value; }
    public int[] ResourcesAmount{ get => _resourcesAmount; set => _resourcesAmount = value; }

}

