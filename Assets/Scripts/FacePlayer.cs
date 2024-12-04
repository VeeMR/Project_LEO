using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{

    public Transform player; // Assign the player's transform in the Inspector 

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction from LEO to the player
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // Keep the NPC upright

        // Rotate the NPC to face the player
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);

    }
}
