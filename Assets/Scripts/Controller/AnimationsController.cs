using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : Animations
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int IsHit = Animator.StringToHash("IsHit");

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller.OnShootingEvent += Attacking;
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(IsWalking, vector.magnitude > .5f);        
    }

    private void Attacking(AttackSO sO)
    {
        animator.SetTrigger(Attack);
    }

    private void Hit()
    {
        animator.SetBool(IsHit, true);
    }

    private void InvincibilityEnd()
    {
        animator.SetBool(IsHit, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
