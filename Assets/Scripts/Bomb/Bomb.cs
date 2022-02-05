using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Bomb : MonoBehaviour
{
    [SerializeField] private float _exposionTime = 0.5f;
    [SerializeField] private float _explosionRadius = 1;
    private GameObject _explosionObject;

    protected virtual void Start()
    {
        _explosionObject = transform.GetChild(0).gameObject;
        StartCoroutine(Detonate());
    }

    protected IEnumerator Detonate()
    {
        yield return new WaitForSeconds(_exposionTime);

        var hits = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

        foreach (var collider in hits)
        {
            ICharacter character;
            if (collider.CompareTag("character") && collider.TryGetComponent(out character))
            {
                DealEffect(character);
            }
        }

        yield return DetonateEnd();
    }

    protected virtual IEnumerator DetonateEnd()
    {
        _explosionObject.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
        var info = _explosionObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
        var animationTime = info[0].clip.length;

        yield return new WaitForSeconds(animationTime);
        Destroy(gameObject);
    }

    protected abstract void DealEffect(ICharacter character);
}