using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _controller;
    private Vector2 _MoveValue = Vector2.zero;
    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        _controller = GetComponent<CharacterController>();
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
        value = value * 5; // 캐릭터 스피드
        _rigidbody.velocity = value;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyMovement(_MoveValue);
    }
}
