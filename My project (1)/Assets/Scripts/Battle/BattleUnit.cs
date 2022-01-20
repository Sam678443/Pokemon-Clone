using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] PokemonBase _base;
    [SerializeField] bool isPlayerUnit;

    //Property to store Pokemon created
    public Pokemon Pokemon { get; set; }

    public void Setup()
    {
        //Call Pokemon class constructor to create Pokemon
        Pokemon = new Pokemon(_base, level);


        if (isPlayerUnit)
            GetComponent<Image>().sprite = Pokemon.Base.BackSprite;
        else
            GetComponent<Image>().sprite = Pokemon.Base.FrontSprite;
    }
}
