using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackData", menuName = "Controller/Attack/Ranged", order = 1)]
public class RangedAttackData : AttackSO
{
    [Header("Ranged Attack Data")]
    public string bulletNamTag;
    public float duration;
    public float spread;
    public int numberofBulletsPerShot;
    public float multipleBulletsAngel;
    public Color BulletColor;
}
