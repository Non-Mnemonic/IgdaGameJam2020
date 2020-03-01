/*
 * Programmer: Dylan McDonald
 * 
 * Description: 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour
{
    public GameObject startMenu, secondMenu, credits, startButton, 
        beginButton;
    private GameObject mainCamera;
    private bool isCameraMoving = false, camMoveForward = false,
        camMoveBack = false;
    private float angle = 0f;
    private Vector3 startPos, nextPos;
    //
    void Awake()
    {
        startMenu.SetActive(true);
        secondMenu.SetActive(false);
        credits.SetActive(false);

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        startPos = new Vector3(0, 1, -10);
        nextPos = new Vector3(0, 1, 0);
    }

    //
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!isCameraMoving)
            {
                //If the second menu with "Begin" "Credits" and "Exit" is up
                // then go back to the start
                if (secondMenu.activeSelf)
                {
                    secondMenu.SetActive(false);
                    startMenu.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(startButton);
                    camMoveBack = true;
                }

                //If the credits are being shown, then go back to the second
                // menu
                if (credits.activeSelf)
                {
                    secondMenu.SetActive(true);
                    credits.SetActive(false);
                    EventSystem.current.SetSelectedGameObject(beginButton);
                }
            }
        }

        //Camera movement
        if (camMoveForward)
        {
            angle += 0.02f;
            mainCamera.transform.position = Vector3.Lerp(startPos, nextPos, angle);
            isCameraMoving = true;
            if (angle > 1)
            {
                camMoveForward = false;
                isCameraMoving = false;
                angle = 0;
            }
        }
        else if (camMoveBack)
        {
            angle += 0.02f;
            mainCamera.transform.position = Vector3.Lerp(nextPos, startPos, angle);
            isCameraMoving = true;
            if (angle > 1)
            {
                camMoveBack = false;
                isCameraMoving = false;
                angle = 0;
            }
        }
    }

    public void SelectStart()
    {
        startMenu.SetActive(false);
        secondMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(beginButton);
        camMoveForward = true;
        ShakeMainCamera();
    }

    public void SelectBegin()
    {
        ShakeMainCamera();
        GameManagerScript.instance.LoadScene("Stage1");
    }

    public void SelectCredits()
    {
        secondMenu.SetActive(false);
        credits.SetActive(true);
        ShakeMainCamera();
    }

    public void SelectExit()
    {
        ShakeMainCamera();
        Application.Quit();
    }

    private void ShakeMainCamera()
    {
        StartCoroutine("ShakeCamera");
    }

    IEnumerator ShakeCamera()
    {
        mainCamera.transform.position = new Vector3(Random.Range(-0.8f, 1.8f), Random.Range(0.5f, 1.7f),
            mainCamera.transform.position.z);
        yield return new WaitForSeconds(0.01f);

        mainCamera.transform.position = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(1, 1.5f),
            mainCamera.transform.position.z);
        yield return new WaitForSeconds(0.02f);

        mainCamera.transform.position = new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(1.15f, 1.35f),
            mainCamera.transform.position.z);
        yield return new WaitForSeconds(0.02f);

        mainCamera.transform.position = new Vector3(0, 1, mainCamera.transform.position.z);
    }
}