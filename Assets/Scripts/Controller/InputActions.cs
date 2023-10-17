using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActions
{
    private static Controls _controls;

    public static void Init(playercontrol myPlayer)
    {
        _controls = new Controls();

        _controls.Permanent.Enable();

        _controls.Game.Movement.performed += ctx =>
        {
            myPlayer.SetMovementDirection(ctx.ReadValue<Vector2>());
        };

        _controls.Game.Jump.started += ctx =>
        {
            myPlayer.Jump();
        };
    }

    public static void SetControls()
    {
        _controls.Game.Enable();
        _controls.UI.Disable();
    }

    public static void SetUI()
    {
        _controls.UI.Enable();
        _controls.Game.Disable();
    }
}
