using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastFoward : MonoBehaviour
{
    private bool speed = true;

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (speed)
            {
                speed = false;
                this.gameObject.GetComponent<DayNightCycle>().speed = 15;
                this.gameObject.GetComponent<DayNightCycle>().Awake();
            }else if (!speed)
            {
                speed = true;
                this.gameObject.GetComponent<DayNightCycle>().speed = 1;
                this.gameObject.GetComponent<DayNightCycle>().Awake();
            }
        }
        /*float sp = this.gameObject.GetComponent<DayNightCycle>().speed;
        if (sp == 1)
        {
            this.gameObject.GetComponent<DayNightCycle>().speed = 5;
            this.gameObject.GetComponent<DayNightCycle>().Awake();
        } else if (sp == 5)
        {
            this.gameObject.GetComponent<DayNightCycle>().speed = 1;
            this.gameObject.GetComponent<DayNightCycle>().Awake();
        }*/
        
    }
}
