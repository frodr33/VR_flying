using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flying : MonoBehaviour
{
    //Constants
    private int force = 300;
	private int rotation_scalar = 15;
	private int rotation_scalar2 = 1;
	private double maxdistance = 1.3f;
	private double LR_Ydifference = .4f;
	private double HeadtoHandsDiff = .7f;
	private bool flying = false;
	private string motion;

	//Math variables
	private float x_disL;
	private float y_disL;
	private float z_disL;
	private float HeadtoL_dist;
	private float x_disR;
	private float y_disR;
	private float z_disR;
	private float HeadtoR_dist;


	//Gameobjects
	public GameObject LeftHand;
	public GameObject RightHand;
	public GameObject head;


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
	 * Changes: 10/19
	 * 1). Arms backwards now works in all directions
	 * 2). Smoothness still a problem
	 * 3). Sometimes actual game is choppy, pause screen pops up and screen turns darker for a second
	 * 		could this be fixed with a more efficient implementation?
	 * 
	 * Changes: 10/23
	 * 1). Created several instances of IEnumerator to create a smoother flying experience compared
	 * 	   to the choppy and sharp turns that were previously impelemented
	 */

    // Use this for initialization
    void Start()
	{
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		
		//math for forward flying
		x_disL = LeftHand.transform.position.x - head.transform.position.x;
		y_disL = LeftHand.transform.position.y - head.transform.position.y;
		z_disL = LeftHand.transform.position.z - head.transform.position.z;
		HeadtoL_dist = Mathf.Pow((Mathf.Pow(x_disL, 2) + Mathf.Pow(y_disL, 2) + Mathf.Pow(z_disL, 2)), .5f); 
		x_disR = RightHand.transform.position.x - head.transform.position.x;
		y_disR = RightHand.transform.position.y - head.transform.position.y;
		z_disR = RightHand.transform.position.z - head.transform.position.z;
		HeadtoR_dist = Mathf.Pow((Mathf.Pow(x_disR, 2) + Mathf.Pow(y_disR, 2) + Mathf.Pow(z_disR, 2)), .5f); 

		
		if (Input.GetKeyDown ("space")) {
			this.gameObject.GetComponent<Renderer> ().enabled = true;
		
			flying = true;
		}
		if (flying == true) {
			newFunction ();

		}
		
	}

	IEnumerator Fade_up(){
		//yield return new WaitForSeconds (50f);
		int looptime = 0;
		while (looptime != 5) {
			// do something
			looptime++;
			yield return null; // return one frame
			GetComponent<Rigidbody> ().AddForce (Vector3.up * force);
			GetComponent<Rigidbody> ().AddForce (transform.forward * force);
		}
	}
	IEnumerator Fade_right(){
		//yield return new WaitForSeconds (50f);
		int looptime = 0;
		while (looptime != 5) {
			// do something
			looptime++;
			yield return null; // return one frame
			transform.Rotate (Vector3.up * Time.deltaTime * rotation_scalar2);
			GetComponent<Rigidbody> ().AddForce (transform.forward * force);
		}
	}
	IEnumerator Fade_left(){
		//yield return new WaitForSeconds (50f);
		int looptime = 0;
		while (looptime != 5){
			// do something
			looptime++;
			yield return null; // return one frame
			GetComponent<Rigidbody> ().AddForce (transform.forward * force);
			transform.Rotate (-Vector3.up * Time.deltaTime * rotation_scalar2);
		}

	}

	IEnumerator Fade_forward(){
		//yield return new WaitForSeconds (50f);
		int looptime = 0;
		while (looptime != 5) {
			// do something
			looptime++;
			yield return null; // return one frame
			GetComponent<Rigidbody> ().AddForce (transform.forward * force);
		}
	}

	IEnumerator Fade_down(){
		//yield return new WaitForSeconds (50f);
		int looptime = 0;
		while (looptime != 5) {
			// do something
			looptime++;
			yield return null; // return one frame
			GetComponent<Rigidbody> ().AddForce (Vector3.down * force);
			GetComponent<Rigidbody> ().AddForce (transform.forward * force / 2);
		}
	}

	public void newFunction()
	{

		// Last Frame's Positions
		if (motion == "up") {
			StartCoroutine ("Fade_up");

		} else if (motion == "bankright") {
			StartCoroutine ("Fade_right");

		} else if (motion == "bankleft") {
			StartCoroutine ("Fade_left");

		} else if (motion == "down") {
			StartCoroutine ("Fade_down");

		} else if (motion == "forwards") {
			StartCoroutine ("Fade_forward");
		}

	

		/*************************************************************************/
		/* Find the new force to add in the current frame */

		// Hands are Head level or above
		if (LeftHand.transform.position.y >= head.transform.position.y &&
		    RightHand.transform.position.y >= head.transform.position.y) {
				
			// Fly Upwards
			GetComponent<Rigidbody> ().AddForce (Vector3.up * force);

			// Fly Forwards
			GetComponent<Rigidbody> ().AddForce (transform.forward * force);

			motion = "up";

		// When Left hand higher than Right hand, rotate to the right
		} else if (LeftHand.transform.position.y > RightHand.transform.position.y + LR_Ydifference) {

			// Rotate to the right
			transform.Rotate (Vector3.up * Time.deltaTime * rotation_scalar);

			// Fly Forwards
			GetComponent<Rigidbody> ().AddForce (transform.forward * force);

			motion = "bankright";

		// When Right hand higher than left hand, rotate to the left
		} else if (RightHand.transform.position.y > LeftHand.transform.position.y + LR_Ydifference) {

			// Rotate to the left
			transform.Rotate (-Vector3.up * Time.deltaTime * rotation_scalar);

			// Fly Forwards
			GetComponent<Rigidbody> ().AddForce (transform.forward * force);

			motion = "bankleft";

		// If hands both stretched to ground, fly down
		} else if (LeftHand.transform.position.y < head.transform.position.y - HeadtoHandsDiff &&
			RightHand.transform.position.y < head.transform.position.y - HeadtoHandsDiff) {

			// Fly Down
			GetComponent<Rigidbody> ().AddForce (Vector3.down * force);

			// Fly forwards (with less force)
			GetComponent<Rigidbody> ().AddForce (transform.forward * force / 2);

			motion = "down";

		// Hands behind your back
		} else if (HeadtoL_dist > maxdistance && HeadtoR_dist > maxdistance) {

			// Fly Forwards
			GetComponent<Rigidbody> ().AddForce (transform.forward * force);

			motion = "forwards";

		} else {

			// Do nothing (Stay still in air)
			motion = "none";

		}
	}
	}




