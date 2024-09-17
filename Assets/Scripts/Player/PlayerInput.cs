using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]

public class PlayerInput : MonoBehaviour
{
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }
    public bool jump { get; private set; }
    public bool sprint { get; private set; }
    public bool primaryClick { get; private set; }
    public bool secondaryClick { get; private set; }    
    public bool commandPressed { get; private set; }
    public bool interact { get; private set; }

    private bool clear;

    // Singleton
    private static PlayerInput instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(instance);
            return;
        }

        instance = this;
    }

    public static PlayerInput GetInstance() {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ResetInputs();
        ProcessInputs();
        clear = true;
    }

    void ProcessInputs() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        sprint = sprint || Input.GetButton("Sprint");
        jump = jump || Input.GetButtonDown("Jump");
        interact = interact || Input.GetKeyDown(KeyCode.E);

        primaryClick = primaryClick || Input.GetButtonDown("Fire1");
        secondaryClick = secondaryClick || Input.GetButtonDown("Fire2");
        
        commandPressed = commandPressed || Input.GetKeyDown(KeyCode.Q);
    }

    /*private void FixedUpdate() {
        clear = true;
    }*/

    void ResetInputs() {
        if (!clear) {
            return;
        }

        horizontal = 0;
        vertical = 0;
        mouseX = 0;
        mouseY = 0;
        jump = false;
        sprint = false;
        primaryClick = false;
        secondaryClick = false;
        commandPressed = false;
        interact = false;
        
        clear = false;
    }
}
