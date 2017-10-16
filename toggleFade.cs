using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleFade : MonoBehaviour {

	public float fadeTime = 1f;
	bool fading = false;
	bool faded = true;

	Color opaque;
	Color transparent;
	Renderer rend;

	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Renderer> ().enabled = false;

		rend = gameObject.GetComponent<Renderer> ();
		Color rendColor = rend.material.color;
		transparent = new Color (rendColor.r, rendColor.g, rendColor.b, 0.0f);
		opaque = new Color (rendColor.r, rendColor.g, rendColor.b, 1.0f);
		rend.material.color = transparent;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space") && !fading) {
			StartCoroutine (Fade ());
		}
	}

	IEnumerator Fade() {
		print ("fading");
		fading = true;
		Color startColor = faded ? transparent : opaque;
		Color endColor = faded ? opaque : transparent;
		for (float t = 0; t < fadeTime; t += Time.deltaTime) {
			rend.material.color = Color.Lerp (startColor, endColor, t / fadeTime);
			yield return null;
		}
		fading = false;
		faded = !faded;
	}
}
