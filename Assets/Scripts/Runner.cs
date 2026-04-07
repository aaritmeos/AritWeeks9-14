using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    //contains displayed sprite
    public SpriteRenderer runnerSelector;
    //list that contains all sprites from where the boxSelector can choose
    public List<Sprite> runners;
    //number that indicates which sprite the boxSelector will display
    public int runnerNumber;
    //to get location of Bull game object
    public Transform bull;
    //variable to control speed
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickARunner();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;

        if (Vector3.Distance(transform.position, bull.position) <= 4f)
        {
            Debug.Log("Hit");
            StartCoroutine(Rotate());
        }
    }

    public void PickARunner()
    {
        //define boxNumber as a number between 0 and the amount of sprites in the boxes list
        runnerNumber = Random.Range(0, runners.Count);
        //tell the boxSelector to display the sprite indicated by the line of code above
        runnerSelector.sprite = runners[runnerNumber];
    }

    IEnumerator Rotate()
    {
        //varible for timer
        float t = 0;

        while (t < 1)
        {
            //start timer
            t += Time.deltaTime;
            //use the value of t to alter the scale of the game object
            Vector3 rotate = transform.eulerAngles;
            rotate.z += 5;
            transform.eulerAngles = rotate;
            yield return null;
        }


    }
}
