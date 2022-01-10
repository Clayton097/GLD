using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoximonFollow : MonoBehaviour
{
    private BoximonAnimator boximonAnimator;
    private EnemyState enemyState;
    public NavMeshAgent navAgent;
    public Transform target;
    //Walking speed
    public float walkSpeed = 0.5f;
    //Running speed
    public float runSpeed = 4f;
    private float patrolTimer;
    public float patrolForThisTime = 15f;
    public float chaseDistance = 100f;
    private float currentChaseDistance;
    public float attackDistance = 1.8f;

    //Time between each attack
    public float waitBeforeAttack = 2f;
    private float attackTimer;
    //Time to wait after attack
    public float chaseAfterAttackDistance = 2f;
    //Patrol range
    public float patrolRadiusMin = 20f, patrolRadiusMax = 60f;

    void Start()
    {
        //Initialising
        enemyState = EnemyState.PATROL;
        patrolTimer = patrolForThisTime;
        attackTimer = waitBeforeAttack;
        currentChaseDistance = chaseDistance;
    }

    // Update is called once per frame
    void Update()
    {
        //If Metalon state is set to patrol
        if (enemyState == EnemyState.PATROL)
        {
            Patrol();
        }

        //If Metalon state is set to chase
        if (enemyState == EnemyState.CHASE)
        {
            Chase();
        }

        //If Metalon state is set to attack
        if (enemyState == EnemyState.ATTACK)
        {
            Attack();
        }
    }

    void Awake()
    {
        //Initialising
        boximonAnimator = GetComponent<BoximonAnimator>();
        navAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag(Tags.PLAYER).transform;
    }

    void Patrol()
    {
        navAgent.isStopped = false;
        navAgent.speed = walkSpeed;

        patrolTimer += Time.deltaTime;

        if (patrolTimer > patrolForThisTime)
        {
            SetNewRandomDestination();
            patrolTimer = 0f;
        }

        //Checks if the Metalon is moving
        if (navAgent.velocity.sqrMagnitude > 0)
        {
            boximonAnimator.Walk(true);
        }
        else
        {
            boximonAnimator.Walk(false);
        }

        //Checks distance between Metalon and player
        if (Vector3.Distance(transform.position, target.position) <= chaseDistance)
        {
            boximonAnimator.Walk(false);
            enemyState = EnemyState.CHASE;
            //zombieAudio.playScream();
        }
    }

    void Chase()
    {
        navAgent.isStopped = false;
        navAgent.speed = runSpeed;

        navAgent.SetDestination(target.position);

        //Checks if the Metalon is moving
        if (navAgent.velocity.sqrMagnitude > 0)
        {
            boximonAnimator.Run(true);
        }
        else
        {
            boximonAnimator.Run(false);
        }

        //Checks if the player is within range to be attacked
        if (Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            boximonAnimator.Run(false);
            boximonAnimator.Walk(false);
            enemyState = EnemyState.ATTACK;

            if (chaseDistance != currentChaseDistance)
            {
                chaseDistance = currentChaseDistance;
                //Checks if the player ran away
            }
            else if (Vector3.Distance(transform.position, target.position) > chaseDistance)
            {
                boximonAnimator.Run(false);
                enemyState = EnemyState.PATROL;
                patrolTimer = patrolForThisTime;

                if (chaseDistance != currentChaseDistance)
                {
                    chaseDistance = currentChaseDistance;
                }
            }
        }
    }

    void Attack()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        attackTimer += Time.deltaTime;

        //Checks if the Metalon can attack
        if (attackTimer > waitBeforeAttack)
        {
            boximonAnimator.Attack(true);
            attackTimer = 0f;

            //playerHealth.TakeDamage(5);
            //zombieAudio.playAttack();
        }

        if (Vector3.Distance(transform.position, target.position) > attackDistance + chaseAfterAttackDistance)
        {
            enemyState = EnemyState.CHASE;
        }
    }

    //Sets a random destination for the Metalon to go to, used when patrolling
    void SetNewRandomDestination()
    {
        float randomRadius = Random.Range(patrolRadiusMin, patrolRadiusMax);

        Vector3 randomDirection = Random.insideUnitSphere * randomRadius;
        randomDirection += transform.position;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, randomRadius, -1);

        navAgent.SetDestination(navHit.position);
    }
}
