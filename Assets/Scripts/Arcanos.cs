using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcanos : MonoBehaviour
{
    public string Name;
    public int Damage;
    public int MaxHp;
    public int HpActual;
    public int element;
    public int inUse;
    public int potenciado;
    public int Maxpotenciado; 
    public bool Boosted;
    public bool Life(int id){
        if(id == 1){
            HpActual -= 2; 
        }else if(id == 2){
            HpActual -= 4;
        }else if(id == 3){
            HpActual -= 8;
        }
        if(HpActual <= 0){
            return true;
        }else {
            return false;
        }
    }
    public void Heal(int id){
        if(id == 2){
            HpActual +=4;
        }else{
            HpActual += 2;
        }

        if(HpActual>=30){
            HpActual = 30;
        }
    }
    public bool ArcanoOscuro(int id){
        if(id == 1){
            HpActual -= 1;
        }
        if(HpActual <= 0){
            return true;
        }else {
            return false;
        }
    }
    public bool potenciados(){
        potenciado -= 1;
        if(potenciado == 0){
            return false;
        }else {
            return true;
        }
    }
    public void SetBoost(){
        potenciado = 4;
    }
    public void SetBoostBool(){
        Boosted = true;
    }
    public void quitarBoost(){
        Boosted = false;
    }
}
