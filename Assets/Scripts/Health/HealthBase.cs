using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBase : MonoBehaviour
{
    public Action onKill;

    public int startLife = 10;

    public bool destroyOnKill = false;
    public float delayOnDestroyKill = 0f;

    private int _currentLife;

    private bool isDead = false;

   [SerializeField] private FlashColor _flashColor;


    private void Awake()
    {
        Init(); 
        
        if (_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
      
    }

    void Init()
    {
        isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (isDead) return;
        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }

        if(_flashColor != null)
        {
            _flashColor.Flash();
        }
    }

    private void Kill()
    {
        isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject,delayOnDestroyKill);
        }
       
        onKill?.Invoke();
    }
}
