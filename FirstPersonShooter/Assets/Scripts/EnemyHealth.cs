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
    public GameObject milk;
    public int enemyDamage = 5;

    [SerializeField]
    float thrust = 100f;

    private PlayerHealth player;

    [SerializeField]
    bool openGate = false;

    [SerializeField]
    [Range(1f, 20f)]
    [Tooltip("Determines the maximum distance between the enemy and the player to deal damage")]
    float maxDistance;


    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
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

    public bool canOpenGate
    {
        get
        {
            return gameObject.CompareTag("Skeleton") ? true : false;
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

    public void DropCoin(int multiplier = 1)
    {
        for (int i = 0; i < multiplier; i++)
        {
            Instantiate(coin, this.transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
    }

    public void DropMilk(int multiplier = 1)
    {
        for (int i = 0; i < multiplier; i++)
        {
            Instantiate(milk, this.transform.position + new Vector3(0.5f, -0.1f, 0f), Quaternion.identity);
        }
    }

    protected void TryAttackPlayerBug()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < maxDistance) AttackPlayer(enemyDamage);
    }

    protected void TryAttackPlayerSkeleton(float maxDistance)
    {
        if (Mathf.Abs(player.transform.position.z - transform.position.z) < maxDistance) AttackPlayer(enemyDamage);
    }

    protected void TryAttackPlayerBoximon(float maxDistance)
    {
        if (Mathf.Abs(player.transform.position.z - transform.position.z) < maxDistance) AttackPlayer(enemyDamage);
    }

    private void AttackPlayer(int damage, bool applyForce = false)
    {
        player.TakeDamage(damage);
        if (applyForce)
        {
            Debug.Log("Skeleton attacked");
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, transform.position.z - player.transform.position.z) * thrust * 20f);
        }
    }
}
