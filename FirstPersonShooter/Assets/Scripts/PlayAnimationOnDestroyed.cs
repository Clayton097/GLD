using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnDestroyed : MonoBehaviour
{

    [Header("Play Animation when boss is destroyed")]
    [SerializeField]private Animator anim;
    [SerializeField] private string barGoDown = "BarGoDown";

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        anim.Play(barGoDown,0,0.0f);
    }
}
