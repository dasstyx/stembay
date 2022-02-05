using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace stembay.Characters
{
    public class DirtySkin : MonoBehaviour
    {
        [SerializeField] private float _duration = 2;
        [SerializeField] private float _fadeTime = 0.2f;
        [SerializeField] private SpriteRenderer _mainSkinRenderer;
        [SerializeField] private SpriteRenderer _dirtySkinRenderer;

        private void Start()
        {
            _dirtySkinRenderer.enabled = true;
            var transparent = _dirtySkinRenderer.color;
            transparent.a = 0;
            _dirtySkinRenderer.color = transparent;
        }

        public void MakeDirty()
        {
            StartCoroutine(DirtyWithTimer());
        }

        private IEnumerator DirtyWithTimer()
        {
            _mainSkinRenderer.DOFade(0, _fadeTime);
            _dirtySkinRenderer.DOFade(1, _fadeTime);
            yield return new WaitForSeconds(_duration);

            _mainSkinRenderer.DOFade(1, _fadeTime);
            _dirtySkinRenderer.DOFade(0, _fadeTime);
        }
    }
}