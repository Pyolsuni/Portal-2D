using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events
{
    public static event Action<GameObject> OnButtonPressed;
    public static event Action<GameObject> OnButtonReleased;

    public static void ButtonPressed(GameObject button) => OnButtonPressed?.Invoke(button);
    public static void ButtonReleased(GameObject button) => OnButtonReleased?.Invoke(button);
}
