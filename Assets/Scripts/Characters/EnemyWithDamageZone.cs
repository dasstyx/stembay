using System.Collections;
using UnityEngine;

public class EnemyWithDamageZone : MonoBehaviour, ICharacter
{
    [SerializeField] private float _coolDown = 1.5f;
    [SerializeField] private int _damageAmmount = 15;
    [SerializeField] private float _damageRadius = 2;
    private bool _canDamage;

    private WaitForSeconds _cooldownYield;
    private Movable _movable;

    protected void Start()
    {
        _cooldownYield = new WaitForSeconds(_coolDown);
        _movable = GetComponent<Movable>();
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(DoCooldown());
    }

    private void OnCollisionStay2D(Collision2D collisionInfo)
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, _damageRadius);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out IPlayer player))
            {
                Debug.Log("touching you");
                DealDamage(player);
            }
        }
    }

    public Rigidbody2D rb { get; private set; }


    public Movable GetMovable()
    {
        return _movable;
    }

    private void DealDamage(IPlayer player)
    {
        if (!_canDamage)
        {
            return;
        }

        Debug.Log("Dealing damage!!");
        player.TakeDamage(_damageAmmount);
        _canDamage = false;
    }

    private IEnumerator DoCooldown()
    {
        while (true)
        {
            _canDamage = true;
            yield return _cooldownYield;
        }
    }
}