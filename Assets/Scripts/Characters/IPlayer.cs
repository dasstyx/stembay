namespace stembay.Characters
{
    public interface IPlayer : IDamagableCharacter
    {
        int Hp { get; }
    }
}