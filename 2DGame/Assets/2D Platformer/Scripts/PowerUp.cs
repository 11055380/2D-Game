using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpSlider : MonoBehaviour
{
    public Slider powerUpSlider;
    public float maxPowerUpValue = 5f;
    public float regenerationRate = 10f; 
    public float cooldownDuration = 2f;
    public Animator playerAnimator;
    public string powerUpTrigger = "PowerUp";
    public string idleTrigger = "Idle";

    private float currentPowerUpValue = 5f;
    private bool isOnCooldown = false;

    private void Update()
    {
        // Change the threshold to 10 (or any value you want)
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentPowerUpValue >= 5f && !isOnCooldown)
        {
            currentPowerUpValue = 0f;
            StartCoroutine(TriggerPowerUpAnimation());
        }

        powerUpSlider.value = currentPowerUpValue;
    }
    private IEnumerator TriggerPowerUpAnimation()
    {
        playerAnimator.SetTrigger(powerUpTrigger);
        yield return new WaitForSeconds(1.5f); // Adjust this to match the length of your animation
        playerAnimator.SetTrigger(idleTrigger);
    }

    private void FixedUpdate()
    {
        if (!isOnCooldown && currentPowerUpValue < maxPowerUpValue)
        {
            currentPowerUpValue += regenerationRate * Time.fixedDeltaTime;
            currentPowerUpValue = Mathf.Clamp(currentPowerUpValue, 0f, maxPowerUpValue);
        }
    }
}