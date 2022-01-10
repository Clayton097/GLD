using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoximonAnimator : MonoBehaviour
{
    private Animator animate;

    void Awake()
    {
        animate = GetComponent<Animator>();
    }

    //Sets walk perimeter
    public void Walk(bool walk)
    {
        animate.SetBool(AnimationTags.BOXIMON_WALK_PARAMETER, walk);
    }

    //Sets run perimeter
    public void Run(bool run)
    {
        animate.SetBool(AnimationTags.BOXIMON_RUN_PARAMETER, run);
    }

    //Sets attack perimeter
    public void Attack(bool attack)
    {
        animate.SetBool(AnimationTags.BOXIMON_ATTACK_TRIGGER, attack);
    }

    //Sets death perimeter
    public void Dead(bool dead)
    {
        animate.SetBool(AnimationTags.BOXIMON_DEATH_TRIGGER, dead);
    }
}
