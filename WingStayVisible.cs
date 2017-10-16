using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WingStayVisible : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Renderer> ().enabled = false;
	}

    void Update()
    {
    }

    public void OnTriggerEnter(Collider other){
        Debug.Log("WingIsTouched");
		if (other.gameObject.tag == "right_c" && this.gameObject.tag == "left_wing")
        {
            //stays on
			this.gameObject.GetComponent<Renderer> ().enabled = true;
			Debug.Log("WingIsTouched2");
        }
		if (other.gameObject.tag == "left_c" && this.gameObject.tag == "right_wing") {
			this.gameObject.GetComponent<Renderer> ().enabled = true;
		}
		}

}