using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    private Camera main;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        main = GetComponent<Camera>();   
    }

    // Update is called once per frame
    void Update()
    {
        main.transform.LookAt(player.transform);   
    }
}
