using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{

    public static GameObject Canvas;

    void Start()
    {
        Canvas = GameObject.Find("Canvas");
    }

    void Update()
    {

    }

    private void OnEnable()
    {
        InputManager.KeyDown += ObserverKeyPress;
    }

    public void ObserverKeyPress(KeyCode keyCode)
    {
        if (keyCode == KeyCode.Tab)
        {
            ShowToggleInventory();
        }
    }

    private void OnDisable()
    {
        InputManager.KeyDown -= ObserverKeyPress;
    }
    private void ShowToggleInventory()
    {
        //ShowToggleInventory inside InventoryManager
        GameObject.Find("Canvas").GetComponentInChildren<InventoryManager>().ShowToggleInventory();
    }

}
