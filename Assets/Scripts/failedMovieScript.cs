using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class failedMovieScript : MonoBehaviour {

	public GameObject canvas;
	// Use this for initialization
	void Start () {
		canvas.SetActive (false);
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
		GetComponent<AudioSource> ().Play ();
		StartCoroutine ("delay");
		Cursor.visible = true;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{

	}

	public IEnumerator delay(){

		yield return new WaitForSeconds (5f);
		canvas.SetActive (true);
	}
}
