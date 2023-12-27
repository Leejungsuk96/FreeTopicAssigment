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
    public int maxHelth;
    public float Speed;

    // 공격 데이터
    public AttackSO attackSO;

}
