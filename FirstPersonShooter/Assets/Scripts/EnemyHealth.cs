using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;

    public GameObject ItemToDrop;
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }
    void Updete()
    {
        slider.value = CalculateHealth();
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if (health <= 0)
        {
            //Debug.Log("Item Dropped");
            //Instantiate(ItemToDrop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }


    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
