using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastFoward : MonoBehaviour
{
    public bool speed;
    // Start is called before the first frame update
    public void Fast()
    {
        float sp = this.gameObject.GetComponent<DayNightCycle>().speed;
        if (sp == 1)
        {
            this.gameObject.GetComponent<DayNightCycle>().speed = 5;
            this.gameObject.GetComponent<DayNightCycle>().Awake();
        } else if (sp == 5)
        {
            this.gameObject.GetComponent<DayNightCycle>().speed = 1;
            this.gameObject.GetComponent<DayNightCycle>().Awake();
        }
        
    }
}
