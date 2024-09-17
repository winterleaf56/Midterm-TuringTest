using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraBehaviour : MonoBehaviour
{
    private PlayerInput input;

    [Header("Player Camera")]
    [SerializeField] private float turnSpeed;
    [SerializeField] private bool invertMouse;

    private float camXRotation;


    // Start is called before the first frame update
    void Start()
    {
        input = PlayerInput.GetInstance();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    void RotateCamera() {
        camXRotation += Time.deltaTime * input.mouseY * turnSpeed * (invertMouse ? 1 : -1);
        camXRotation = Mathf.Clamp(camXRotation, -45f, 45f);

        transform.localRotation = Quaternion.Euler(camXRotation, 0, 0);
    }
}
