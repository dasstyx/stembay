using System.Collections;
using UnityEngine;

namespace stembay
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
    public class DirectionalSprites : MonoBehaviour
    {
        [SerializeField] public Sprite _right;
        [SerializeField] public Sprite _left;
        [SerializeField] public Sprite _up;
        [SerializeField] public Sprite _down;
        private Animator _animator;
        private Sprite[] _directionSpritesArray;

        private SpriteRenderer _renderer;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();

            _directionSpritesArray = new[]
            {
                _right,
                _left,
                _up,
                _down
            };
        }

        public void Move(int lookDirection)
        {
            _renderer.sprite = _directionSpritesArray[lookDirection];
            StartCoroutine(PlayMoveAnimation(lookDirection));
        }

        private IEnumerator PlayMoveAnimation(int lookDirection)
        {
            // _animator.SetInteger("lookDirection", lookDirection);
            _animator.SetTrigger("walking");
            yield return null;
        }
    }
}