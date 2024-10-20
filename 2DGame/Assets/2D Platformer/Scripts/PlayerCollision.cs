using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Animator animator; // Reference to the player's animator
    public float detectionRadius; // Radius for the OverlapCircle
    public float hitAnimationDuration; // Duration of the "Hit" animation

    private bool isHit = false;

    private void Update()
    {
        // Check for player collisions within the detection radius
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectionRadius, LayerMask.GetMask("Enemy"));

        if (hit != null && !isHit)
        {
            // Trigger the "Hit" animation and set isHit to true
            animator.SetTrigger("Hit");
            isHit = true;
            StartCoroutine(StopHitAnimation());
        }
    }

    private IEnumerator StopHitAnimation()
    {
        // Wait for the hit animation duration
        yield return new WaitForSeconds(hitAnimationDuration);

        // Stop the "Hit" animation
        isHit = false;
        animator.SetTrigger("Idle");
    }
}

/*
public class PlayerCollision : MonoBehaviour
{
    public Animator animator; // Reference to the player's animator

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is an enemy (assuming "Enemy" is the layer name)
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // Trigger the "Hit" animation
            animator.SetTrigger("Hit");
            Debug.Log("Detected Hit!");
        }
    }
}
*/