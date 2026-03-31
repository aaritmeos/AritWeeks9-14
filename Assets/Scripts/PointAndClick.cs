using UnityEngine;
using UnityEngine.InputSystem;

public class PointAndClick : MonoBehaviour
{
    public Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        //the same as Mouse.current.position.ReadValue();
        movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        //the same as Mouse.current.position.ReadValue();
        transform.position = new Vector2 newPos();
        newPos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}
