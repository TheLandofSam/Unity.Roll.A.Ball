using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerController : MonoBehaviour {

    public float speed; //by creating a public variable it will show up in the inspector as an editable property
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    private void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    //void Update ()
    //{
     //called before rendering a game, this is where most of the game code will go   
    //}

   void FixedUpdate ()
    {
        //called just before performing any physics calculations, physics code goes here, ie force applied to ridgid body

        //grabs the input from player through keyboard:
        float moveHorizontal = Input.GetAxis("Horizontal"); //x value of vector3
        float moveVertical = Input.GetAxis("Vertical"); //z value of vector 3

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {//this code called every time touch trigger collider, there is a ref to collider you touch (.CompareTag("PickUp"),
        //we test its tag (complete if statement), and if it is "PickUp" we will take the other game obj and set its state
        //deavtive

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 13)
        {
            winText.text = "You Win!";
        }
    }
}
