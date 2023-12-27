using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnShootingEvent;

    private float LastAttackTime = float.MaxValue;
    protected bool IsAttacking { get; set; }

    protected CharacterStatsHandler _stats { get; private set; }

    protected virtual void Awake()
    {
        _stats = GetComponent<CharacterStatsHandler>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandleAttackDely();
    }

    private void HandleAttackDely()
    {
        if (_stats.CurrentStates.attackSO == null)
        {
            return;
        }

        if (LastAttackTime <= _stats.CurrentStates.attackSO.delay)
        {
            LastAttackTime += Time.deltaTime;
            
        }

        if (IsAttacking && LastAttackTime > _stats.CurrentStates.attackSO.delay)
        {
            LastAttackTime = 0;
            CallShootingEvent();
            
        }
        
    }

    public void CallMoveEvent(Vector2 value)
    {
        OnMoveEvent?.Invoke(value);
    }

    public void CallLookEvent(Vector2 value)
    {
        OnLookEvent?.Invoke(value);
    }

    public void CallShootingEvent()
    {
        OnShootingEvent?.Invoke();
    }
}
