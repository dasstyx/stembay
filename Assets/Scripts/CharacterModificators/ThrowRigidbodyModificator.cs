using stembay.Characters;
using UnityEngine;

namespace stembay.CharacterModificators
{
    public class ThrowRigidbodyModificator : MonoBehaviour, IModificator
    {
        public void Throw(ICharacter character, Vector2 from, float force)
        {
            var vectorForce = (Vector2) character.gameObject.transform.position - from;
            vectorForce *= force;
            character.rb.AddForce(vectorForce, ForceMode2D.Impulse);
        }
    }
}