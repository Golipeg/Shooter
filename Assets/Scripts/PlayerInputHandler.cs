using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public event Action AimModeChanged;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AimModeChanged?.Invoke();
        }
    }
}
