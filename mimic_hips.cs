using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mimic_hips : MonoBehaviour {

	//in future, simplify script to have only one public GameObject, which will be holdHeight
	//public GameObject followedObject;
	public GameObject holdHeight;
	public float theHeight;

	// Use this for initialization
	void Start () {
		//transform.parent = followedObject.transform;
		theHeight = holdHeight.transform.position.y;
	}

	void followPosition() {
		Vector3 _tmp = holdHeight.transform.position;
		//_tmp.y = (followedObject.transform.position.y - (theHeight * .35f) - .1f);
		_tmp.y = holdHeight.transform.position.y - 2f;
		this.transform.position = _tmp; 
	}
	void followRotation()
	{
		Vector3 _tmp2 = holdHeight.transform.eulerAngles;
		_tmp2.x = 0;
		//The body turns as a percentage of the head turning
		_tmp2.z = 0;
		this.transform.eulerAngles = _tmp2;
	}
	// Update is called once per frame

	void Update()
	{
		followPosition();
		followRotation();
	}

}
