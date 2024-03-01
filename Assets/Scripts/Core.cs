using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Core : MonoBehaviour
{
    public int maxHP = 10;
    int hp;

    public UnityEvent<string> OnHPChanged;
    public UnityEvent OnHit;
    public UnityEvent OnDestroy;

    static Core instance; // ΩÃ±€≈Ê
    public static Core Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Core>();
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        hp = maxHP;
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        var mob = other.GetComponent<Mob>();
        if(mob != null)
        {
            OnHit?.Invoke();
            DecreaseHP(1);
            mob.Destroy();
        }
    }

    void DecreaseHP(int amount)
    {
        if (hp <= 0)
            return;
        hp -= amount;
        if(hp <= 0)
        {
            hp = 0;
            OnDestroy?.Invoke();
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        OnHPChanged?.Invoke($"HP:{hp}");
    }
}
