using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [Tooltip("Show inventory GUI")]
    public bool showInventory = false;
    private Animator animator;

    public GameObject Inventory;

    // Start is called before the first frame update
    void Start()
    {
        animator = Inventory.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            if (showInventory == true)
            {
                Inventory.SetActive(true);
                animator.SetTrigger("InventoryIn");
                showInventory = false;
            }
            else
            {
                Inventory.SetActive(false);
                animator.SetTrigger("InventoryOut");
                showInventory = true;
            }
        }
    }
}
