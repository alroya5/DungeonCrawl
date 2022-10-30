using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;

    public void SetHud(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text ="lvl: "+ unit.level;
        hpSlider.maxValue = unit.maxHp;
        hpSlider.value = unit.currentHp;


    }
    public void SetHp(float hp)
    {
        hpSlider.value = hp;
    }
}
