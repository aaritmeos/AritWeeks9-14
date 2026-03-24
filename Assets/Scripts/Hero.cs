using UnityEngine;

public class Hero : MonoBehaviour
{
    public AudioSource step;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Step()
    {
        step.Play();
    }
}
