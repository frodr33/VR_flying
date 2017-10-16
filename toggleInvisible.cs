using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleInvisible : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			print ("space key was pressed");
			// toggle visibility on spacebar
			//gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled; 
			gameObject.GetComponent<Renderer>().enabled = true; 

		}
	}
}
