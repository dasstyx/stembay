namespace stembay.Characters
{
    public class PlayerCharacter : DamagableCharacter, IPlayer
    {
        public int Hp => _hp;
    }
}