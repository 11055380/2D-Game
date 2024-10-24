using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpSlider : MonoBehaviour
{
    public Slider powerUpSlider;
    public float maxPowerUpValue = 100f;
    public Animator playerAnimator;
    public string powerUpTrigger = "PowerUp";

    private float currentPowerUpValue = 0f;

    public void IncreasePowerUp(float amount)
    {
        if (currentPowerUpValue < maxPowerUpValue)
        {
            currentPowerUpValue += amount;
            currentPowerUpValue = Mathf.Clamp(currentPowerUpValue, 0f, maxPowerUpValue);
        }
        else
        {
            // Trigger the animation when the slider is full
            playerAnimator.SetTrigger(powerUpTrigger);
            currentPowerUpValue = 0f;
        }
    }
}
