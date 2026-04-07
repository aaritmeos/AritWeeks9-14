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
    }

    //get player input to alter movement
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    //get player input to accelerate/charge
    public void OnJump(InputAction.CallbackContext context)
    {
        //multiply speed when space is pressed
        if(context.started == true)
        {
            speed = speed * chargeMult;
        }
        //return speed to normal
        if(context.canceled == true)
        {
            speed = speed / chargeMult;
        }
            
    }
}
