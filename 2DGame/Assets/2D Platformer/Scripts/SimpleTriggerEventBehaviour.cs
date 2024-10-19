using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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