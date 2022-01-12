using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAnimation : MonoBehaviour
{
    [Header("Play Animation when boss is destroyed")]
    [SerializeField] private Animator anim;
    [SerializeField] private string sailBoat = "SailBoat";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("AnimationPlaying");
            anim.Play(sailBoat, 0, 0.0f);
        }    
    }
}
