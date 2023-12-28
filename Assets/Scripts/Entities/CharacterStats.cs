using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatChangeType
{
    Add,         // 더하기
    Multiple,   // 곱하기
    Override,   // 덮어쓰기
}

[Serializable]
public class CharacterStats
{
    public StatChangeType statsChangeType;
    public int maxHealth;
    public float Speed;
    public int Level;
    public int Gold;

    // 공격 데이터
    public AttackSO attackSO;

}
