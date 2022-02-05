using System.Collections;
using UnityEngine;

public abstract class MovementInputBase : MonoBehaviour
{
    [SerializeField] private GameObject _characterObject;
    protected ICharacter _character;
    protected Movable _movable;

    protected virtual IEnumerator Start()
    {
        yield return null;

        _character = _characterObject.GetComponent<ICharacter>();
        _movable = _character.GetMovable();
        if (_movable == null)
        {
            if (!TryGetComponent(out _movable))
            {
                Debug.LogError("Missing Movable component for the Input script!");
            }
        }
    }

    protected virtual void FixedUpdate()
    {
        var direction = GetInput();

        if (!direction.Equals(Vector2.zero))
        {
            _movable.MoveByDirection(direction);
        }
    }

    protected abstract Vector2 GetInput();
}