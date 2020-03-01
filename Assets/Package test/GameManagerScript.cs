/*
 * Programmer: Dylan McDonald
 * 
 * Description: 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    private Animator transitionAnimator;
    private bool isLoading = false;

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change 
        //as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as 
        //soon as this script is disabled. Remember to always have an unsubscription for every 
        //delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
    }

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            transitionAnimator = GetComponentInChildren<Animator>();
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadScene(string levelName)
    {
        if (!isLoading)
            StartCoroutine(LoadNextScene(levelName));
    }

    IEnumerator LoadNextScene(string levelName)
    {
        isLoading = true;
        transitionAnimator.SetBool("isLoading", true);
        transitionAnimator.SetBool("isLoaded", false);
        yield return new WaitForSeconds(0.5f);
        yield return SceneManager.LoadSceneAsync(levelName);
        yield return new WaitForSeconds(0.2f);
        isLoading = false;
        transitionAnimator.SetBool("isLoaded", true);
        transitionAnimator.SetBool("isLoading", false);
    }
}
