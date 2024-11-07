using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider2D))]
public class TriggerParticleEffect : MonoBehaviour
{
    public int particleAmount = 10;
    public int firstEmissionAmount = 5;
    public int secondEmissionAmount = 10;
    public int thirdEmissionAmount = 30;
    public float delayBetweenEmissions = .2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Rigidbody2D>())  // Check for Rigidbody2D instead of CharacterController
        {
            StartCoroutine(EmitParticlesCoroutine());
        }
    }
    private IEnumerator EmitParticlesCoroutine()
    {
        // First emission
        GetComponent<ParticleSystem>().Emit(firstEmissionAmount);
        yield return new WaitForSeconds(delayBetweenEmissions);

        // Second emission
        GetComponent<ParticleSystem>().Emit(secondEmissionAmount);
        yield return new WaitForSeconds(delayBetweenEmissions);

        // Third emission
        GetComponent<ParticleSystem>().Emit(thirdEmissionAmount);
    }


}