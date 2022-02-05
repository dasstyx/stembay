using System;
using UnityEngine;

[RequireComponent(typeof(Movable))]
public abstract class DamagableCharacter : MonoBehaviour, IDamagableCharacter
{
    [SerializeField] protected int _maxHp;
    [SerializeField] protected int _hp;
    protected Movable _movable;

    protected virtual void Start()
    {
        _hp = _maxHp;
        _movable = GetComponent<Movable>();
        rb = GetComponent<Rigidbody2D>();
    }

    public event Action OnDeath;
    public Rigidbody2D rb { get; private set; }

    public void TakeDamage(int value)
    {
        _hp -= value;

        if (_hp <= 0)
        {
            Death();
        }
    }

    public void HealUp(int value, bool ignoreMaxHp = false)
    {
        if (ignoreMaxHp || value + _hp <= _maxHp)
        {
            _hp += value;
        }
    }

    public Movable GetMovable()
    {
        return _movable;
    }

    protected virtual void Death()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}