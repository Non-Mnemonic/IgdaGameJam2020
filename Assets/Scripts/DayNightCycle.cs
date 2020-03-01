using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // create a countdown for 3 mins

    public float speed = 1f;
    private float time;
    private float timer = 0.0f;

    private int loops = 0;
    public void Awake()
    {
        //create default timer for 3 mins
        time = 180f / speed;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.RotateAround(Vector3.zero, Vector3.forward, speed*0.004f);
        transform.LookAt(Vector3.zero);

        GameObject sunNMoon = GameObject.Find("UITimeDisplay");

        Vector3 target = sunNMoon.transform.position;

        sunNMoon.transform.RotateAround(target, Vector3.back, speed * 0.004f);

        if (timer > time)
        {
            
            this.gameObject.GetComponent<GameController>().StateChange();
            timer = timer - time;
            loops += 1;
            if (loops >= 2)
            {
                loops = 0;
                this.gameObject.GetComponent<Restart>().restartDay();
            }
        }
        
    }

    //Note: night time is positive rotation, day is negative rotation.

 
}
