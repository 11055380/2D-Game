using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
}