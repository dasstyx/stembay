using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace stembay.Input
{
    public class PlayerPhoneInput : PlayerInputBase
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _bombButton;

        protected override IEnumerator Start()
        {
            yield return base.Start();
            _bombButton.onClick.AddListener(_planter.Plant);
        }

        protected override Vector2 GetInput()
        {
            var direction = _joystick.Direction;
            return direction;
        }
    }
}