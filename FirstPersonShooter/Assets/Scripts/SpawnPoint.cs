using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject monster;
    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;

    public GameObject[] spawnPoints;

    private GameObject currentPoint;


    private int index;
    public int spawnAmount = 5;
    public float spawnRate = 1f;
    //public int health;
    private bool spawning;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < spawnAmount && spawning == false)
        {
            StartCoroutine(SpawnMonster());
            SpawnMonster();
        }
    }

    public IEnumerator SpawnMonster()
    {
        int randomMonster = Random.Range(1, 4);
        switch (randomMonster)
        {
            case 1:
                monster = monster3;
                break;
            case 2:
                monster = monster1;
                break;
            case 3:
                monster = monster2;
                break;
            default:
                monster = monster3;
                break;
        }

        spawning = true;
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        monster = Instantiate(monster, currentPoint.transform.position, currentPoint.transform.rotation) as GameObject;
        monster.transform.parent = gameObject.transform;
        yield return new WaitForSeconds(spawnRate);
        spawning = false;
    }


}
