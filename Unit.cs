using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Unit : MonoBehaviour
{
    public enum TiposArmas { SWORD, BASIC_DAGGER, LONGBOW, BATTLE_AXE }
    public enum TiposEscudos { NOSHIELD, SMALLSHIELD, MEDIUMSHIELD, BIGSHIELD }

    public string unitName;
    public int level;

    public float dmg;
    public float fuerza, destreza, constitucion, inteligencia;
    public float defense;

    public float maxHp;
    public float currentHp;

    public TiposArmas currentWeapon;
    public TiposEscudos currentShield;

    private void Start()
    {
        switch (currentWeapon)
        {
            case TiposArmas.SWORD:
                dmg = 15;
                dmg = fuerza * 100 /50f + dmg;
                break;
            case TiposArmas.BASIC_DAGGER:
                dmg = 5;
                dmg = destreza * 100 / 100f+dmg;
                break;
            case TiposArmas.LONGBOW:
                dmg = 20;
                dmg = destreza * 100 / 75f + dmg;
                break;
            case TiposArmas.BATTLE_AXE:
                dmg = 25;
                dmg = fuerza * 100 / 75f + dmg;
                break;

        }
        switch (currentShield)
        {
            case TiposEscudos.NOSHIELD:
                defense = 0;
                break;
            case TiposEscudos.SMALLSHIELD:
                defense = 25;
                break;
            case TiposEscudos.MEDIUMSHIELD:
                defense = 50;
                break;
            case TiposEscudos.BIGSHIELD:
                defense = 100;
                break;
        }
        
    }


    public bool TakeDamage(float dmg)
    {
        
        currentHp -= dmg;
        if (currentHp <= 0)
        {
            return true;
        }
        else return false;
    }
    public void Heal(float amount)
    {
        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
    

}

