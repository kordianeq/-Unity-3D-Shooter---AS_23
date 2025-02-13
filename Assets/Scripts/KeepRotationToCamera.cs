using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotationToCamera : MonoBehaviour
{
    public Camera cam;
   
    void Start()
    {
       cam = GameObject.Find("Camera").GetComponent<Camera>();
    }


    void Update()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
