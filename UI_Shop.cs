using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Shop : MonoBehaviour
{
   public Transform container,continueButton;
    public Transform shopItemTemplate;
    public Battlesystem battlesystem;
   
    private void Awake()
    {      
        container.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
    }
    
    private void Start()
    {
        CreateItemButton("Basic dagger", Items.GetCost(Items.ItemType.BasicDagger), 0,Items.ItemType.BasicDagger);
        CreateItemButton("Battle axe", Items.GetCost(Items.ItemType.BattleAxe), 1, Items.ItemType.BattleAxe);
        CreateItemButton("Longbow", Items.GetCost(Items.ItemType.Longbow), 2, Items.ItemType.Longbow);
        CreateItemButton("Sword", Items.GetCost(Items.ItemType.Sword), 3, Items.ItemType.Sword);
        CreateItemButton("Fire bomb", Items.GetCost(Items.ItemType.FireBomb), 4, Items.ItemType.FireBomb);
        CreateItemButton("Venenous knife", Items.GetCost(Items.ItemType.VenenousKnife), 5, Items.ItemType.VenenousKnife);
        CreateItemButton("More stats", Items.GetCost(Items.ItemType.MoreStats), 6, Items.ItemType.MoreStats);
        CreateItemButton("Small shield", Items.GetCost(Items.ItemType.SmallShield), 7, Items.ItemType.SmallShield);
        CreateItemButton("Medium shield", Items.GetCost(Items.ItemType.MediumShield), 8, Items.ItemType.MediumShield);
        CreateItemButton("Big shield", Items.GetCost(Items.ItemType.BigShield), 9, Items.ItemType.BigShield);

    }
    private void CreateItemButton(string itemName, int itemCost,int positionIndex,Items.ItemType type)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.GetComponent<BuyItem>().coste = itemCost;
        shopItemTransform.GetComponent<BuyItem>().tipo = type;
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("NameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("PriceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        //sprites here

    }
    public void Continue()
    {
        container.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        battlesystem.coinsText.text = "Coins: " + battlesystem.coins;
       
        

    }
    
}
