using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2DMovement : MonoBehaviour
{
    
    public Joystick joystick;
    public float movementSpeed;
    public SpriteRenderer spriteRenderer;
    public Character2DController player_Controller;
    public GrapplingGun player_GrapplingGun;

    bool isJumping = false;
    bool isHooking = false;

    float horizontalMovement = 0f;

    private Transform joystickTransform;


    // Start is called before the first frame update
    void Start()
    {
        joystickTransform = joystick.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = joystick.Horizontal * movementSpeed;
    }

    private void FixedUpdate()
    {
        player_Controller.Move(horizontalMovement * Time.fixedDeltaTime , isJumping);
        player_GrapplingGun.Hook(joystick.Direction, isHooking);
        isJumping = false;
    }

    public void Jump(){
        //gets called when the A button is pressed
        isJumping = true;
    }

    public void Hook(){
        //gets called when the B button is pressed
        isHooking = true;
    }

    public void ResetHook() {
        //gets called when the B button is released
        isHooking = false;
    }
}
