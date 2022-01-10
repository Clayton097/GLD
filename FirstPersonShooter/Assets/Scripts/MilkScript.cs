using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        MilkScore.milkAmount += 1;
        Destroy(gameObject);
        Debug.Log("Milk picked");
    }
}
