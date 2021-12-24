using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Tooltip("Shop Menu Panel")]
    public GameObject ShopMenu;
    public static GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        ShopMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowBottomMenu(bool showMenu, string text = "")
    {
        ShopMenu.SetActive(showMenu);
        ShopMenu.GetComponentInChildren<Text>().text = text;
    }

    /*
    private void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            Debug.Log("tajba hara");

        }
    }
    */
    
}
