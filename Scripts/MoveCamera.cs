// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.

using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    //
    // VARIABLES
    //

    public float turnSpeed = 4.0f;      // Speed of camera turning when mouse moves in along an axis
    public float panSpeed = 4.0f;       // Speed of the camera when being panned
    public float zoomSpeed = 4.0f;      // Speed of the camera going back and forth

    private Vector3 mouseOrigin;    // Position of cursor when mouse dragging starts
    private bool isPanning;     // Is the camera being panned?
    public bool isRotating;    // Is the camera being rotated?
    public bool isZooming;     // Is the camera zooming?

    float scroll = 0;

    //
    // UPDATE
    //

    void Update()
    {
        // Get the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        // Get the right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }

        // Get the middle mouse button
        /*if (Input.GetMouseButtonDown(2))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isZooming = true;
        }*/

        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Debug.Log("Scroll Wheel");
            scroll = Input.GetAxis("Mouse ScrollWheel");
            Debug.Log("Scroll Value: " + scroll);
            isZooming = true;

        }

        // Disable movements on button release
        if (!Input.GetMouseButton(0)) isRotating = false;
        if (!Input.GetMouseButton(1)) isPanning = false;
        if (!Input.GetMouseButton(2)) isZooming = false;
        //if (Input.GetAxis("Mouse ScrollWheel") == 0) isZooming = false;


        GameObject manager = GameObject.Find("Manager");
        if (manager.GetComponent<Manager>().uiOpened != true)
        {
            // Rotate camera along X and Y axis
            if (isRotating)
            {
                Debug.Log("isRotating");
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

                transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
                transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
            }

            // Move the camera on it's XY plane
            /*if (isPanning)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

                Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
                transform.Translate(move, Space.Self);
            }*/

            // Move the camera linearly along Z axis
            /*if (isZooming)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

                Vector3 move = pos.y * zoomSpeed * transform.forward;
                transform.Translate(move, Space.World);
            }*/
            if (isZooming)
            {
                Debug.Log("isZooming ");
                transform.Translate(0, -(scroll * zoomSpeed), 0, Space.World);//zoom in and out
            }


            // float scroll = Input.GetAxis("Mouse ScrollWheel");
            // transform.Translate(0, -(scroll * zoomSpeed), 0, Space.World);//zoom in and out
            // transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, MIN_Y, MAX_Y), transform.position.z);//limits the zoom

            
        }
    }
}
