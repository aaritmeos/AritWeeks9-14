using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Crate : MonoBehaviour
{
    //contains displayed sprite
    public SpriteRenderer boxSelector;
    //list that contains all sprites from where the boxSelector can choose
    public List<Sprite> boxes;
    //number that indicates which sprite the boxSelector will display
    public int boxNumber;
    //to get location of Bull game object
    public Transform bull;
    //curve to change size of object
    public AnimationCurve shrinker;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickABox();
    }

    // Update is called once per frame
    void Update()
    {
        //check for collisions with the bull
        if (Vector3.Distance(transform.position, bull.position) <= 4f)
        {
            Debug.Log("Hit");
            
            StartCoroutine(MakeSmall());
        }
    }

    public void PickABox()
    {
        //define boxNumber as a number between 0 and the amount of sprites in the boxes list
        boxNumber = Random.Range(0, boxes.Count);
        //tell the boxSelector to display the sprite indicated by the line of code above
        boxSelector.sprite = boxes[boxNumber];
    }

    //corroutine to reduce the size of the object only once
    IEnumerator MakeSmall ()
    {
        //varible for timer
        float t = 0;
        
        while (t < 1)
        {
            //start timer
            t += Time.deltaTime;
            //use the value of t to alter the scale of the game object
            transform.localScale = Vector2.one * shrinker.Evaluate(t);
            yield return null;
        }

        
    }
}
