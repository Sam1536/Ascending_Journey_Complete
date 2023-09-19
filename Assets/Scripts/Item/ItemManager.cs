using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SamEbac.Core.Singleton;
using TMPro;


public class ItemManager : Singleton<ItemManager>
{
    public SOint coins;
    public TextMeshProUGUI coinsCount;

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        coins.value = 0;
        UpdateCoins();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateCoins();
    }

    private void UpdateCoins()
    {
       // coinsCount.text = coins.value.ToString();
    }
}
