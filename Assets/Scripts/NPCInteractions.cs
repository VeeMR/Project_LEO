using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractions : MonoBehaviour
{
   // Assign the AudioSource component in the inspector
    public AudioSource audioSource;
    

    // Dictionary to map tags to audio clips
    public Dictionary<string, AudioClip> tagToAudioClip;

    void Update()
    {
        // Initialize the dictionary (Example setup, modify as needed)
        tagToAudioClip = new Dictionary<string, AudioClip>
        {
            { "Pikachu", Resources.Load<AudioClip>("Pikachu") },
            { "Poster", Resources.Load<AudioClip>("Tech4Good") }
        };
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object's tag is in the dictionary
        if (tagToAudioClip.ContainsKey(collision.gameObject.tag))
        {
            // Play the corresponding audio clip
            audioSource.clip = tagToAudioClip[collision.gameObject.tag];
            audioSource.Play();
        }

    }
}


