using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheat : MonoBehaviour
{

    [SerializeField]
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Self Destroy
        if (Input.GetKeyDown(KeyCode.P))
        {
            Destroy(player);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
            {
                GameObject.Destroy(enemy);
            }
        }
        
    }
}
