using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour {

    public int rotateSpeed;

    public bool rotate;

    public float rotSpeed = 20;

    GameObject manager;

    void OnMouseDrag()
    {
        if (manager.GetComponent<Manager>().overUI != true)
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

            transform.Rotate(Vector3.up, -rotX);
            transform.Rotate(Vector3.right, rotY);
        }
    }

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("Manager");
    }
	
	// Update is called once per frame
	void Update () {
        if(rotate)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 8);
        } 
    }

    public void setRotate(bool toggle)
    {
        rotate = toggle;
    }
}
