using UnityEngine;
using UnityEngine.InputSystem;

public class Bull : MonoBehaviour
{
    public float speed;
    public Vector2 movement;
    public Vector2 latMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // make bull move according to the value of Vector2 movement
        transform.position = (Vector3)latMove;
        latMove.x += movement.x;
        latMove.y += speed * -1 * Time.deltaTime;
        transform.position = latMove;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
