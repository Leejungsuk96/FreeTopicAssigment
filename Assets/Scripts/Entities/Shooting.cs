using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private Transform bulletSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    public GameObject testBullet;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

    }
    // Start is called before the first frame update
    void Start()
    {
        _controller.OnShootingEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 vector)
    {
        aimDirection = vector;
    }

    private void OnShoot()
    {
        CreateBullet();
    }

    private void CreateBullet()
    {
        Instantiate(testBullet, bulletSpawnPosition.position,Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
