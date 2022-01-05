using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    //public GameObject textObject;
    public GameObject shopObject;
    // Start is called before the first frame update
    void Start()
    {
        //textObject.SetActive(false);
        shopObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        /*
        if (other.tag == "Player")
        {
            Debug.Log("player hit shop");
            textObject.SetActive(true);
        }
        */

        /*
        if (Input.GetKeyDown("b"))
        {
            textObject.SetActive(false);
            Debug.Log("B key Pressed");
            shopObject.SetActive(true);
        }
        */

        if (other.CompareTag("Player"))
        {
            //textObject.SetActive(false);           
            shopObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //textObject.SetActive(false);
        shopObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
