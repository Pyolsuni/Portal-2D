using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityEqualizer : MonoBehaviour
{
    public Rigidbody2D targetObject; // Rigidbody component of the object whose velocity will be affected
    public Rigidbody2D sourceObject; // Rigidbody component of the object whose velocity will affect the targetObject

    void Update()
    {
        // Check if both Rigidbody components are assigned
        if (targetObject != null && sourceObject != null)
        {
            // Set the velocity of the targetObject to match the velocity of the sourceObject
            targetObject.velocity = sourceObject.velocity;
        }
    }
}
