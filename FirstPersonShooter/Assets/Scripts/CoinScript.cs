using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        CoinScore.coinAmount += 1;
        Destroy(gameObject);
        Debug.Log("Coin picked");
    }
}
