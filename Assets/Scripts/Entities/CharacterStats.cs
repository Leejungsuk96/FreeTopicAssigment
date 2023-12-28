using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatChangeType
{
    Add,         // ���ϱ�
    Multiple,   // ���ϱ�
    Override,   // �����
}

[Serializable]
public class CharacterStats
{
    public StatChangeType statsChangeType;
    public int maxHealth;
    public float Speed;
    public int Level;
    public int Gold;

    // ���� ������
    public AttackSO attackSO;

}
