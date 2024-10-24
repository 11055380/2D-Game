using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpSlider : MonoBehaviour
{
    public Slider powerUpSlider;
    public float maxPowerUpValue = 100f;
    public float regenerationRate = 50f; // Increased regeneration rate
    public float cooldownDuration = 2f; // Cooldown duration after animation
    public Animator playerAnimator;
    public string powerUpTrigger = "PowerUp";

    private float currentPowerUpValue = 100f;
    private bool isOnCooldown = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentPowerUpValue >= maxPowerUpValue && !isOnCooldown)
        {
            playerAnimator.SetTrigger(powerUpTrigger);
            currentPowerUpValue = 0f;
            isOnCooldown = true;
            Invoke("EndCooldown", cooldownDuration);
        }

        if (!isOnCooldown)
        {
            playerAnimator.SetTrigger("Idle");
            currentPowerUpValue += regenerationRate * Time.deltaTime;
            currentPowerUpValue = Mathf.Clamp(currentPowerUpValue, 0f, maxPowerUpValue);
        }

        powerUpSlider.value = currentPowerUpValue;
    }

    private void EndCooldown()
    {
        isOnCooldown = false;
    }
}