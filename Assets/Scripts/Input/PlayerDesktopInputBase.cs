using UnityEngine;

public class PlayerDesktopInputBase : PlayerInputBase
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _planter.Plant();
        }
    }

    protected override Vector2 GetInput()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var direction = new Vector2(x, y);

        return direction;
    }
}