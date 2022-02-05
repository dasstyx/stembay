using UnityEngine;

[RequireComponent(
    typeof(SpeedModificator),
    typeof(MakeDirtyModificator),
    typeof(ThrowRigidbodyModificator))]
public class SlowBomb : Bomb
{
    [SerializeField] private float _slowPercent;
    [SerializeField] private float _slowDuration;
    [SerializeField] private float _throwForce;
    private MakeDirtyModificator _makeDirtyModificator;

    private SpeedModificator _speedModificator;
    private ThrowRigidbodyModificator _throwRigidbodyModificator;

    protected override void Start()
    {
        base.Start();
        _speedModificator = GetComponent<SpeedModificator>();
        _makeDirtyModificator = GetComponent<MakeDirtyModificator>();
        _throwRigidbodyModificator = GetComponent<ThrowRigidbodyModificator>();
    }

    protected override void DealEffect(ICharacter character)
    {
        _speedModificator.SlowDown(character, _slowPercent, _slowDuration);
        _makeDirtyModificator.MakeDirty(character);
        _throwRigidbodyModificator.Throw(character, transform.position, _throwForce);
    }
}