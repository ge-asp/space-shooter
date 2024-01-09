using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInputManager : MonoBehaviour
{
    public enum InputType
    {
        Desktop,
        Mobile,
        Bot
    }

    public static IMovementControls GetInputControls(InputType inputType)
    {
        return inputType switch
        {
            InputType.Desktop => new DesktopMovementControls(),
            InputType.Mobile => null,
            InputType.Bot => null,
            _ => throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null)
        };
    }
}
