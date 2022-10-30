using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public int coste;
    public Items.ItemType tipo;
   
    Battlesystem battlesystem;
    UI_Shop tienda;



    private void Start()
    {
        battlesystem = FindObjectOfType<Battlesystem>();
    }
    public void Buy()
    {
        if (coste <= battlesystem.coins)
        {
            battlesystem.coins = battlesystem.coins - coste;
            print(tipo);
            
            var player = battlesystem.playerGO.GetComponent<Unit>();

            switch (tipo)
            {
                case Items.ItemType.Sword:
                    player.dmg = 15;
                    player.dmg = player.fuerza * 100 / 50f + player.dmg;
                    player.currentWeapon = Unit.TiposArmas.SWORD;
                    break;
                case Items.ItemType.BasicDagger:
                    player.dmg = 5;
                    player.dmg = player.destreza * 100 / 100f + player.dmg;
                    player.currentWeapon = Unit.TiposArmas.BASIC_DAGGER;
                    break;
                case Items.ItemType.Longbow:
                    player.dmg = 20;
                    player.dmg = player.destreza * 100 / 75f + player.dmg;
                    player.currentWeapon = Unit.TiposArmas.LONGBOW;
                    break;
                case Items.ItemType.BattleAxe:
                    player.dmg = 25;
                    player.dmg = player.fuerza * 100 / 75f + player.dmg;
                    player.currentWeapon = Unit.TiposArmas.BATTLE_AXE;
                    break;
                case Items.ItemType.FireBomb:
                    battlesystem.bombs++;
                    break;
                case Items.ItemType.VenenousKnife:
                    battlesystem.venenousKnife++;
                    break;

            }
        }
    }
    
    
}
