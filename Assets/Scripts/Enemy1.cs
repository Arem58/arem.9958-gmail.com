using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public string Name;
    public float Damage;
    public float MagicDamage; 
    public float Bomba;
    public float MaxHp;
    public float HpActual;
    public int element; 
    public int counterElement; 

     public bool TakeDamage(float dmg, int id, bool boost){
        if(boost == true){
            if(element == id){
                HpActual += (dmg + (dmg/2));
            }else if (counterElement == id){
                HpActual -= (dmg * 2);
            }else{
                HpActual -= (dmg + (dmg/2));
            }
        }else{
            if(element == id){
                HpActual += dmg;
            }else if (counterElement == id){
                HpActual -= (dmg + (dmg/4));
            }else{
                HpActual -= dmg;
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

        if(HpActual>=30){
            HpActual =30;
        }
    }
    public bool SuperHeal(){
        HpActual -= 15;
        if(HpActual <= 0){
            return true;
        }else {
            return false;
        }
    }

    
}


