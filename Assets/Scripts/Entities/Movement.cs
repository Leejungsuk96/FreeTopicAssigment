using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _controller;
    private CharacterStatsHandler _stats;
    private Vector2 _MoveValue = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;
    // Start is called before the first frame update
    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _stats = GetComponent<CharacterStatsHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 value)
    {
        _MoveValue = value;
    }

    private void ApplyMovement(Vector2 value)
    {
        value = value * _stats.CurrentStats.Speed; // 캐릭터 스피드
        if(knockbackDuration > 0.0f)
        {
            value += knockback;
        }
        _rigidbody.velocity = value;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyMovement(_MoveValue);
        if(knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        knockback = -(other.position - transform.position).normalized*power;
    }
}
