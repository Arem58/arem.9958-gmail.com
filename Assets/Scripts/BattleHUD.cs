using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;
    public Slider  mpSlider; 
    public void SetHUD(Unit unit){
        nameText.text = unit.Name;
        hpSlider.maxValue = unit.MaxHp;
        hpSlider.value = unit.HpActual;
        mpSlider.maxValue = unit.MaxMp;
        mpSlider.value = unit.mana;
    }
    public void SetHUD(Arcanos arcano){
        nameText.text = arcano.Name;
        hpSlider.maxValue = arcano.MaxHp;
        hpSlider.value = arcano.HpActual;
    }
    public void SetHUD2(Arcanos arcano){
        hpSlider.maxValue = arcano.MaxHp;
        hpSlider.value = arcano.HpActual;
        mpSlider.maxValue = arcano.Maxpotenciado;
        mpSlider.value = arcano.potenciado;
    }
    public void SetHUD(Enemy1 unit){
        nameText.text = unit.Name;
        hpSlider.maxValue = unit.MaxHp;
        hpSlider.value = unit.HpActual;
    }

    public void SetHP(float hp){
        hpSlider.value = hp;
    }
    public void SetMP(float mp){
        mpSlider.value = mp;
    }
}
