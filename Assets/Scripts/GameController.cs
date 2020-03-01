using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public enum GameState { Day, Night };
    public GameState currentState = GameState.Day;

    private GameObject[] dayObjs;
    private GameObject[] nightObjs;

    

    private void Start()
    {
        dayObjs = GameObject.FindGameObjectsWithTag("DayObject");
        nightObjs = GameObject.FindGameObjectsWithTag("NightObject");

        foreach (GameObject nightObject in nightObjs)
        {
            nightObject.SetActive(false);
        }

    }

    public void Update()
    {
        float angle = this.gameObject.transform.rotation.eulerAngles.z;

        if (angle > 0 && angle < 180)
        {
            currentState = GameState.Night;
            foreach (GameObject dayObject in dayObjs)
            {
                dayObject.SetActive(false);
            }
            foreach (GameObject nightObject in nightObjs)
            {
                nightObject.SetActive(true);
            }
        }

        if (angle > 180)
        {
            currentState = GameState.Day;
            foreach (GameObject dayObject in dayObjs)
            {
                dayObject.SetActive(true);
            }
            foreach (GameObject nightObject in nightObjs)
            {
                nightObject.SetActive(false);
            }
        }
            
    }


}
