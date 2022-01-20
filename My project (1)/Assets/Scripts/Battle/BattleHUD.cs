using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    //Sets values to variables above
    public void SetData(Pokemon pokemon)
    {
        nameText.text = pokemon.Base.Name; //Value for name text
        levelText.text = "Lvl" + pokemon.Level; //Value for level text
        hpBar.SetHP((float)pokemon.HP / pokemon.MaxHP); //Value for HP bar to function
    }
}
