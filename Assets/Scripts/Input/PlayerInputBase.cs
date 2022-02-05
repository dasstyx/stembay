using System.Collections;

public abstract class PlayerInputBase : MovementInputBase
{
    protected bool _canControl = true;
    protected BombPlanter _planter;
    protected PlayerCharacter _player;

    protected override IEnumerator Start()
    {
        yield return base.Start();
        _player = (PlayerCharacter) _character;
        _player.OnDeath += () => _canControl = false;

        _planter = _movable.GetComponent<BombPlanter>();
    }

    protected override void FixedUpdate()
    {
        if (!_canControl)
        {
            return;
        }

        base.FixedUpdate();
    }
}