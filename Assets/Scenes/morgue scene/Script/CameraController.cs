using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 200.0f;
    public float mouseSensitivity = 200.0f;

    public Vector3 minBounds;
    public Vector3 maxBounds;

    private float pitch = 0.0f;

    private float fixedY;  // Store the initial Y position

    void Start()
    {
        // Set the fixed Y position to the camera's initial Y position
        fixedY = transform.position.y;
    }

    void Update()
    {
        
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        
        Vector3 newPosition = transform.position + transform.forward * translation + transform.right * strafe;

        
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = fixedY; 
        newPosition.z = Mathf.Clamp(newPosition.z, minBounds.z, maxBounds.z);

        
        transform.position = newPosition;

       
        float rotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f); 
        transform.eulerAngles = new Vector3(pitch, transform.eulerAngles.y, 0.0f);
    }
}