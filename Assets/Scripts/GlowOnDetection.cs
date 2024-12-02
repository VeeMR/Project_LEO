using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowOnDetection : MonoBehaviour
{
    public Light flashlight; // Reference to the flashlight
    private Color glowColor = Color.blue; // Color to glow
    private List<Renderer> memoryItemRenderers = new List<Renderer>();
    private Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();

    void Start()
    {
        // Find all objects with the tag "MemoryItem"
        GameObject[] memoryItems = GameObject.FindGameObjectsWithTag("MemoryItem");
        foreach (GameObject item in memoryItems)
        {
            Renderer renderer = item.GetComponent<Renderer>();
            if (renderer != null)
            {
                memoryItemRenderers.Add(renderer);
                originalMaterials[renderer] = renderer.material;
            }
        }
    }

    void Update()
    {
        foreach (Renderer renderer in memoryItemRenderers)
        {
            // Check if flashlight is pointing to the MemoryItem
            if (IsMemoryItemLit(renderer))
            {
                // Change the MemoryItem's color to blue
                renderer.material.color = glowColor;
            }
            else
            {
                // Reset to original material
                renderer.material.color = originalMaterials[renderer].color;
            }
        }
    }

    private bool IsMemoryItemLit(Renderer renderer)
    {
        // Use a Raycast to determine if the flashlight is hitting the MemoryItem
        Ray ray = new Ray(flashlight.transform.position, flashlight.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject == renderer.gameObject;
        }
        return false;
    }
}
