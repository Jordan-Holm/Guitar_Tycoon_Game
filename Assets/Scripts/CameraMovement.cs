using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 20f;
    public float zoomSpeed = 80f;
    public bool gameIsActive = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = 40f;
        } else {
            speed = 20f;
        }

        if (gameIsActive) {
            Movement();
            MouseMovement();
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    void MouseMovement()
    {
        // The Camera will move within a certain amount of pixels of the edge of the screen
        float edgeSize = 40f;
        // Moves the Main Camera to the right
        if (Input.mousePosition.x > Screen.width - edgeSize)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        // Moves the Main Camera to the Left
        if (Input.mousePosition.x < edgeSize)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        //Moves the Main Camera forward
        if (Input.mousePosition.y > Screen.height - edgeSize)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        // Moves the Main Camera Backward
        if (Input.mousePosition.y < edgeSize)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        // Prevents the Main Camera from going lower than 5 on the Y axis
        if (transform.position.y > 5)
        {
            // Moves the Main Camera Lower
            if (Input.mouseScrollDelta.y > 0)
            {
                transform.position += Vector3.down * zoomSpeed * Time.deltaTime;
            }
        }
        //Prevents the Main Camera from going higher than 10 on the Y axis
        if (transform.position.y < 10)
        {
            // Moves the Main Camera Higher
            if (Input.mouseScrollDelta.y < 0)
            {
                transform.position += Vector3.up * zoomSpeed * Time.deltaTime;
            }

        }
    }
}
