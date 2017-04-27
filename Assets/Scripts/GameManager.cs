using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	/* This class handles:
	 * UI text
	 * Initialization/execution of game logic
	 * Handoff to other scenes
	 */
	public int levelNumber;

	public Text timeDisplay;
	int time; //in seconds
	int frameCounter;

	int ammoRemaining;
	public GameObject bullet1;
	public GameObject bullet2;
	public GameObject bullet3;

	public GameObject arduinoController;


	GameObject hitThing;


	// Use this for initialization
	void Start () {
		time = 30; 
		timeDisplay.text = "Time: " + time;
		frameCounter = 0;


		ammoRemaining = 3;

		//may need to say Cursor.visible = true in other scenes now
		//Cursor.visible = false;

	}
	
	// Update is called once per frame
	void Update () {
		//timer. assuming 60 fps but there's no way my laptop is going to get that
		if (frameCounter == 60) {
			time--;
			timeDisplay.text = "Time: " + time;
			frameCounter = 0;
			if (time <= 0) {
				SceneManager.LoadScene("levelfail");
			}

		}
		frameCounter++;

		//shoot
		if (Input.GetMouseButtonDown (0) && ammoRemaining > 0) {

			shoot ();

		}


	} //end update

	public IEnumerator gameOverLoss(){
		//close port

		//arduinoController.GetComponent<ArduinoController> ().OnApplicationQuit ();
		yield return new WaitForSeconds (0.7f);
		SceneManager.LoadScene("levelfail");
	}

	public IEnumerator gameOverWin(){
		//arduinoController.GetComponent<ArduinoController> ().OnApplicationQuit ();
		yield return new WaitForSeconds (0.7f);

		if (levelNumber == 1) {
			SceneManager.LoadScene ("bunnieslevelsuccess");
		} else if (levelNumber == 2) {
			SceneManager.LoadScene ("fishbowllevelsuccess");

		} else if (levelNumber == 3) {
			SceneManager.LoadScene ("chickenlevelsuccess");
		}
	}

	public void shoot(){
		GetComponent<AudioSource> ().Play ();
		ammoRemaining--;

		//update UI
		if (ammoRemaining == 2) {
			bullet3.SetActive (false);
		}
		if (ammoRemaining == 1) {
			bullet2.SetActive (false);
		}
		if (ammoRemaining == 0) {
			bullet1.SetActive (false);
		}


		//check for hit
		//the coordinates in the line below assume the camera is going to be in the exact same space in each level
		Ray ray = Camera.main.ScreenPointToRay (new Vector3(614.0f, 315.0f));
		Debug.Log (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 10000)) {
			Debug.DrawLine (ray.origin, hit.point, Color.red, 30f);
			hitThing = hit.transform.gameObject;
			Debug.Log (hitThing);
			if (hitThing.CompareTag ("enemy")) {
				//hit the bunny
				Debug.Log("Hit the bunny");
				hitThing.SetActive (false);
				StartCoroutine ("gameOverWin");
			}
			//if no hit, check for game over
			else if (ammoRemaining == 0) {
				StartCoroutine ("gameOverLoss");
			}
		}

	}

}
