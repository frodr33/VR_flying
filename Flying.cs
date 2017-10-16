using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flying : MonoBehaviour
{
    //Flap force
    public float force = .0000000000000000001f;

	public GameObject LeftHand;
	public GameObject RightHand;
	public GameObject head;
	public GameObject CameraRig;

	public bool flying = false;

    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		//Debug.Log ("aesga menrbaertbgasd");
		if (Input.GetKeyDown ("space")) {
			this.gameObject.GetComponent<Renderer> ().enabled = true;
			flying = true;
		}
		if (flying == true) {
			newFunction ();
			//StartCoroutine (Pause ());
		}


	}

	// delay next loop of update
	//IEnumerator Pause(){
	//	Debug.Log ("testttttttttttttttttttttttttttttttttttttt");
	//	yield return new WaitForSecondsRealtime (450);
	//}




	public void newFunction()
	{
		if (LeftHand.transform.position.y >= head.transform.position.y &&
		    RightHand.transform.position.y >= head.transform.position.y) {
				


			/**
			***************************************************************************************************************
			What was done 10 pm- 12 am October 2nd
				-Implemented Leaning motion for turning left and right
				-Now able to land on terrain (Colliders on terrain and camera rig, freeze rotation in rigid body
				-Now able to put both hands completely down to fly downwards, otherwise will slowly go down (can adjust)

			*/

			// Fly Forward
			GetComponent<Rigidbody> ().AddForce (Vector3.forward * force);
			//Rigidbody. = Vector3.ClampMagnitude (rigidbody.velocity.x, 10);

			// Fly Upwards
			GetComponent<Rigidbody> ().AddForce ( Vector3.up * force);

			flying = true;
			//yield WaitForSecondsRealtime (5);


			//Vector3 newposition = head.transform.position;
			//Debug.Log ("TESTTTTTTT");
			//newposition.y += 10000;
			//head.transform.position = newposition;
			//head.transform.position.


		} else if (LeftHand.transform.position.y > RightHand.transform.position.y + .4) {

			Debug.Log ("Head position");
			Debug.Log (head.transform.position);
			Debug.Log ("Lefthand y value");
			Debug.Log (LeftHand.transform.position.y);
			Debug.Log ("Right Hand y value");
			Debug.Log (RightHand.transform.position.y);

			GetComponent<Rigidbody> ().AddForce (Vector3.right * force);
			GetComponent<Rigidbody> ().AddForce (Vector3.forward * force);

		} else if (RightHand.transform.position.y > LeftHand.transform.position.y + .4f) {

			GetComponent<Rigidbody> ().AddForce (Vector3.left * force);
			GetComponent<Rigidbody> ().AddForce (Vector3.forward * force);

		} else if (LeftHand.transform.position.y < head.transform.position.y - .6f &&
		           RightHand.transform.position.y < head.transform.position.y - .6f) {


			GetComponent<Rigidbody> ().AddForce (Vector3.down * force);
			GetComponent<Rigidbody> ().AddForce (Vector3.forward * force / 2);

		
		} else {
			GetComponent<Rigidbody> ().AddForce (Vector3.down * force/100);


		
		/**
		} else if (LeftHand.transform.position.x > head.transform.position.x) {
			//GetComponent<Rigidbody> ().AddForce (Vector3.up + 5);

			Debug.Log ("LEFTHAND");
			// Not flying, but moving left
			GetComponent<Rigidbody> ().AddForce (Vector3.right * force);
			GetComponent<Rigidbody> ().AddForce (Vector3.back * force);
			flying = false;

		} else if (RightHand.transform.position.x < head.transform.position.x) {
			Debug.Log ("RIGHTHAND");
			// Not flying, but moving right
			GetComponent<Rigidbody> ().AddForce (Vector3.left * force);
			GetComponent<Rigidbody> ().AddForce (Vector3.back * force);
			flying = false;


		//}else if (LeftHand.transform.position.z > CameraRig.transform.position.z &&
		//	RightHand.transform.position.z >= CameraRig.transform.position.z){
			//
		//	GetComponent<Rigidbody> ().AddForce (Vector3.forward * force);

		} else if (LeftHand.transform.position.y < CameraRig.transform.position.y &&
		           RightHand.transform.position.y < CameraRig.transform.position.y) {

			GetComponent<Rigidbody> ().AddForce (Vector3.down * force);
			GetComponent<Rigidbody> ().AddForce (Vector3.back * force / 2);

			// Not flying and not moving
			//flying = false;
		*/

		}


	}
		/**
	  public void OnTriggerEnter(Collider other){
		Debug.Log ("box on top woooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo");
		//if (other.gameObject.tag == "fly") {

		//if (lefthand.
			Debug.Log ("Check before");

			// Fly Forward
			GetComponent<Rigidbody> ().AddForce (Vector3.forward * force);

			// Fly Upwards
			GetComponent<Rigidbody> ().AddForce (Vector3.up * force);

			Debug.Log ("WingIsTouched2");
		}


	}

*/

	}




