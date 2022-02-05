using System.Collections;
using UnityEngine;

public class BotRandomInput : MovementInputBase
{
    [SerializeField] private float _maxMoveDuration = 1;

    private Vector2 _direction;

    protected override IEnumerator Start()
    {
        yield return base.Start();
        yield return NextMove();
    }

    protected override Vector2 GetInput()
    {
        return _direction;
    }

    private IEnumerator NextMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(_maxMoveDuration);
            _direction = Random.onUnitSphere;
        }
    }
}