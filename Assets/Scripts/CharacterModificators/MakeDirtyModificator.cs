using UnityEngine;

public class MakeDirtyModificator : MonoBehaviour, IModificator
{
    public void MakeDirty(ICharacter character)
    {
        if (!character.gameObject.TryGetComponent(out DirtySkin changeSkinToDirty))
        {
            return;
        }

        changeSkinToDirty.MakeDirty();
    }
}