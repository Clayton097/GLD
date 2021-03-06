using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{

    [SerializeField] private Animator myDoor;

    [SerializeField] string doorOpen = "DoorOpen";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myDoor.Play(doorOpen, 0, 0.0f);
            Destroy(gameObject);
        }
    }
}
