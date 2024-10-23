using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading;

public class EnemyFade : MonoBehaviour
{
    public float fadeSpeed = 2f;
    public float detectionRadius = 1f; // Adjust detection radius as needed

    //Health
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    
    //Health
    void Start()
    {
        currentHealth = 100;
        GameObject healthBarObject = GameObject.Find("Health Bar2");
        if (healthBarObject != null)
        {
            healthBar = healthBarObject.GetComponent<HealthBar>();
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            Debug.LogError("Health Bar2 not found by name.");
        }
    }
    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, detectionRadius, LayerMask.GetMask("Player")))
        {
            StartCoroutine(FadeOut());
        }
    }
    
    //Health
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }


    private IEnumerator FadeOut()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Color originalColor = renderer.color;

        float elapsedTime = 0f;
        //Health
        for (int i=0; i<=10; i++)
        {
            TakeDamage(10); 
            Thread.Sleep(500);
        }
        
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime / fadeSpeed;
            renderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f - elapsedTime);
            yield return null;
        }

        // Destroy the enemy object after fading
        Destroy(gameObject);
    }
}




/*
public class SimpleTriggerEventBehaviour : MonoBehaviour
{
    public UnityEvent triggerEvent;

    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        // Trigger the event and test with a debug message
        triggerEvent.Invoke();
        Debug.Log("Player interacted with the object!");

        // Play an animation
        //animator.Play("AnimationName");

        // Make the object disappear
        other.gameObject.SetActive(false);

        // Make the object fall
        Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
        if (otherRigidbody != null)
        {
            otherRigidbody.AddForce(Vector3.down * 100f, ForceMode.Impulse);
        }
    }
}
*/