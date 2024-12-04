using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class FloatingThing : MonoBehaviour
{
    public float floatHeight = 2.0f; // Base height
    public float floatAmplitude = 0.5f; // Amplitude of the floating effect
    public float floatFrequency = 1.0f; // Frequency of the floating effect

    void Update()
    {

        // Calculate the new height using a since wave
        float newY = floatHeight + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

        // Apply the new height to the NPC's position
        Vector3 floatPosition = transform.position;
        floatPosition.y = newY;
        transform.position = floatPosition;
    }
}
