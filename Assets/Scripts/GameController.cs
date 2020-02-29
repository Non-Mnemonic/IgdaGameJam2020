using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

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

    public void StateChange()
    {

        if (currentState == GameState.Day)
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

        else
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
