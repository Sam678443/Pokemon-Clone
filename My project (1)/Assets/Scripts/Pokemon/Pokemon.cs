using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    public PokemonBase Base { get; set; }
    public int Level { get; set; }

    public int HP { get; set; }

    public List<Moves> Moves { get; set; }

    public Pokemon(PokemonBase pBase, int plevel)
    {
        Base = pBase;
        Level = plevel;
        HP = MaxHP; 


        //Generate Moves
        Moves = new List<Moves>();
        foreach(var move in Base.LearnableMoves)
        {
            if(move.Level <= Level)
                Moves.Add(new Moves(move.Base));

            if (Moves.Count >= 4)
                break;
            
        }
    }

    public int Attack
    {
        get { return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5; }
    }

    public int Defense
    {
        get { return Mathf.FloorToInt((Base.Defense * Level) / 100f) + 5; }
    }

    public int SpAttack
    {
        get { return Mathf.FloorToInt((Base.SpAttack * Level) / 100f) + 5; }
    }

    public int SpDefense
    {
        get { return Mathf.FloorToInt((Base.SpDefense * Level) / 100f) + 5; }
    }

    public int Speed
    {
        get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 5; }
    }

    public int MaxHP
    {
        get { return Mathf.FloorToInt((Base.MaxHP * Level) / 100f) + 10; }
    }


}   

