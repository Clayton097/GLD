using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerHealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth;

    private ItemInventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<ItemInventory>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Damage taken = 25");
            TakeDamage(25);
            Debug.Log("Player Curretn Health  = " + currentHealth);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventory.UseItem(1);
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventory.UseItem(2);
        }

        PlayerDeath();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    //Player Heal
    public void HealPlayer(int heal)
    {
        //heal player
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);//Update the PlayerHealthBar UI

        //If health  is 100
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("HealthPotion"))
        {
            inventory.AddItem(new ItemInventory.ItemPicked(collider.gameObject, collider.gameObject.tag));
            Destroy(collider.gameObject);
        }else if (collider.gameObject.CompareTag("Ammo"))
        {
            inventory.AddItem(new ItemInventory.ItemPicked(collider.gameObject, collider.gameObject.tag));
            Destroy(collider.gameObject);
        }
    }

    void PlayerDeath()
    {
        if (currentHealth <= 0)
        {
            Destroy(GameObject.FindWithTag("Player"));
            Cursor.visible = true;
            Screen.lockCursor = false;
            SceneManager.LoadScene("GameOver");
        }
    }
}
