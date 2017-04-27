using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstmoviescript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
		GetComponent<AudioSource> ().Play ();
		Cursor.visible = true;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnMouseDown()
    {
		SceneManager.LoadScene ("Level Select");
    }
}
