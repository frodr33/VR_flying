using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flying : MonoBehaviour
{
    //Flap force
    private int force = 300;
	private int rotation_scalar = 15;
	private bool flying = false;
	Rigidbody rb;
	Vector3 destination_forward;
	Vector3 lh_relative;
	Vector3 rh_relative;

	public GameObject LeftHand;
	public GameObject RightHand;
	public GameObject head;
	public GameObject CameraRig;
	public GameObject Player;

	/********************************************************************************
	 * Changes: 10/16
	 * 1). Rotation is now possible by rotating around + or - y axis
	 * 2). Changed global variable Vector.foward to local variable transform.foward
	 * 3). Some work was done for smoothing, all of it is commeneted out below. Not sure if 
	 * 	   this will work. Still researching ideas, but will involve deltatime some how
	 * 
	 * Changes: 10/18
	 * 1). Put in feature that allows arms pointing backwards to cause forward motion
	 * 2). Problems...only works when not rotating. Trying to figure out how to make it for all directions
	 * 3). Smooth Transitions still a problem
	 * 
	 */

    // Use this for initialization
    void Start()
    {
		//rb = GetComponent<Rigidbody> ();
		//destination_forward = rb.transform.position;


		
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		

		lh_relative = head.transform.InverseTransformPoint (LeftHand.transform.position);
		rh_relative = head.transform.InverseTransformPoint (RightHand.transform.position);

		Debug.Log ("TESTTTTTTTTTTTTT");
		Debug.Log (lh_relative.x);
		Debug.Log (head.transform.position.x);
		Debug.Log (transform.forward.x);
		
		if (Input.GetKeyDown ("space")) {
			this.gameObject.GetComponent<Renderer> ().enabled = true;
			flying = true;
		}
		if (flying == true) {
			newFunction ();
			//rb.AddForce (destination_forward * Time.deltaTime * 100f);
		}
		
	}

	public void newFunction()
	{
		if (LeftHand.transform.position.y >= head.transform.position.y &&
		    RightHand.transform.position.y >= head.transform.position.y) {
				
			// Fly Forward
			//GetComponent<Rigidbody> ().AddForce (transform.forward * force);
			//destination_forward = transform.forward * force;

			// Fly Upwards
			GetComponent<Rigidbody> ().AddForce (Vector3.up * force);
			flying = true;


		// transform.foward.x is a local variable while lefthand.transform.foward.z is a global variable
		//} else if (LeftHand.transform.position.z < transform.forward.x && RightHand.transform.position.z < transform.forward.x) {

		}else if (lh_relative.z < transform.forward.x && rh_relative.z < transform.forward.x){
		
			GetComponent<Rigidbody> ().AddForce (transform.forward * force);

		

		} else if (LeftHand.transform.position.y > RightHand.transform.position.y + .4) {
			
			//GetComponent<Rigidbody> ().AddForce (Vector3.right * force);

			transform.Rotate (Vector3.up * Time.deltaTime * rotation_scalar);
			GetComponent<Rigidbody> ().AddForce (transform.forward * force);


		} else if (RightHand.transform.position.y > LeftHand.transform.position.y + .4f) {

			//GetComponent<Rigidbody> ().AddForce (Vector3.left * force);
			transform.Rotate (-Vector3.up * Time.deltaTime * rotation_scalar);
			GetComponent<Rigidbody> ().AddForce (transform.forward * force);


		} else if (LeftHand.transform.position.y < head.transform.position.y - .6f &&
		           RightHand.transform.position.y < head.transform.position.y - .6f) {


			GetComponent<Rigidbody> ().AddForce (Vector3.down * force);
			GetComponent<Rigidbody> ().AddForce (transform.forward * force / 2);

		} else {
			GetComponent<Rigidbody> ().AddForce (Vector3.down * force/100);


		}
	}
	}




