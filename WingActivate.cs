using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WingActivate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
    }

    public void OnTriggerEnter(Collider other){
            Debug.Log("WingIsTouched");
        if (other.gameObject.tag == "wing")
        {
            other.gameObject.GetComponent<Renderer>().enabled = !other.gameObject.GetComponent<Renderer>().enabled;
            Debug.Log("WingIsTouched2");
        }
		}

}