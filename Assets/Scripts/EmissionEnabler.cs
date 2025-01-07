using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionEnabler : MonoBehaviour
{
    private List<Material> materials = new List<Material>();
    public Light flashlight;
    public bool StartWithEmissionOnByDefault = true;
    public float checkInterval = 0.1f;

    void Start()
    {
        GetComponent<MeshRenderer>().GetMaterials(materials);

        if (StartWithEmissionOnByDefault)
            SetEmission(true);

        InvokeRepeating("CheckFlashlight", 0, checkInterval);
    }

    void CheckFlashlight()
    {
        if (flashlight != null)
        {
            Vector3 toObject = transform.position - flashlight.transform.position;
            float angle = Vector3.Angle(flashlight.transform.forward, toObject);

            if (angle < flashlight.spotAngle / 2)
            {
                RaycastHit hit;
                if (Physics.Raycast(flashlight.transform.position, toObject, out hit))
                {
                    if (hit.transform == transform)
                    {
                        SetEmission(true);
                        return;
                    }
                }
            }
        }
        SetEmission(false);
    }

    public void SetEmission(bool state)
    {
        foreach (var material in materials)
        {
            if (state)
            {
                material.EnableKeyword("_EMISSION");
            }
            else
            {
                material.DisableKeyword("_EMISSION");
            }
        }
    }
}


