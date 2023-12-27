using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private SpriteRenderer _playerRenderer;
    [SerializeField] private Transform gunPivot;
    [SerializeField] private SpriteRenderer gunSprite;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 vector)
    {
        RotateAim(vector);
    }

    private void RotateAim(Vector2 vector)
    {
        float rotZ = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        gunSprite.flipY = Mathf.Abs(rotZ) > 90f;
        _playerRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        gunPivot.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
}
