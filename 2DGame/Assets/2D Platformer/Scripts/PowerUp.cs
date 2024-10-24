using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpSlider : MonoBehaviour
{
    public Slider powerUpSlider;
    public float maxPowerUpValue = 100f;
    public float regenerationRate = 5f; // Adjust as needed
    public float cooldownDuration = 2f;
    public Animator playerAnimator;
    public string powerUpTrigger = "PowerUp";
    public string idleTrigger = "Idle";

    private float currentPowerUpValue = 100f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentPowerUpValue >= maxPowerUpValue)
        {
            playerAnimator.SetTrigger(powerUpTrigger);
            currentPowerUpValue = 0f;
            StartCoroutine(Cooldown());
        }

        powerUpSlider.value = currentPowerUpValue;
    }

    IEnumerator Cooldown()
    {
        playerAnimator.SetTrigger(idleTrigger);
        yield return new WaitForSeconds(cooldownDuration);
    }

    private void FixedUpdate()
    {
        if (currentPowerUpValue < maxPowerUpValue)
        {
            currentPowerUpValue += regenerationRate * Time.fixedDeltaTime;
            currentPowerUpValue = Mathf.Clamp(currentPowerUpValue, 0f, maxPowerUpValue);
            playerAnimator.SetTrigger(idleTrigger);
        }
    }
}