using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionEnabler : MonoBehaviour
{
    private List<Material> materials = new List<Material>();

    public bool StartWithEmissionOnByDefault = true;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().GetMaterials(materials);

        if (StartWithEmissionOnByDefault)
            SetEmission(true);
    }

    public void SetEmission(bool State)
    {
        for (int i = 0; i < materials.Count; ++i)
        {
            if (State)
            {
                materials[i].EnableKeyword("_EMISSION");
            }
            else 
            {
                materials[i].DisableKeyword("_EMISSION");
            }
        }
    }
}
