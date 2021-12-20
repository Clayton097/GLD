using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//States Enemy can be
public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}
public class EnemyFollow : MonoBehaviour
{

    private SkeletonAnimator skeletonAnimator;
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

    // Start is called before the first frame update
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
        //If skeleton state is set to patrol
        if (enemyState == EnemyState.PATROL)
        {
            Patrol();
        }

        //If skeleton state is set to chase
        if (enemyState == EnemyState.CHASE)
        {
            Chase();
        }

        //If skeleton state is set to attack
        if (enemyState == EnemyState.ATTACK)
        {
            Attack();
        }
    }

    void Awake()
    {
        //Initialising
        skeletonAnimator = GetComponent<SkeletonAnimator>();
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

        //Checks if the zombie is moving
        if (navAgent.velocity.sqrMagnitude > 0)
        {
            skeletonAnimator.Walk(true);
        }
        else
        {
            skeletonAnimator.Walk(false);
        }

        //Checks distance between zombie and player
        if (Vector3.Distance(transform.position, target.position) <= chaseDistance)
        {
            skeletonAnimator.Walk(false);
            enemyState = EnemyState.CHASE;
            //zombieAudio.playScream();
        }
    }

    void Chase()
    {
        navAgent.isStopped = false;
        navAgent.speed = runSpeed;

        navAgent.SetDestination(target.position);

        //Checks if the skeleton is moving
        if (navAgent.velocity.sqrMagnitude > 0)
        {
            skeletonAnimator.Run(true);
        }
        else
        {
            skeletonAnimator.Run(false);
        }

        //Checks if the player is within range to be attacked
        if (Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            skeletonAnimator.Run(false);
            skeletonAnimator.Walk(false);
            enemyState = EnemyState.ATTACK;

            if (chaseDistance != currentChaseDistance)
            {
                chaseDistance = currentChaseDistance;
                //Checks if the player ran away
            }
            else if (Vector3.Distance(transform.position, target.position) > chaseDistance)
            {
                skeletonAnimator.Run(false);
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

        //Checks if the zombie can attack
        if (attackTimer > waitBeforeAttack)
        {
            skeletonAnimator.Attack(true);
            attackTimer = 0f;
            //zombieAudio.playAttack();
        }

        if (Vector3.Distance(transform.position, target.position) > attackDistance + chaseAfterAttackDistance)
        {
            enemyState = EnemyState.CHASE;
        }
    }

    //Sets a random destination for the zombie to go to, used when patrolling
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
