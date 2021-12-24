using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private GameObject nextToBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Collision with:" + other.gameObject.name);
        ShopUI.Canvas.GetComponentInChildren<ShopUI>().ShowBottomMenu(true, "Press E to collect box");
        nextToBox = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        print("Exiting Collision");
        ShopUI.Canvas.GetComponentInChildren<ShopUI>().ShowBottomMenu(false);
        nextToBox = null;
    }
}
