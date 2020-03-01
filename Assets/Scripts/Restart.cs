using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    private GameObject[] timeBodyObjs;
    private GameObject[] timeBodyObjsRotation;

    public void restartDay()
    {
        this.gameObject.GetComponent<DayNightCycle>().enabled = false;

        timeBodyObjs = GameObject.FindGameObjectsWithTag("TimeBodyObjects");
        timeBodyObjsRotation = GameObject.FindGameObjectsWithTag("TimeBodyObjectRotation");

        foreach (GameObject TimeBodyObjects in timeBodyObjs)
        {
            TimeBodyObjects.GetComponent<TimeBody>().StartRewind();
        }
        foreach (GameObject TimeBodyObjectsRotation in timeBodyObjsRotation)
        {
            TimeBodyObjectsRotation.GetComponent<TimeBodyRotation>().StartRewind();
        }
        this.gameObject.GetComponent<DayNightCycle>().enabled = true;
    }

}
