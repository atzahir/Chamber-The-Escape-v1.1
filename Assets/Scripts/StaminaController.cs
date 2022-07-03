﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{ 
    public float Stamina = 100.0f;
    public float MaxStamina = 100.0f;
    //---------------------------------------------------------
    private float StaminaRegenTimer = 0.0f;
    //---------------------------------------------------------
    private const float StaminaDecreasePerFrame = 20.0f;
    private const float StaminaIncreasePerFrame = 15.0f;
    private const float StaminaTimeToRegen = 2.0f;
    //---------------------------------------------------------

    private void Update()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        if (isRunning)
        {
            Stamina = Mathf.Clamp(Stamina - (StaminaDecreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
            StaminaRegenTimer = 0.0f;
        }
        else if (Stamina < MaxStamina)
        {
            if (StaminaRegenTimer >= StaminaTimeToRegen)
                Stamina = Mathf.Clamp(Stamina + (StaminaIncreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
            else
                StaminaRegenTimer += Time.deltaTime;
        }
    }
}
