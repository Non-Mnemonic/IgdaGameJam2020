using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // create a countdown for 3 mins

    public float speed = 1f;
    private float time;
    private float timer = 0.0f;


    void Start()
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

        if (timer > time)
        {
            this.gameObject.GetComponent<GameController>().StateChange();
            timer = timer - time;
        }
        
    }

    //Note: night time is positive rotation, day is negative rotation.

 
}
