using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCotroll : MonoBehaviour
{
    public class MouseHandler : MonoBehaviour
    {
        public float speed = 1f;
        public float xRotation = 0.0f;
        public float yRotation = 0.0f;
        public Camera cam;

        void Start()
        {
            cam = Camera.main;
        }

        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * speed;
            float mouseY = Input.GetAxis("Mouse Y") * speed;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        }
    }
}
