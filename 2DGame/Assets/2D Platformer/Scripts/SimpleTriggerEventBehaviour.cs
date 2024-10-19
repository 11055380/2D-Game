using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyFade : MonoBehaviour
{
    public float fadeSpeed = 2f;
    public float detectionRadius = 1f; // Adjust detection radius as needed

    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, detectionRadius, LayerMask.GetMask("Player")))
        {
            StartCoroutine(FadeOut());
        }
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