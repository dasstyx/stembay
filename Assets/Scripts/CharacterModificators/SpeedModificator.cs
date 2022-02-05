using System.Collections;
using UnityEngine;

public class SpeedModificator : MonoBehaviour, IModificator
{
    public void SlowDown(ICharacter character, float percent, float duration)
    {
        var movable = character.GetMovable();
        var changeSpeedWithDuration = ChangeSpeedWithDuration(movable, -percent, duration);
        movable.StartCoroutine(changeSpeedWithDuration);
    }

    public void SpeedUp(ICharacter character, float percent, float duration)
    {
        var movable = character.GetMovable();
        var changeSpeedWithDuration = ChangeSpeedWithDuration(movable, percent, duration);
        movable.StartCoroutine(changeSpeedWithDuration);
    }

    private IEnumerator ChangeSpeedWithDuration(Movable movable, float percent, float duration)
    {
        var _speed = movable.Speed;
        var newSpeed = _speed + _speed * percent;
        Debug.Log($"changing speed from {_speed} to {newSpeed}");
        movable.ChangeSpeed(newSpeed);

        yield return new WaitForSeconds(duration);
        ComeBack(movable);
        Debug.Log($"speed was reset to {movable.Speed}");
    }

    private void ComeBack(Movable movable)
    {
        var initialSpeed = movable.MaxSpeed;
        movable.ChangeSpeed(initialSpeed);
    }
}