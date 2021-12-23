using System;
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

    public GameObject coin;
    public int enemyDamage = 5;

    [SerializeField]
    [Range(1f,20f)]
    [Tooltip("Determines the maximum distance between the enemy and the player to deal damage")]
    float maxDistance;
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    void Update()
    {
        slider.value = CalculateHealth();
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
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

    public void DropCoin(int multiplier = 1) {
        for (int i = 0; i < multiplier; i++)
        {
            Instantiate(coin, this.transform.position + new Vector3(0f,0f,0f), Quaternion.identity);
        }
    }

    protected void TryAttackPlayer() {
        var player = FindObjectOfType<PlayerHealth>();
        if (Vector3.Distance(player.transform.position, transform.position) < maxDistance) AttackPlayer(player, enemyDamage);
    }

    private void AttackPlayer(PlayerHealth player, int damage)
    {
        player.TakeDamage(damage);
    }
}
