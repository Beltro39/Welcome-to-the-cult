using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringResouceToSprite : MonoBehaviour
{
    [SerializeField] private Sprite Juniors;
    [SerializeField] private Sprite SemiSeniors;
    [SerializeField] private Sprite Seniors;
    [SerializeField] private Sprite Architects;
    [SerializeField] private Sprite Servers;
    [SerializeField] private Sprite Satellites;
    [SerializeField] private Sprite IASprite;
    [SerializeField] private Sprite Hosting;
    [SerializeField] private Sprite Recruitment;
    [SerializeField] private Sprite Skillful;
    [SerializeField] private Sprite Bargain;
    [SerializeField] private Sprite Research;
    [SerializeField] private Sprite Itilianos;
    [SerializeField] private Sprite cellGeneric;

    Dictionary<string, Sprite> dictTextSprite;

    public void Start()
    {
        dictTextSprite = new Dictionary<string, Sprite>()
        {
            { "Juniors", Juniors },
            { "SemiSeniors",SemiSeniors },
            { "Seniors", Seniors},
            { "Architects", Architects },
            { "Servers", Servers },
            { "Satellites", Satellites },
            { "IA", IASprite },
            { "Hosting", Hosting },
            { "Recruitment", Recruitment },
            { "Skillful", Skillful },
            { "Bargain", Bargain },
            { "Research", Research },
            { "Itilianos", Itilianos }
        };
    }

    public Sprite GetStripte(string resource)
    {
        return dictTextSprite[resource];
    }
    public Sprite GetCellGeneric()
    {
        return cellGeneric;
    }
}
