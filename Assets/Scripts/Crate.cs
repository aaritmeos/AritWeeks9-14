using NUnit.Framework;
using System.Collections.Generic;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickABox();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxSelector.bounds.Contains(bull.position) == true)
        {
            Debug.Log("Hit");
        }
    }

    public void PickABox()
    {
        //define boxNumber as a number between 0 and the amount of sprites in the boxes list
        boxNumber = Random.Range(0, boxes.Count);
        //tell the boxSelector to display the sprite indicated by the line of code above
        boxSelector.sprite = boxes[boxNumber];
    }
}
