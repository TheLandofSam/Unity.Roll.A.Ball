using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}

    //as we move the play each frame of the game the camera is aligned to a new position in conj with the position fo the player. 
    //LateUpdate() refreshes each frame, but after the rest so we know it will occur after the refresh for the player
}
