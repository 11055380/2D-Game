using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading;

public class EnemyFade : MonoBehaviour
{
    public float fadeSpeed = 4f;
    public float detectionRadius = 1f; // Adjust detection radius as needed
    public float moveSpeed = .5f; // Speed of the enemy's movement
    public float moveRange = 100f; // Range of side-to-side movement
    private AudioSource audioSource; //Audio

    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position; // Store the starting position
        audioSource = GetComponent<AudioSource>(); //Audio
        audioSource.pitch = 3.0f;
        audioSource.time = audioSource.clip.length / 3;
    }

    private void Update()
    {
        // Move the enemy side to side
        Move();

        // Check for player detection
        if (Physics2D.OverlapCircle(transform.position, detectionRadius, LayerMask.GetMask("Player")))
        {
            audioSource.Play();
            StartCoroutine(FadeOut());
        }
    }
    
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void Move()
    {
        // Calculate new position based on the starting position and move range
        float newPosX = startingPosition.x + Mathf.Sin(Time.time * moveSpeed) * (moveRange / 2);
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
    }




    private IEnumerator FadeOut()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Color originalColor = renderer.color;

        float elapsedTime = 0f;
        
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime / fadeSpeed;
            renderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f - elapsedTime);
            yield return null;
        }

        // Destroy the enemy object after fading
        Invoke("DestroyEnemy",1f);
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