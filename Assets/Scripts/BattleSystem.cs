using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public enum BattleState{ START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    private Arcanos junit; 
    private Arcanos junit2; 
    private Arcanos junit3; 
    private Arcanos junit4;  
    private Arcanos junit5;  
    private Arcanos junit6; 
    public GameObject playerPrefad;
    public GameObject enemyPrefab;
    public GameObject fuegoPrefad;
    public GameObject electricidadPrefad; 
    public GameObject vientoPrefad; 
    public GameObject aguaPrefad; 
    public GameObject luzOscuridadPrefad; 
    public GameObject tierraPrefad;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    public GameObject ProteccionT;
    public GameObject ProteccionA;
    public GameObject ProteccionE;
    public GameObject ProteccionF;
    public GameObject ProteccionO;
    public GameObject ProteccionV;

    Unit playerUnit;
    Enemy1 enemyUnit; 
  
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    public BattleHUD FuegoHUD;
    public BattleHUD VientoHUD;
    public BattleHUD AguaHUD;
    public BattleHUD ElectricidadHUD;
    public BattleHUD LuzOscuridadHUD;
    public BattleHUD TierraHUD;
    public BattleHUD FuegoHUD2;
    public BattleHUD VientoHUD2;
    public BattleHUD AguaHUD2;
    public BattleHUD ElectricidadHUD2;
    public BattleHUD LuzOscuridadHUD2;
    public BattleHUD TierraHUD2;
    public Text dialogueText;
    public BattleState state;
    private int turnos;
    private bool isDead;
    private bool noMana;
    public GameObject FuegoUI;
    public GameObject ElectricidadUI;
    public GameObject VientoUI;
    public GameObject AguaUI;
    public GameObject TierraUI;
    public GameObject LuzOscuridadUI;
    public GameObject FuegoUIP;
    public GameObject ElectricidadUIP;
    public GameObject VientoUIP;
    public GameObject AguaUIP;
    public GameObject TierraUIP;
    public GameObject LuzOscuridadUIP;
    public GameObject FuegoF;
    public GameObject ElectricidadF;
    public GameObject VientoF;
    public GameObject AguaF;
    public GameObject TierraF;
    public GameObject LuzOscuridadF;
    public GameObject BotonesUI;
    private bool changeTurn;
    private bool ArcanoMuerto;
    private bool ArcanoOscutoMuerto;
    public Text Turnos;
    private int manaID; 
    private int proteccionTurn;
    public Text mana;
    public int botonID;
    public GameObject CurarUI;
    public GameObject Botone1;
    public GameObject Botone2;
    public GameObject Botone3;
    public GameObject Botone4;
    public GameObject Botone5;
    public GameObject Botone6;
    private bool pot1;
    private bool pot2;
    private bool pot3;
    private bool pot4;
    private bool pot5;
    private bool pot6;
    private int EnemyAttack;
    public GameObject BotonHeal;
    public GameObject SuperBotonHeal;
    public GameObject Defensa;
    public GameObject Robar;


    void Start(){
        state = BattleState.START; 
        StartCoroutine(SeyUpBattle());
        turnos = 0;
        Turnos.text = "Turno " + turnos;
    } 
        
    IEnumerator SeyUpBattle()
    {
        GameObject playerGo = Instantiate(playerPrefad, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();
        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Enemy1>();
        junit = fuegoPrefad.GetComponent<Arcanos>();
        FuegoHUD.SetHUD(junit);
        FuegoHUD2.SetHUD2(junit);
        junit2 = aguaPrefad.GetComponent<Arcanos>();
        AguaHUD.SetHUD(junit2);
        AguaHUD2.SetHUD2(junit2);
        junit3 = electricidadPrefad.GetComponent<Arcanos>();
        ElectricidadHUD.SetHUD(junit3);
        ElectricidadHUD2.SetHUD2(junit3);
        junit4 = vientoPrefad.GetComponent<Arcanos>();
        VientoHUD.SetHUD(junit4);
        VientoHUD2.SetHUD2(junit4);
        junit5 = luzOscuridadPrefad.GetComponent<Arcanos>();
        LuzOscuridadHUD.SetHUD(junit5);
        LuzOscuridadHUD2.SetHUD2(junit5);
        junit6 = tierraPrefad.GetComponent<Arcanos>();
        TierraHUD.SetHUD(junit6);
        TierraHUD2.SetHUD2(junit6);

        dialogueText.text = "VS " + enemyUnit.Name;

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(3f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    void GameUI(){
        if(EventSystem.current.currentSelectedGameObject.name == "ArcanoF"){
            if(junit.inUse == 0){
                FuegoUI.SetActive(true);
                ElectricidadUI.SetActive(false);
                AguaUI.SetActive(false);
                TierraUI.SetActive(false);
                LuzOscuridadUI.SetActive(false);
                VientoUI.SetActive(false);
                FuegoUIP.SetActive(false);
                ElectricidadUIP.SetActive(true);
                AguaUIP.SetActive(true);
                TierraUIP.SetActive(true);
                LuzOscuridadUIP.SetActive(true);
                VientoUIP.SetActive(true);
            }else{
                return;
            }
        }else if(EventSystem.current.currentSelectedGameObject.name == "ArcanoA"){
            if(junit2.inUse == 0){
                FuegoUI.SetActive(false);
                ElectricidadUI.SetActive(false);
                AguaUI.SetActive(true);
                TierraUI.SetActive(false);
                LuzOscuridadUI.SetActive(false);
                VientoUI.SetActive(false);
                FuegoUIP.SetActive(true);
                ElectricidadUIP.SetActive(true);
                AguaUIP.SetActive(false);
                TierraUIP.SetActive(true);
                LuzOscuridadUIP.SetActive(true);
                VientoUIP.SetActive(true);
            }else{
                return;
            }
            
        }else if(EventSystem.current.currentSelectedGameObject.name == "ArcanoV"){
            if(junit4.inUse == 0){
                FuegoUI.SetActive(false);
                ElectricidadUI.SetActive(false);
                AguaUI.SetActive(false);
                TierraUI.SetActive(false);
                LuzOscuridadUI.SetActive(false);
                VientoUI.SetActive(true);
                FuegoUIP.SetActive(true);
                ElectricidadUIP.SetActive(true);
                AguaUIP.SetActive(true);
                TierraUIP.SetActive(true);
                LuzOscuridadUIP.SetActive(true);
                VientoUIP.SetActive(false);
            }else{
                return;
            }
    
        }else if(EventSystem.current.currentSelectedGameObject.name == "ArcanoT"){
            if(junit6.inUse==0){
                FuegoUI.SetActive(false);
                ElectricidadUI.SetActive(false);
                AguaUI.SetActive(false);
                TierraUI.SetActive(true);
                LuzOscuridadUI.SetActive(false);
                VientoUI.SetActive(false);
                FuegoUIP.SetActive(true);
                ElectricidadUIP.SetActive(true);
                AguaUIP.SetActive(true);
                TierraUIP.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                VientoUIP.SetActive(true);
            }else{
                return;
            }
            
        }else if(EventSystem.current.currentSelectedGameObject.name == "ArcanoE"){
            if(junit3.inUse==0){
                FuegoUI.SetActive(false);
                ElectricidadUI.SetActive(true);
                AguaUI.SetActive(false);
                TierraUI.SetActive(false);
                LuzOscuridadUI.SetActive(false);
                VientoUI.SetActive(false);
                FuegoUIP.SetActive(true);
                ElectricidadUIP.SetActive(false);
                AguaUIP.SetActive(true);
                TierraUIP.SetActive(true);
                LuzOscuridadUIP.SetActive(true);
                VientoUIP.SetActive(true);
            }else{
                return;
            }
           
        }else if(EventSystem.current.currentSelectedGameObject.name == "ArcanoLuzOscuridad"){
            if(junit5.inUse==0){
                FuegoUI.SetActive(false);
                ElectricidadUI.SetActive(false);
                AguaUI.SetActive(false);
                TierraUI.SetActive(false);
                LuzOscuridadUI.SetActive(true);
                VientoUI.SetActive(false);
                BotonesUI.SetActive(false);
                FuegoUIP.SetActive(true);
                ElectricidadUIP.SetActive(true);
                AguaUIP.SetActive(true);
                TierraUIP.SetActive(true);
                LuzOscuridadUIP.SetActive(false);
                VientoUIP.SetActive(true);
            }else{
                return;
            }
            
        }
    }

    IEnumerator PlayerAttack(){
        if(EventSystem.current.currentSelectedGameObject.name == "AtaqueT"){
            manaID = 1;
            isDead = enemyUnit.TakeDamage(playerUnit.Damage, junit6.element, junit6.Boosted);
            ArcanoMuerto = junit6.Life(manaID);
            enemyHUD.SetHP(enemyUnit.HpActual);
            TierraHUD.SetHP(junit6.HpActual);
            TierraHUD2.SetHP(junit6.HpActual);
            noMana = playerUnit.ReduxMana(manaID);
            playerHUD.SetMP(playerUnit.mana);
        }else if(EventSystem.current.currentSelectedGameObject.name == "AtaqueA"){
            manaID = 1;
            isDead = enemyUnit.TakeDamage(playerUnit.Damage, junit2.element, junit2.Boosted);
            ArcanoMuerto = junit2.Life(manaID);
            enemyHUD.SetHP(enemyUnit.HpActual);
            AguaHUD.SetHP(junit2.HpActual);
            AguaHUD2.SetHP(junit2.HpActual);
            noMana = playerUnit.ReduxMana(manaID);
            playerHUD.SetMP(playerUnit.mana);
        }else if(EventSystem.current.currentSelectedGameObject.name == "AtaqueF"){
            manaID = 1;
            isDead = enemyUnit.TakeDamage(playerUnit.Damage, junit.element, junit.Boosted);
            ArcanoMuerto = junit.Life(manaID);
            enemyHUD.SetHP(enemyUnit.HpActual);
            FuegoHUD.SetHP(junit.HpActual);
            FuegoHUD2.SetHP(junit.HpActual);
            noMana = playerUnit.ReduxMana(manaID);
            playerHUD.SetMP(playerUnit.mana);
        }else if(EventSystem.current.currentSelectedGameObject.name == "AtaqueV"){
            manaID = 1;
            isDead = enemyUnit.TakeDamage(playerUnit.Damage, junit4.element, junit4.Boosted);
            ArcanoMuerto = junit4.Life(manaID);
            enemyHUD.SetHP(enemyUnit.HpActual);
            VientoHUD.SetHP(junit4.HpActual);
            VientoHUD2.SetHP(junit4.HpActual);
            noMana = playerUnit.ReduxMana(manaID);
            playerHUD.SetMP(playerUnit.mana);
        }else if(EventSystem.current.currentSelectedGameObject.name == "AtaqueE"){
            manaID = 1;
            isDead = enemyUnit.TakeDamage(playerUnit.Damage, junit3.element, junit3.Boosted);
            ArcanoMuerto = junit3.Life(manaID);
            enemyHUD.SetHP(enemyUnit.HpActual);
            ElectricidadHUD.SetHP(junit3.HpActual);
            ElectricidadHUD2.SetHP(junit3.HpActual);
            noMana = playerUnit.ReduxMana(manaID);
            playerHUD.SetMP(playerUnit.mana);
        }
        if(noMana == true){
            state = BattleState.ENEMYTURN;
            closeUI();
        }
        dialogueText.text = "Has daniado al enemigo";
        if(playerUnit.mana != 0){
            changeTurn = false;
            yield return new WaitForSeconds(1f);
            if(isDead){
                state = BattleState.WON;
                EndBattle();
            }else if(ArcanoMuerto){
                state = BattleState.LOST;
                EndBattle();
            }else{
                
                PlayerTurn();
            }
        }else{
             yield return new WaitForSeconds(3f);
            if(isDead==true){
                state = BattleState.WON;
                EndBattle();
            }else if(ArcanoMuerto == true){
                state = BattleState.LOST;
                EndBattle();
            }else{
                StartCoroutine(enemyTurn());
            }
        }
    }
    IEnumerator PlayerDefense(){
        if(playerUnit.mana>1){
            if(junit6.inUse ==1){
                junit6.inUse = 0;
                ProteccionT.SetActive(false);
            }else if(junit2.inUse ==1){
                junit2.inUse = 0;
                ProteccionA.SetActive(false);
            }else if(junit.inUse ==1){
                junit.inUse = 0;
                ProteccionF.SetActive(false);
            }else if(junit3.inUse ==1){
                junit3.inUse = 0;
                ProteccionE.SetActive(false);
            }else if(junit4.inUse ==1){
                junit4.inUse = 0;
                ProteccionV.SetActive(false);
            }else if(junit5.inUse ==1){
                junit5.inUse = 0;
                ProteccionO.SetActive(false);
            }
            if(EventSystem.current.currentSelectedGameObject.name == "DefensaT"){
                manaID = 2;
                junit6.inUse = 1;
                playerUnit.ProteccionElemental(junit6.element);
                ProteccionT.SetActive(true);
                proteccionTurn = 3;
                dialogueText.text = "Proteccion elemental de tierra";
                noMana = playerUnit.ReduxMana(manaID);
                ArcanoMuerto = junit6.Life(manaID);
                playerHUD.SetMP(playerUnit.mana);
                TierraHUD.SetHP(junit6.HpActual);
                TierraHUD2.SetHP(junit6.HpActual);
                TierraUI.SetActive(false);
                TierraUIP.SetActive(true);
            }else if(EventSystem.current.currentSelectedGameObject.name == "DefensaA"){
                manaID = 2;
                junit2.inUse = 1;
                playerUnit.ProteccionElemental(junit2.element);
                ProteccionA.SetActive(true);
                proteccionTurn = 3;
                dialogueText.text = "Proteccion elemental de agua";
                noMana = playerUnit.ReduxMana(manaID);
                ArcanoMuerto = junit2.Life(manaID);
                playerHUD.SetMP(playerUnit.mana);
                AguaHUD.SetHP(junit2.HpActual);
                AguaHUD2.SetHP(junit2.HpActual);
                AguaUIP.SetActive(true);
                AguaUI.SetActive(false);
            }else if(EventSystem.current.currentSelectedGameObject.name == "DefensaF"){
                manaID = 2;
                junit.inUse = 1;
                playerUnit.ProteccionElemental(junit.element);
                ProteccionF.SetActive(true);
                proteccionTurn = 3;
                dialogueText.text = "Proteccion elemental de fuego";
                noMana = playerUnit.ReduxMana(manaID);
                ArcanoMuerto = junit.Life(manaID);
                playerHUD.SetMP(playerUnit.mana);
                FuegoHUD.SetHP(junit.HpActual);
                FuegoHUD2.SetHP(junit.HpActual);
                FuegoUIP.SetActive(true);
                FuegoUI.SetActive(false);
            }else if(EventSystem.current.currentSelectedGameObject.name == "DefensaV"){
                manaID = 2;
                junit4.inUse = 1;
                playerUnit.ProteccionElemental(junit4.element);
                ProteccionV.SetActive(true);
                proteccionTurn = 3;
                dialogueText.text = "Proteccion elemental de viento";
                noMana = playerUnit.ReduxMana(manaID);
                ArcanoMuerto = junit4.Life(manaID);
                playerHUD.SetMP(playerUnit.mana);
                VientoHUD.SetHP(junit4.HpActual);
                VientoHUD2.SetHP(junit4.HpActual);
                VientoUIP.SetActive(true);
                VientoUI.SetActive(false);
            }else if(EventSystem.current.currentSelectedGameObject.name == "DefensaE"){
                manaID = 2;
                junit3.inUse = 1;
                playerUnit.ProteccionElemental(junit3.element);
                ProteccionE.SetActive(true);
                proteccionTurn = 3;
                dialogueText.text = "Proteccion elemental de electricidad";
                noMana = playerUnit.ReduxMana(manaID);
                ArcanoMuerto = junit3.Life(manaID);
                playerHUD.SetMP(playerUnit.mana);
                ElectricidadHUD.SetHP(junit3.HpActual);
                ElectricidadHUD2.SetHP(junit3.HpActual);
                ElectricidadUIP.SetActive(true);
                ElectricidadUI.SetActive(false);
            }else if(EventSystem.current.currentSelectedGameObject.name == "SuperDefensa"){
                manaID = 2;
                junit5.inUse = 1;
                playerUnit.ProteccionElemental(junit5.element);
                ProteccionO.SetActive(true);
                proteccionTurn = 3;
                dialogueText.text = "Super proteccion";
                noMana = playerUnit.ReduxMana(manaID);
                ArcanoMuerto = junit5.Life(manaID);
                playerHUD.SetMP(playerUnit.mana);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
            }
            if(noMana == true){
                state = BattleState.ENEMYTURN;
                closeUI();
            }

            if(playerUnit.mana != 0){
                changeTurn = false;
                yield return new WaitForSeconds(1f);
                if(ArcanoMuerto){
                    state = BattleState.LOST;
                    EndBattle();
                }else{
                    
                    PlayerTurn();
                }
            }else{
                yield return new WaitForSeconds(3f);
                if(ArcanoMuerto){
                    state = BattleState.LOST;
                    EndBattle();
                }else{
                    StartCoroutine(enemyTurn());
                }
            }
        }else{
            mana.text = "Insuficiente mana ";
            yield return new WaitForSeconds(1f);
            mana.text = "";
            PlayerTurn();
        }
        
    }
    void closeUI(){
        FuegoUI.SetActive(false);
        ElectricidadUI.SetActive(false);
        AguaUI.SetActive(false);
        TierraUI.SetActive(false);
        LuzOscuridadUI.SetActive(false);
        VientoUI.SetActive(false);
        FuegoUIP.SetActive(true);
        ElectricidadUIP.SetActive(true);
        AguaUIP.SetActive(true);
        TierraUIP.SetActive(true);
        LuzOscuridadUIP.SetActive(true);
        VientoUIP.SetActive(true);
    }
    IEnumerator enemyTurn(){
        dialogueText.text = "Turno del enemigo";
        int limit = turnos % 3;
        if((limit) == 0){
            dialogueText.text = "Ataque fisico";
            EnemyAttack = 0;
            bool limitB = true;
            while(limitB == true){
                isDead = playerUnit.TakeDamage(enemyUnit.Damage);
                playerHUD.SetHP(playerUnit.HpActual);
                yield return new WaitForSeconds(1f);
                Debug.Log(playerUnit.HpActual);
                Debug.Log(EnemyAttack);
                if(isDead){
                    state = BattleState.LOST;
                    EndBattle();
                }
                EnemyAttack += 1;
                if(EnemyAttack == 4){
                    limitB = false;
                }
            }
            dialogueText.text = "Se aproxima ataque elemental";
            Debug.Log(playerUnit.HpActual);
        }else if((limit) == 1){
            dialogueText.text = "Ataque de fuego";
            if(junit.inUse == 1){
                if(pot3 == true){
                    isDead = playerUnit.ataqueElemental(enemyUnit.element, junit.Boosted, enemyUnit.MagicDamage);
                    Debug.Log("1");
                }else{
                    isDead = playerUnit.ataqueElemental(enemyUnit.element, junit.Boosted, enemyUnit.MagicDamage);
                    Debug.Log("2");
                }
            }else if(junit4.inUse == 1){
                if(pot5 == true){
                    isDead = playerUnit.ataqueElemental(enemyUnit.element, junit4.Boosted, enemyUnit.MagicDamage);
                    Debug.Log("3");
                }else{
                    isDead = playerUnit.ataqueElemental(enemyUnit.element, junit4.Boosted, enemyUnit.MagicDamage);
                    Debug.Log("4");
                }
            }else if(junit5.inUse == 1){
                    isDead = playerUnit.ataqueElemental(enemyUnit.element, junit5.Boosted,enemyUnit.MagicDamage);
            }else{
                isDead = playerUnit.TakeDamage(enemyUnit.MagicDamage);
                    Debug.Log("5");
            }
            Debug.Log(playerUnit.HpActual);
            playerHUD.SetHP(playerUnit.HpActual);
            yield return new WaitForSeconds(1.5f);
            dialogueText.text = "Se aproxima bomba de fuego!!!";
            if(isDead){
                state = BattleState.LOST;
                EndBattle();
            }
        }else if((limit) == 2){
            if(junit.inUse == 1){
                if(pot3 == true){
                    isDead = playerUnit.ataqueElemental(enemyUnit.element, junit.Boosted, enemyUnit.Bomba);
                    Debug.Log("1");
                }else{
                    isDead = playerUnit.ataqueElemental(enemyUnit.element, junit.Boosted, enemyUnit.Bomba);
                    Debug.Log("2");
                }
            }else if(junit4.inUse == 1){
                if(pot5 == true){
                    isDead = playerUnit.ataqueElemental(enemyUnit.element, junit4.Boosted, enemyUnit.Bomba);
                    Debug.Log("3");
                }else{
                    isDead = playerUnit.ataqueElemental(enemyUnit.element, junit4.Boosted, enemyUnit.Bomba);
                    Debug.Log("4");
                }
            }else if(junit5.inUse == 1){
                    isDead = playerUnit.ataqueElemental(enemyUnit.element, junit5.Boosted,enemyUnit.Bomba);
            }else{
                isDead = playerUnit.TakeDamage(enemyUnit.Bomba);
                    Debug.Log("5");
            }
            Debug.Log(playerUnit.HpActual);
            playerHUD.SetHP(playerUnit.HpActual);
            yield return new WaitForSeconds(1.5f);
            if(isDead){
                state = BattleState.LOST;
                EndBattle();
            }
            if(state != BattleState.LOST){
                dialogueText.text = "El enemigo se curo";
                enemyUnit.Heal();
                enemyHUD.SetHP(enemyUnit.HpActual);
                yield return new WaitForSeconds(1.5f);
                dialogueText.text = "Ataque fisico";
                EnemyAttack = 0;
                while(EnemyAttack != 2){
                    isDead = playerUnit.TakeDamage(enemyUnit.Damage);
                    playerHUD.SetHP(playerUnit.HpActual);
                    yield return new WaitForSeconds(1.5f);
                    if(isDead){
                        state = BattleState.LOST;
                        EndBattle();
                    }
                    EnemyAttack += 1;
                }
                dialogueText.text = "Se aproxima ataque fisico";
            }
        }
        yield return new WaitForSeconds(3f);
        if(state != BattleState.LOST){
            state = BattleState.PLAYERTURN;
            turnos = turnos + 1;
            Turnos.text = "Turno " + turnos;
            playerUnit.mana = 3;
            noMana = false;
            playerHUD.SetMP(playerUnit.mana);
            proteccionTurn = proteccionTurn - 1;
            if(pot1 == true){ 
                pot1 = junit3.potenciados();
                ElectricidadHUD2.SetMP(junit3.potenciado);
                if(junit3.potenciado == 0){ 
                    ElectricidadF.SetActive(false);
                    junit3.quitarBoost();
                }
            }
            if(pot2 == true){ 
                pot2 = junit2.potenciados();
                AguaHUD2.SetMP(junit2.potenciado); 
                if(junit2.potenciado == 0){ 
                    AguaF.SetActive(false);
                    junit2.quitarBoost();
                }
            } 
            if(pot3 == true){ 
                pot3 = junit.potenciados();
                FuegoHUD2.SetMP(junit.potenciado);
                if(junit.potenciado == 0){ 
                    FuegoF.SetActive(false);
                    junit.quitarBoost();
                }
            }
            if(pot4 == true){ 
                pot4 = junit6.potenciados();
                TierraHUD2.SetMP(junit6.potenciado);
                if(junit6.potenciado == 0){ 
                    TierraF.SetActive(false);
                    junit6.quitarBoost();
                }
            }
            if(pot5 == true){ 
                pot5 = junit4.potenciados();
                VientoHUD2.SetMP(junit4.potenciado);
                if(junit4.potenciado == 0){ 
                    VientoF.SetActive(false);
                    junit4.quitarBoost();
                }
            }
            if(pot6 == true){
                pot6 = junit5.potenciados();
                LuzOscuridadHUD2.SetMP(junit5.potenciado);
                if(junit5.potenciado == 0){ 
                    LuzOscuridadF.SetActive(false);
                    junit5.quitarBoost();
                    SuperBotonHeal.SetActive(false);
                    BotonHeal.SetActive(true);
                    Robar.SetActive(true);
                    Defensa.SetActive(false);
                }
            }
            
            if(proteccionTurn == 0){
                ProteccionT.SetActive(false);
                ProteccionA.SetActive(false);
                ProteccionF.SetActive(false);
                ProteccionO.SetActive(false);
                ProteccionE.SetActive(false);
                ProteccionV.SetActive(false);
                junit.inUse = 0;
                junit2.inUse = 0;
                junit3.inUse = 0;
                junit4.inUse = 0;
                junit5.inUse = 0;
                junit6.inUse = 0;
                playerUnit.ProteccionElemental(proteccionTurn);
            }
            PlayerTurn();
        }
    }
    void EndBattle(){
        if(state == BattleState.WON){
            dialogueText.text = "Ganaste";
        }else if(state == BattleState.LOST){
            dialogueText.text = "Perdiste";
        }
    }
    IEnumerator DarkHeal(){
        if(EventSystem.current.currentSelectedGameObject.name == "VitalidadE"){
                manaID = 1;
                ArcanoMuerto = junit3.Life(manaID);
                junit5.Heal(manaID);
                ElectricidadHUD.SetHP(junit3.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                ElectricidadHUD2.SetHP(junit3.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
            playerHUD.SetMP(playerUnit.mana);
        }else if (EventSystem.current.currentSelectedGameObject.name == "VitalidadP"){
                manaID = 1;
                ArcanoMuerto = playerUnit.Life(manaID);
                junit5.Heal(manaID);
                playerHUD.SetHP(playerUnit.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
        }else if (EventSystem.current.currentSelectedGameObject.name == "VitalidadF"){
                manaID = 1;
                ArcanoMuerto = junit.Life(manaID);
                junit5.Heal(manaID);
                FuegoHUD.SetHP(junit.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                FuegoHUD2.SetHP(junit.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
        }else if (EventSystem.current.currentSelectedGameObject.name == "VitalidadT"){
                manaID = 1;
                ArcanoMuerto = junit6.Life(manaID);
                junit5.Heal(manaID);
                TierraHUD.SetHP(junit6.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                TierraHUD2.SetHP(junit6.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
        }else if (EventSystem.current.currentSelectedGameObject.name == "VitalidadA"){
                manaID = 1;
                ArcanoMuerto = junit2.Life(manaID);
                junit5.Heal(manaID);
                AguaHUD.SetHP(junit2.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                AguaHUD2.SetHP(junit2.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
        }else if (EventSystem.current.currentSelectedGameObject.name == "VitalidadV"){
                manaID = 1;
                ArcanoMuerto = junit4.Life(manaID);
                junit5.Heal(manaID);
                ElectricidadHUD.SetHP(junit4.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                ElectricidadHUD2.SetHP(junit4.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
        }
        dialogueText.text = ("Has curado al arcano Oscuro");
        if(noMana == true){
            state = BattleState.ENEMYTURN;
            closeUI();
        }
        if(playerUnit.mana != 0){
            changeTurn = false;
            yield return new WaitForSeconds(1f);
            if(ArcanoMuerto){
                    state = BattleState.LOST;
                    EndBattle();
            }else{
                    
                PlayerTurn();
            }
        }else{
            yield return new WaitForSeconds(3f);
            if(ArcanoMuerto){
                state = BattleState.LOST;
                EndBattle();
            }else{
                StartCoroutine(enemyTurn());
            }
        }
        
    }
    IEnumerator BoostArcano(){
        if(playerUnit.mana == 3){
            if(EventSystem.current.currentSelectedGameObject.name == "FortalecerE"){
                manaID = 3; 
                pot1 = true;
                junit3.SetBoost();
                junit3.SetBoostBool();
                ArcanoMuerto = junit5.Life(manaID);
                ElectricidadHUD2.SetMP(junit3.potenciado);
                ElectricidadF.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                playerHUD.SetMP(playerUnit.mana);
                dialogueText.text = ("Se ha potenciado el arcano de electricidad"); 
                
            }else if(EventSystem.current.currentSelectedGameObject.name == "FortalecerA"){
                manaID = 3; 
                pot2 = true;
                junit2.SetBoost();
                junit2.SetBoostBool();
                ArcanoMuerto = junit5.Life(manaID);
                AguaHUD2.SetMP(junit2.potenciado);
                AguaF.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                playerHUD.SetMP(playerUnit.mana);  
                dialogueText.text = ("Se ha potenciado el arcano de agua"); 


            }else if(EventSystem.current.currentSelectedGameObject.name == "FortalecerF"){
                manaID = 3; 
                pot3 = true;
                junit.SetBoost();
                junit.SetBoostBool();
                ArcanoMuerto = junit5.Life(manaID);
                FuegoHUD2.SetMP(junit.potenciado);
                FuegoF.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                playerHUD.SetMP(playerUnit.mana); 
                dialogueText.text = ("Se ha potenciado el arcano de fuego"); 

                
            }else if(EventSystem.current.currentSelectedGameObject.name == "FortalecerT"){
                manaID = 3; 
                pot4 = true;
                junit6.SetBoost();
                junit6.SetBoostBool();
                ArcanoMuerto = junit5.Life(manaID);
                TierraHUD2.SetMP(junit6.potenciado);
                TierraF.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                playerHUD.SetMP(playerUnit.mana); 
                dialogueText.text = ("Se ha potenciado el arcano de tirra"); 

                
            }else if(EventSystem.current.currentSelectedGameObject.name == "FortalecerV"){
                manaID = 3; 
                pot5 = true;
                junit4.SetBoost();
                junit4.SetBoostBool();
                ArcanoMuerto = junit5.Life(manaID);
                VientoHUD2.SetMP(junit4.potenciado);
                VientoF.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                playerHUD.SetMP(playerUnit.mana); 
                dialogueText.text = ("Se ha potenciado el arcano de viento"); 
            }else if(EventSystem.current.currentSelectedGameObject.name == "FortalecerO"){
                manaID = 3;
                pot6 = true;
                junit5.SetBoost();
                junit5.SetBoostBool();
                ArcanoMuerto = junit5.Life(manaID);
                LuzOscuridadHUD2.SetMP(junit5.potenciado);
                LuzOscuridadF.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                playerHUD.SetMP(playerUnit.mana);
                SuperBotonHeal.SetActive(true);
                BotonHeal.SetActive(false);
                Robar.SetActive(false);
                Defensa.SetActive(true);
                dialogueText.text = ("Se ha potenciado el arcano de Lux oscuridad");
            }
            if(noMana == true){
                closeUI();
                state = BattleState.ENEMYTURN;
            }
            yield return new WaitForSeconds(3f);
            if(ArcanoMuerto){
                state = BattleState.LOST;
                EndBattle();
            }else{
                StartCoroutine(enemyTurn());
            }
        }else{
            mana.text = "Insuficiente mana ";
            yield return new WaitForSeconds(1f);
            mana.text = "";
            PlayerTurn();
        }
    }
    IEnumerator SuperDuper(){
        if(playerUnit.mana > 1){
            manaID = 2;
            dialogueText.text = ("Robaste la vitalidad del enemigo");
            isDead = enemyUnit.SuperHeal();
            playerUnit.Heal();
            junit.Heal(manaID);
            junit2.Heal(manaID);
            junit3.Heal(manaID);
            junit4.Heal(manaID);
            junit5.Heal(manaID);
            junit6.Heal(manaID);
            enemyHUD.SetHP(enemyUnit.HpActual);
            playerHUD.SetHP(playerUnit.HpActual);
            ElectricidadHUD.SetHP(junit3.HpActual);
            ElectricidadHUD2.SetHP(junit3.HpActual);
            LuzOscuridadHUD.SetHP(junit5.HpActual);
            LuzOscuridadHUD2.SetHP(junit5.HpActual);
            FuegoHUD.SetHP(junit3.HpActual);
            FuegoHUD2.SetHP(junit3.HpActual);
            VientoHUD.SetHP(junit5.HpActual);
            VientoHUD2.SetHP(junit5.HpActual);
            TierraHUD.SetHP(junit3.HpActual);
            TierraHUD.SetHP(junit3.HpActual);
            AguaHUD.SetHP(junit5.HpActual);
            AguaHUD.SetHP(junit5.HpActual);
            LuzOscuridadUI.SetActive(false);
            LuzOscuridadUIP.SetActive(true);
            noMana = playerUnit.ReduxMana(manaID);
            playerHUD.SetMP(playerUnit.mana);
            yield return new WaitForSeconds(1f);
            dialogueText.text = ("Has curado a todos los aliados");
            if(noMana == true){
                closeUI();
                state = BattleState.ENEMYTURN;
            }
            if(playerUnit.mana != 0){
                changeTurn = false;
                yield return new WaitForSeconds(1f);
                if(isDead){
                        state = BattleState.WON;
                        EndBattle();
                }else{
                        
                    PlayerTurn();
                }
            }else{
                yield return new WaitForSeconds(3f);
                if(isDead){
                    state = BattleState.WON;
                    EndBattle();
                }else{
                    StartCoroutine(enemyTurn());
                }
            }  
        }else{
            mana.text = "Insuficiente mana ";
            yield return new WaitForSeconds(1f);
            mana.text = "";
            PlayerTurn();
        }
    }
    IEnumerator PlayerHeal(){
       if(EventSystem.current.currentSelectedGameObject.name == "VitalidadE"){
           if(botonID == 1){
                manaID = 1;
                ArcanoMuerto = junit3.Life(manaID);
                playerUnit.Heal();
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                playerHUD.SetHP(playerUnit.HpActual);
                ElectricidadHUD.SetHP(junit3.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                ElectricidadHUD2.SetHP(junit3.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 2){
                manaID = 1;
                ArcanoMuerto = junit3.Life(manaID);
                junit6.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                TierraHUD.SetHP(junit6.HpActual);
                TierraHUD2.SetHP(junit6.HpActual);
                ElectricidadHUD.SetHP(junit3.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                ElectricidadHUD2.SetHP(junit3.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 3){
                manaID = 1;
                ArcanoMuerto = junit3.Life(manaID);
                junit4.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                VientoHUD.SetHP(junit4.HpActual);
                VientoHUD2.SetHP(junit4.HpActual);
                ElectricidadHUD.SetHP(junit3.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                ElectricidadHUD2.SetHP(junit3.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 4){
                manaID = 1;
                ArcanoMuerto = junit3.Life(manaID);
                junit.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                FuegoHUD.SetHP(junit.HpActual);
                FuegoHUD2.SetHP(junit.HpActual);
                ElectricidadHUD.SetHP(junit3.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                ElectricidadHUD2.SetHP(junit3.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 6){
                manaID = 1;
                ArcanoMuerto = junit3.Life(manaID);
                junit2.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                AguaHUD.SetHP(junit2.HpActual);
                AguaHUD2.SetHP(junit2.HpActual);
                ElectricidadHUD.SetHP(junit3.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                ElectricidadHUD2.SetHP(junit3.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }
       }else if(EventSystem.current.currentSelectedGameObject.name == "VitalidadP"){
           if(botonID == 5){
                manaID = 1;
                ArcanoMuerto = playerUnit.Life(manaID);
                junit3.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                ElectricidadHUD.SetHP(junit3.HpActual);
                ElectricidadHUD2.SetHP(junit3.HpActual);
                playerHUD.SetHP(playerUnit.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 2){
                manaID = 1;
                ArcanoMuerto = playerUnit.Life(manaID);
                junit6.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                TierraHUD.SetHP(junit6.HpActual);
                TierraHUD2.SetHP(junit6.HpActual);
                playerHUD.SetHP(playerUnit.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 3){
                manaID = 1;
                ArcanoMuerto = playerUnit.Life(manaID);
                junit4.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                VientoHUD.SetHP(junit4.HpActual);
                VientoHUD2.SetHP(junit4.HpActual);
                playerHUD.SetHP(playerUnit.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 4){
                manaID = 1;
                ArcanoMuerto = playerUnit.Life(manaID);
                junit.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                FuegoHUD.SetHP(junit.HpActual);
                FuegoHUD2.SetHP(junit.HpActual);
                playerHUD.SetHP(playerUnit.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 6){
                manaID = 1;
                ArcanoMuerto = playerUnit.Life(manaID);
                junit2.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                AguaHUD.SetHP(junit2.HpActual);
                AguaHUD2.SetHP(junit2.HpActual);
                playerHUD.SetHP(playerUnit.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }
       }else if(EventSystem.current.currentSelectedGameObject.name == "VitalidadA"){
           if(botonID == 1){
                manaID = 1;
                ArcanoMuerto = junit2.Life(manaID);
                playerUnit.Heal();
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                playerHUD.SetHP(playerUnit.HpActual);
                AguaHUD.SetHP(junit2.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                AguaHUD2.SetHP(junit2.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 2){
                manaID = 1;
                ArcanoMuerto = junit2.Life(manaID);
                junit6.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                TierraHUD.SetHP(junit6.HpActual);
                TierraHUD2.SetHP(junit6.HpActual);
                AguaHUD.SetHP(junit2.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                AguaHUD2.SetHP(junit2.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 3){
                manaID = 1;
                ArcanoMuerto = junit2.Life(manaID);
                junit4.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                VientoHUD.SetHP(junit4.HpActual);
                VientoHUD2.SetHP(junit4.HpActual);
                AguaHUD.SetHP(junit2.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                AguaHUD2.SetHP(junit2.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 4){
                manaID = 1;
                ArcanoMuerto = junit2.Life(manaID);
                junit.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                FuegoHUD.SetHP(junit.HpActual);
                FuegoHUD2.SetHP(junit.HpActual);
                AguaHUD.SetHP(junit2.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                AguaHUD2.SetHP(junit2.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 5){
                manaID = 1;
                ArcanoMuerto = junit2.Life(manaID);
                junit3.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                ElectricidadHUD.SetHP(junit3.HpActual);
                ElectricidadHUD2.SetHP(junit3.HpActual);
                AguaHUD.SetHP(junit2.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                AguaHUD2.SetHP(junit2.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }
       }else if(EventSystem.current.currentSelectedGameObject.name == "VitalidadF"){
           if(botonID == 1){
                manaID = 1;
                ArcanoMuerto = junit.Life(manaID);
                playerUnit.Heal();
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                playerHUD.SetHP(playerUnit.HpActual);
                FuegoHUD.SetHP(junit.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                FuegoHUD2.SetHP(junit.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 2){
                manaID = 1;
                ArcanoMuerto = junit.Life(manaID);
                junit6.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                TierraHUD.SetHP(junit6.HpActual);
                TierraHUD2.SetHP(junit6.HpActual);
                FuegoHUD.SetHP(junit.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                FuegoHUD2.SetHP(junit.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 3){
                manaID = 1;
                ArcanoMuerto = junit.Life(manaID);
                junit4.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                VientoHUD.SetHP(junit4.HpActual);
                VientoHUD2.SetHP(junit4.HpActual);
                FuegoHUD.SetHP(junit.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                FuegoHUD2.SetHP(junit.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 5){
                manaID = 1;
                ArcanoMuerto = junit.Life(manaID);
                junit3.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                ElectricidadHUD.SetHP(junit3.HpActual);
                ElectricidadHUD2.SetHP(junit3.HpActual);
                FuegoHUD.SetHP(junit.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                FuegoHUD2.SetHP(junit.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 6){
                manaID = 1;
                ArcanoMuerto = junit.Life(manaID);
                junit2.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                AguaHUD.SetHP(junit2.HpActual);
                AguaHUD2.SetHP(junit2.HpActual);
                FuegoHUD.SetHP(junit.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                FuegoHUD2.SetHP(junit.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }
       }else if(EventSystem.current.currentSelectedGameObject.name == "VitalidadV"){
           if(botonID == 1){
                manaID = 1;
                ArcanoMuerto = junit4.Life(manaID);
                playerUnit.Heal();
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                playerHUD.SetHP(playerUnit.HpActual);
                VientoHUD.SetHP(junit4.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                VientoHUD2.SetHP(junit4.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 2){
                manaID = 1;
                ArcanoMuerto = junit4.Life(manaID);
                junit6.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                TierraHUD.SetHP(junit6.HpActual);
                TierraHUD2.SetHP(junit6.HpActual);
                VientoHUD.SetHP(junit4.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                VientoHUD2.SetHP(junit4.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 5){
                manaID = 1;
                ArcanoMuerto = junit4.Life(manaID);
                junit3.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                ElectricidadHUD.SetHP(junit3.HpActual);
                ElectricidadHUD2.SetHP(junit3.HpActual);
                VientoHUD.SetHP(junit4.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                VientoHUD2.SetHP(junit4.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 4){
                manaID = 1;
                ArcanoMuerto = junit4.Life(manaID);
                junit.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                FuegoHUD.SetHP(junit.HpActual);
                FuegoHUD2.SetHP(junit.HpActual);
                VientoHUD.SetHP(junit4.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                VientoHUD2.SetHP(junit4.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 6){
                manaID = 1;
                ArcanoMuerto = junit4.Life(manaID);
                junit2.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                AguaHUD.SetHP(junit2.HpActual);
                AguaHUD2.SetHP(junit2.HpActual);
                VientoHUD.SetHP(junit4.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                VientoHUD2.SetHP(junit4.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                LuzOscuridadUIP.SetActive(true);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }

       }else if(EventSystem.current.currentSelectedGameObject.name == "VitalidadT"){
           if(botonID == 1){
                manaID = 1;
                ArcanoMuerto = junit6.Life(manaID);
                playerUnit.Heal();
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                playerHUD.SetHP(playerUnit.HpActual);
                TierraHUD.SetHP(junit6.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                TierraHUD2.SetHP(junit6.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 5){
                manaID = 1;
                ArcanoMuerto = junit6.Life(manaID);
                junit3.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                ElectricidadHUD.SetHP(junit3.HpActual);
                ElectricidadHUD2.SetHP(junit3.HpActual);
                TierraHUD.SetHP(junit6.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                TierraHUD2.SetHP(junit6.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 3){
                manaID = 1;
                ArcanoMuerto = junit6.Life(manaID);
                junit4.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                VientoHUD.SetHP(junit4.HpActual);
                VientoHUD2.SetHP(junit4.HpActual);
                TierraHUD.SetHP(junit6.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                TierraHUD2.SetHP(junit6.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 4){
                manaID = 1;
                ArcanoMuerto = junit6.Life(manaID);
                junit.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                FuegoHUD.SetHP(junit.HpActual);
                FuegoHUD2.SetHP(junit.HpActual);
                TierraHUD.SetHP(junit6.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                TierraHUD2.SetHP(junit6.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }else if(botonID == 6){
                manaID = 1;
                ArcanoMuerto = junit6.Life(manaID);
                junit2.Heal(manaID);
                ArcanoOscutoMuerto = junit5.ArcanoOscuro(manaID);
                AguaHUD.SetHP(junit2.HpActual);
                AguaHUD2.SetHP(junit2.HpActual);
                TierraHUD.SetHP(junit6.HpActual);
                LuzOscuridadHUD.SetHP(junit5.HpActual);
                TierraHUD2.SetHP(junit6.HpActual);
                LuzOscuridadHUD2.SetHP(junit5.HpActual);
                LuzOscuridadUI.SetActive(false);
                noMana = playerUnit.ReduxMana(manaID);
                playerHUD.SetMP(playerUnit.mana);
           }
       }
        dialogueText.text = ("Has curado a un aliado");
        if(noMana == true){
            state = BattleState.ENEMYTURN;
            closeUI();
        }
        if(playerUnit.mana != 0){
            changeTurn = false;
            yield return new WaitForSeconds(1f);
            if(ArcanoOscutoMuerto || ArcanoMuerto){
                    state = BattleState.LOST;
                    EndBattle();
            }else{
                        
                PlayerTurn();
            }
        }else{
            yield return new WaitForSeconds(3f);
            if(ArcanoOscutoMuerto || ArcanoMuerto){
                state = BattleState.LOST;
                EndBattle();
            }else{
                StartCoroutine(enemyTurn());
            }
        }  
    }

    public void PlayerTurn()
    {
        dialogueText.text = "Has una accion";
        changeTurn = true;
    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        if (changeTurn == false){
            return;
        }
        if(playerUnit.mana > 0){
            StartCoroutine(PlayerAttack());    
        }else{
            return;
        }
        
    }
    public void idButton(){
        if(EventSystem.current.currentSelectedGameObject.name == "Jugador"){
            botonID = 1;
            CurarUI.SetActive(true);
            Botone3.SetActive(false);
            Botone2.SetActive(true);
            Botone1.SetActive(true);
            Botone4.SetActive(true);
            Botone5.SetActive(true);
            Botone6.SetActive(true);
        }else if(EventSystem.current.currentSelectedGameObject.name == "Tierra"){
            botonID = 2;
            CurarUI.SetActive(true);
            Botone5.SetActive(false);
            Botone2.SetActive(true);
            Botone3.SetActive(true);
            Botone4.SetActive(true);
            Botone1.SetActive(true);
            Botone6.SetActive(true);
        }else if(EventSystem.current.currentSelectedGameObject.name == "Viento"){
            botonID = 3;
            CurarUI.SetActive(true);
            Botone2.SetActive(false);
            Botone1.SetActive(true);
            Botone3.SetActive(true);
            Botone4.SetActive(true);
            Botone5.SetActive(true);
            Botone6.SetActive(true);
        }else if(EventSystem.current.currentSelectedGameObject.name == "Fuego"){
            botonID = 4;
            CurarUI.SetActive(true);
            Botone6.SetActive(false);
            Botone2.SetActive(true);
            Botone3.SetActive(true);
            Botone4.SetActive(true);
            Botone5.SetActive(true);
            Botone1.SetActive(true);
        }else if(EventSystem.current.currentSelectedGameObject.name == "Electricidad"){
            botonID = 5;
            CurarUI.SetActive(true);
            Botone1.SetActive(false);
            Botone2.SetActive(true);
            Botone3.SetActive(true);
            Botone4.SetActive(true);
            Botone5.SetActive(true);
            Botone6.SetActive(true);
        }else if(EventSystem.current.currentSelectedGameObject.name == "Agua"){
            botonID = 6;
            CurarUI.SetActive(true);
            Botone4.SetActive(false);
            Botone2.SetActive(true);
            Botone3.SetActive(true);
            Botone1.SetActive(true);
            Botone5.SetActive(true);
            Botone6.SetActive(true);
        }
    }
    public void OnHealButton(){
        StartCoroutine(PlayerHeal());
    }
    public void SelectHUDbutton(){
        if (state != BattleState.PLAYERTURN)
            return;
        GameUI();
    }
    public void ElementalDefense(){
        if (state != BattleState.PLAYERTURN)
            return;
        if (changeTurn == false){
            return;
        }
        StartCoroutine(PlayerDefense());
    }
    public void Boosted(){
        if (state != BattleState.PLAYERTURN)
            return;
        if (changeTurn == false){
            return;
        }
        StartCoroutine(BoostArcano());
    }
    public void StealLife(){
        StartCoroutine(DarkHeal());
    }
    public void SuperHeal(){
        StartCoroutine(SuperDuper());
    }
}
