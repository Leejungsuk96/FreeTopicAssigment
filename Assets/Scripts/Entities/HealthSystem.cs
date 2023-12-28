using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = 0.5f;

    private CharacterStatsHandler _statsHandler;
    private float _timeSinceLastChange = float.MaxValue;

    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;


    public float CurrentHealth {  get; private set; }

    public float Maxhealth => _statsHandler.CurrentStats.maxHealth;

    private void Awake()
    {
        _statsHandler = GetComponent<CharacterStatsHandler>();
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = _statsHandler.CurrentStats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(_timeSinceLastChange < healthChangeDelay)
        {
            _timeSinceLastChange += healthChangeDelay;
            if(_timeSinceLastChange >= healthChangeDelay)
            {
                OnInvincibilityEnd?.Invoke();
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        if (change == 0 || _timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        _timeSinceLastChange = 0f;
        CurrentHealth += change;
        CurrentHealth = CurrentHealth > Maxhealth ? Maxhealth : CurrentHealth;
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;

        if(change > 0)
        {
            OnHeal?.Invoke();
        }

        else
        {
            OnDamage?.Invoke();
        }

        if (CurrentHealth <= 0f)
        {
            CallDeath();
        }
        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
