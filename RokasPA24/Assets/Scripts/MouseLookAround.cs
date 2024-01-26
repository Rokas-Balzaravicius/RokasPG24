using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAround : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 2f;

    public Transform player;

    private Vector3 offset;

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensitivity, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);

    }
}
