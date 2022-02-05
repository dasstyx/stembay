using UnityEngine;

namespace stembay.Input
{
    public class PlayerDesktopInputBase : PlayerInputBase
    {
        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                _planter.Plant();
            }
        }

        protected override Vector2 GetInput()
        {
            var x = UnityEngine.Input.GetAxis("Horizontal");
            var y = UnityEngine.Input.GetAxis("Vertical");
            var direction = new Vector2(x, y);

            return direction;
        }
    }
}