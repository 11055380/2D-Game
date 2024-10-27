using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading;

public class TriggerEvent : MonoBehaviour
{
    public float detectionRadius = 1f; // Adjust detection radius as needed
    private SimpleIntData simpleIntData; // Reference to SimpleIntData script

    private void Start()
    {
        // Find the SimpleIntData component (make sure it's attached to an object in the scene)
        simpleIntData = FindObjectOfType<SimpleIntData>();
    }

    private void Update()
    {
        // Check for the player in the detection radius
        if (Physics2D.OverlapCircle(transform.position, detectionRadius, LayerMask.GetMask("Player")))
        {
            // Call UpdateValue to increase score by 1
            if (simpleIntData != null)
            {
                simpleIntData.UpdateValue(1); // Adjust as necessary for your scoring system
            }

            // Optionally destroy the fruit object
            Destroy(gameObject);
        }
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