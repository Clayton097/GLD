using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerHealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
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
        healthBar.slider.value = currentHealth;//Update the PlayerHealthBar UI

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
            if (currentHealth >= 100) { }
            else
            {
                HealPlayer(10);
                collider.gameObject.SetActive(false);
                Debug.Log("Player Curretn Health  = " + currentHealth);
            }
        }
    }

    void PlayerDeath()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
