using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTheLightBehavior : MonoBehaviour
{
    public List<Light> lightList;   //All lights that we want to consider, in the inspector you can just drag and drop them over the name to add them to the list
    public bool illuminated;    //Is this object in light or shadow

    private GameObject lightableObject;
    // Start is called before the first frame update
    void Start()
    {
        lightableObject = this.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Light lightInstance in lightList)
        {
            switch (lightInstance.type) {   //I doubt we'll be using anything other than directional/Spotlights, but It's easy enough for most of these... not doing Disk
                case LightType.Directional:
                    Debug.LogError("Please don't make me do this one!");
                    break;
                case LightType.Disc:
                    Debug.LogError("Nothing defined for LightType Disk");
                    break;
                case LightType.Point:

                    break;
                case LightType.Rectangle:
                    Debug.LogError("Nothing defined for LightType REctangle");
                    break;
                case LightType.Spot:

                    break;

            }
            
            

        }   
    }
}
