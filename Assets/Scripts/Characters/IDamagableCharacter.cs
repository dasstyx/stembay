using System;

namespace stembay.Characters
{
    public interface IDamagableCharacter : ICharacter
    {
        event Action OnDeath;
        void TakeDamage(int value);
        void HealUp(int value, bool ignoreMaxHp = false);
    }
}