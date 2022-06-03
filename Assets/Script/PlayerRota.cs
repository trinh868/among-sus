using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRota : MonoBehaviour
{
    public float speed = 100f;
    public float xMouse = 0f, yMouse = 0f;
    public Transform Player;
    public Transform cameraHolder;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Rotation();
    }

    public void Rotation()
    {
        xMouse -= GetVerticalValue();
        xMouse = Mathf.Clamp(xMouse, -90f, 90f);
        yMouse = GetHorizontalValue();
        RotationVertical();
        RotationHorizontal();
    }

    public float GetVerticalValue() => Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
    public float GetHorizontalValue() => Input.GetAxis("Mouse X") * speed * Time.deltaTime;

    public void RotationVertical() => cameraHolder.localRotation = Quaternion.Euler(xMouse, 0f, 0f);

    public void RotationHorizontal() => Player.Rotate(Vector3.up * yMouse);
}
