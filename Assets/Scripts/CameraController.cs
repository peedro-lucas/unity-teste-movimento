using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public float YOffset, sensibilidade, limitRotation;
    public float rotX, rotY;

    //private Vector2 velocidadeFrame, velocidadeRotacao;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        rotX -= MouseY * sensibilidade * Time.deltaTime;
        rotY += MouseX * sensibilidade * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -limitRotation, limitRotation);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }

    private void LateUpdate()
    {
        transform.position = Player.position + Player.up * YOffset;
    }
}
