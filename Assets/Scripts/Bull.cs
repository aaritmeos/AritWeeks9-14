using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bull : MonoBehaviour
{
    //variable to control speed in unity
    public float speed;
    //varible to alter speed and charge
    public float chargeMult;
    //vector to control movement with player input
    public Vector2 movement;
    //vector to alter transform in Update
    public Vector2 latMove;
    //to determine bounds of Bull
    public SpriteRenderer bullShape;
    //to locate game objects for collisions
    public List<Transform> crates;
    //bool to check if player is charging
    public bool charge;
    //variable to start timer for speed restoration
    public float t = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //make transform equal to latMove
        transform.position = (Vector3)latMove;
        //alter latMove.x using movement vector and player input from the OnMove function
        latMove.x += movement.x;
        //alter latMove.y with formula that repeats constantly, moving bull forward
        latMove.y += speed * -1 * Time.deltaTime;
        //return new values to transform
        transform.position = latMove;

        //for loop to count up towards the elements in the crates list
        for (int i = 0; i < crates.Count; i++)
        {
            //if statement for bull reaction when colliding while charging
            if (Vector3.Distance(transform.position, crates[i].transform.position) <= 4f && charge == true)
            {
                Debug.Log("Crash");
            }

            //if statement for bull reaction when colliding while not charging
            if (Vector3.Distance(transform.position, crates[i].transform.position) <= 4f && charge == false)
            {
                //speed is halved
                speed = speed / 2;
                //timer starts
                t ++;
                //when timer gets to 5, it resets and restores speed to default
                if (t > 5)
                {
                    t = 0;
                    speed = speed = 5;
                }
                Debug.Log("Crash");
            }
        }
    }

    //get player input to alter movement
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    //get player input to accelerate/charge
    public void OnJump(InputAction.CallbackContext context)
    {
        //multiply speed when space is pressed and set bool charge to true
        if(context.started == true)
        {
            charge = true;
            speed = speed * chargeMult;
        }
        //return speed to normal and set bool charge to false
        if (context.canceled == true)
        {
            charge = false;
            speed = speed / chargeMult;
        }
            
    }
}
