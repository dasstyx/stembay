using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movable : MonoBehaviour
{
    [SerializeField] private DirectionalSprites[] _directionalSprites;
    [SerializeField] private float _maxSpeed = 0.1f;


    private bool _isWalking;

    private Rigidbody2D _rb;
    public float Speed { get; private set; }
    public float MaxSpeed => _maxSpeed;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        Speed = _maxSpeed;
    }

    public void MoveByDirection(Vector2 direction)
    {
        var position = _rb.position + direction * Speed;
        _rb.MovePosition(position);

        PlayMoveAnimation(direction);
    }

    public void ChangeSpeed(float speed)
    {
        Speed = speed;
    }

    private void PlayMoveAnimation(Vector2 direction)
    {
        if (direction.Equals(Vector2.zero))
        {
            return;
        }

        int lookDirection;
        if (direction.x != 0)
        {
            lookDirection = direction.x > 0 ? 0 : 1;
        }
        else
        {
            lookDirection = direction.y > 0 ? 2 : 3;
        }

        foreach (var directionalSprite in _directionalSprites)
        {
            directionalSprite.Move(lookDirection);
        }
    }
}