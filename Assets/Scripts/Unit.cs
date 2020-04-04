using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Unit : MonoBehaviour
{
    public string Name;
    public float Damage;
    public float MaxHp;
    public float HpActual;
    public int element; 
    public int counterElement; 
    public int MaxMp;
    public int mana;

   public bool TakeDamage(float dmg){

        HpActual -= dmg;
        
        if(HpActual <= 0){
            return true;
        }else {
            return false;
        }
    }
    public bool ReduxMana(int id){
        if (id == 1){
            mana = mana - 1;
        }else if(id == 2){
            mana = mana -2;
        }else if(mana == 3){
            mana = mana - 3;
        }
        if(mana == 0){
            return true;
        }else{
            return false;
        }
    }
    public void ProteccionElemental(int id){
        if(id == 0){
            element = 0;
            counterElement = 0;
        }else if(id == 1){
            element = 1;
            counterElement = 5;
        }else if (id == 2){
            element = 2;
            counterElement = 1;
        }else if (id == 3){
            element = 3;
            counterElement = 2;
        }else if (id == 4){
            element = 4;
            counterElement = 3;
        }else if (id == 5){
            element = 5;
        }else if (id == 6){
            element = 6;
            counterElement = 4;
        }
    }
    public bool Life(int id){
        if(id == 1){
            HpActual -= 2; 
        }else if(id == 2){
            HpActual -= 5;
        }
        if(HpActual <= 0){
            return true;
        }else {
            return false;
        }
    }
    public bool ataqueElemental(int elementAtt, bool boost, float dmg){
        if(boost == true){
            if(elementAtt == element){
                HpActual -= ((dmg  - (dmg/2))-(dmg/4)); 
            }else if(elementAtt == counterElement){
                    HpActual -= ((dmg  - (dmg/2))-(dmg/4)); 
            }else if(element == 5){
                HpActual -= (dmg  - (dmg/2));
            }
        }else{
            if(elementAtt == element){
                 HpActual -= (dmg  - (dmg/2));  
            }else if(elementAtt == counterElement){
                 HpActual -= (dmg  + (dmg/2)); 
            }
        }
        if(HpActual <= 0){
            return true;
        }else {
            return false;
        }
    }
    public void Heal(){
        HpActual += 6;
        
        if(HpActual>=100){
            HpActual = 100;
        }
    }

}
