using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [Tooltip("Show inventory GUI")]
    public bool showInventory = false;
    private Animator animator;

    [Tooltip("Items Selection Panel")]
    public GameObject itemsSelectionPanel;
    // Start is called before the first frame update
    void Start()
    {
        animator = itemsSelectionPanel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowToggleInventory()
    {
        if (showInventory == false)
        {
            showInventory = true;
            animator.SetTrigger("InventoryIn");
        }
        else
        {
            showInventory = false;
            animator.SetTrigger("InventoryOut");
        }
    }
}
