using UnityEngine;
using UnityEngine.InputSystem;

public class TwinStick : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public Vector2 rotation;
    Vector3 spin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        spin = transform.eulerAngles;
        spin.z += rotation.x * speed * Time.deltaTime;
        transform.eulerAngles = spin;


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        rotation = context.ReadValue<Vector2>();
    }
}
