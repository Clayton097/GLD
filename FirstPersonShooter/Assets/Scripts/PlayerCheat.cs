using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheat : MonoBehaviour
{

    [SerializeField]
    GameObject player;


    [SerializeField]
    GameObject skeleton;

    [SerializeField]
    GameObject bug1;

    [SerializeField]
    GameObject bug2;

    [SerializeField]
    GameObject bug3;

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

        //enemy Destroy
        if (Input.GetKeyDown(KeyCode.O))
        {
            Destroy(skeleton);
            Destroy(bug1);
            Destroy(bug2);
            Destroy(bug3);
        }
    }
}
