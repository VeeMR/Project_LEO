using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightDirection : MonoBehaviour
{
    public Transform[] OtherObjects;

    public float DotProductAngle = 0.95f;

    private void Update()
    {
        for (int i = 0; i < OtherObjects.Length; ++i)
        {
            Transform currentObjectToCheck = OtherObjects[i];

            Vector3 DirectionToObject = (currentObjectToCheck.position - transform.position).normalized;
            bool IsCloseEnoughToBeingInfrontOfMe = Vector3.Dot(transform.forward, DirectionToObject) > DotProductAngle;

            EmissionEnabler emissionEnabler = currentObjectToCheck.GetComponent<EmissionEnabler>();
            if (emissionEnabler)
            {
                emissionEnabler.SetEmission(IsCloseEnoughToBeingInfrontOfMe);
            }
        }
    }
}
