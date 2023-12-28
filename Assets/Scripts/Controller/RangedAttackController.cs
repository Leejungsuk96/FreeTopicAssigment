using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;
    private RangedAttackData attackData;
    private float currentDuration;
    private Vector2 direction;
    private bool IsReady;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer spriteRenderer;
    private BulletManager bulletManager;

    public bool fxOnDestroy = true;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!IsReady)
        {
            return;
        }

        currentDuration += Time.deltaTime;

        if (currentDuration > attackData.duration)
        {
            DestroyBullet(transform.position, false);
        }
        _rigidbody.velocity = direction * attackData.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(levelCollisionLayer.value == (levelCollisionLayer.value | (1<<collision.gameObject.layer)))
        {
            DestroyBullet(collision.ClosestPoint(transform.position) - direction * 2f, fxOnDestroy);
        }
    }

    public void InitializeAttack(Vector2 _direction, RangedAttackData _attackData, BulletManager _bulletManager)
    {
        bulletManager = _bulletManager;
        attackData = _attackData;
        direction = _direction;

        currentDuration = 0;
        spriteRenderer.color = attackData.BulletColor;
        transform.right = direction;
        IsReady = true;
    }  

    private void UpdateBulletSPrite()
    {
        transform.localScale = Vector3.one * attackData.size;
    }
    private void DestroyBullet(Vector3 position, bool createFx)
    {
        if (createFx)
        {

        }
        gameObject.SetActive(false);
    }
}
