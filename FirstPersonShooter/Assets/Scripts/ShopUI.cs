using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    //public GameObject textObject;
    public GameObject shopObject;
    private bool inShop = false;
    // Start is called before the first frame update
    void Start()
    {
        //textObject.SetActive(false);
        shopObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inShop = true;
            shopObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inShop = false;
        shopObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!inShop) return;

        if (Input.GetKeyDown(KeyCode.L)) {
            TryBuyAmmo();
        }else if (Input.GetKeyDown(KeyCode.K))
        {
            TryBuyHealth();
        }
    }

    private void TryBuyHealth()
    {
        if (CoinScore.coinAmount >= 35) {
            CoinScore.coinAmount -= 35;
            FindObjectOfType<PlayerHealth>().HealPlayer(50);
        }
    }

    private void TryBuyAmmo()
    {
        if (CoinScore.coinAmount >= 35)
        {
            CoinScore.coinAmount -= 35;
            var player = FindObjectOfType<AutomaticGunScriptLPFP>();
            player.maxAmmo += 70;
            player.totalAmmoText.text = player.maxAmmo.ToString();
        }
    }
}
