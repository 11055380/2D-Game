using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider2D))]
public class TriggerParticleEffect : MonoBehaviour
{
    public int particleAmount = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Rigidbody2D>())  // Check for Rigidbody2D instead of CharacterController
        {
            GetComponent<ParticleSystem>().Emit(particleAmount);
        }
    }


}