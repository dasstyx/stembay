using UnityEngine;

namespace stembay.Characters
{
    public interface ICharacter
    {
        Rigidbody2D rb { get; }
        GameObject gameObject { get; }
        Movable GetMovable();
    }
}