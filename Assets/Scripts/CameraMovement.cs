using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float rotationOnX;
    [SerializeField] float mouseSensitivity = 300f;
    [SerializeField] Transform player;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;   
    }

    void Update()
    {
        //float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;

        //rotationOnX -= mouseY;
        rotationOnX = Mathf.Clamp(rotationOnX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
