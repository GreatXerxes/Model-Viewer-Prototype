using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomFOV : MonoBehaviour
{
    public float minFov = 15f;
    public float maxFov = 90f;
    public float sensitivity = 10f;
    public float defaultFov = 60f;

    GameObject manager;

    void Start()
    {
        manager = GameObject.Find("Manager");
    }

    void Update()
    {
        if(manager.GetComponent<Manager>().overUI != true)
        {
            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;
        }
        
    }
}
