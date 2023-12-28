
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private Transform bulletSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    private BulletManager bulletManager;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

    }
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = BulletManager.instance;
        _controller.OnShootingEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 vector)
    {
        aimDirection = vector;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float BulletsAngleSpace = rangedAttackData.multipleBulletsAngel;
        int numberofBulletsPerShot = rangedAttackData.numberofBulletsPerShot;

        float minAngle = (numberofBulletsPerShot / 2f) * BulletsAngleSpace + 0.5f * rangedAttackData.multipleBulletsAngel;

        for(int i = 0; i < numberofBulletsPerShot; i++)
        {
            float angle = minAngle + BulletsAngleSpace * i;
            float randomSPread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSPread;
            CreateBullet(rangedAttackData, angle);
        }
        
    }

    private void CreateBullet(RangedAttackData rangedAttackData, float angle)
    {
        bulletManager.ShootBullet(
            bulletSpawnPosition.position,
            RotateVector2(aimDirection, angle),
            rangedAttackData
            );
        
    }
    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
