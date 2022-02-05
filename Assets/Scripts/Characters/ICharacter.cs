using UnityEngine;

public interface ICharacter
{
    Rigidbody2D rb { get; }
    GameObject gameObject { get; }
    Movable GetMovable();
}