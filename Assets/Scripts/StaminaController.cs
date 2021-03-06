using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public Slider staminaBar;

    public float Stamina = 100.0f;
    public float MaxStamina = 100.0f;
    //---------------------------------------------------------
    private float StaminaRegenTimer = 0.0f;
    //---------------------------------------------------------
    private const float StaminaDecreasePerFrame = 20.0f;
    private const float StaminaIncreasePerFrame = 25.0f;
    private const float StaminaTimeToRegen = 1.0f;
    //---------------------------------------------------------

    private void Start()
    {
        staminaBar.maxValue = MaxStamina;
        staminaBar.value = MaxStamina;
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetAxis("Horizontal")!=0))
        {
            Stamina = Mathf.Clamp(Stamina - (StaminaDecreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
            staminaBar.value = Stamina;
            StaminaRegenTimer = 0.0f;
        }
        else if (Stamina < MaxStamina)
        {
            if (StaminaRegenTimer >= StaminaTimeToRegen)
            {
                Stamina = Mathf.Clamp(Stamina + (StaminaIncreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
                staminaBar.value = Stamina;
            }
            else
                StaminaRegenTimer += Time.deltaTime;
        }
    }
}
