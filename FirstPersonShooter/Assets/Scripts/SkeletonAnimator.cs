using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimator : MonoBehaviour
{
    private Animator animate;

    void Awake()
    {
        animate = GetComponent<Animator>();
    }

    //Sets walk perimeter
    public void Walk(bool walk)
    {
        animate.SetBool(AnimationTags.WALK_PARAMETER, walk);
    }

    //Sets run perimeter
    public void Run(bool run)
    {
        animate.SetBool(AnimationTags.RUN_PARAMETER, run);
    }

    //Sets attack perimeter
    public void Attack(bool attack)
    {
        animate.SetBool(AnimationTags.ATTACK_TRIGGER, attack);
    }

    //Sets death perimeter
    public void Dead(bool dead)
    {
        animate.SetBool(AnimationTags.DEATH_TRIGGER, dead);
    }
}
