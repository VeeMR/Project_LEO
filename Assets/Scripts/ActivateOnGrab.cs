using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ActivateOnGrab : MonoBehaviour
{
    [Header("Target XR Object")]
    [SerializeField]
    private XRGrabInteractable targetXRObject; // XR object to monitor for grabbing

    [Header("Objects to Activate/Deactivate")]
    [SerializeField]
    private GameObject[] objectsToActivate;

    [SerializeField]
    private GameObject[] objectsToDeactivate;

    private void OnEnable()
    {
        if (targetXRObject == null)
        {
            Debug.LogError("Target XRGrabInteractable is not assigned in the Inspector!");
            return;
        }

        // Subscribe to the grab event of the target XR object
        targetXRObject.selectEntered.AddListener(OnGrab);
    }

    private void OnDisable()
    {
        if (targetXRObject == null) return;

        // Unsubscribe from the grab event
        targetXRObject.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Activate the specified objects
        foreach (var obj in objectsToActivate)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        // Deactivate the specified objects
        foreach (var obj in objectsToDeactivate)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }
}