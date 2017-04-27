/** 
 * EXAMPLE CODE 
http://answers.unity3d.com/questions/179311/unity-to-arduino.html
http://www.dyadica.co.uk/unity3d-serialport-script/
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System;

public class ArduinoController : MonoBehaviour {

    // SerialPortConnectorMac portConnect;
    public GameObject camera;
	public static SerialPort sp;
	public static string strIn;
	public static List<string> portList;
	public float smooth = 2.0F;
	private Vector3 prevPosition;
	public float oldAccX = 0;
	public float oldAccY = 0;
	public float oldAccZ = 0;
	int oldButton = 0;

	public GameObject gameManager;

	void Start () {
		/*
		Debug.Log (System.IO.Ports.SerialPort.GetPortNames ().Length);
		foreach (string p in System.IO.Ports.SerialPort.GetPortNames()) {
			Debug.Log (p);
		}
		*/

		//portList = GetPortNames ();
		/*
		foreach (string port in portList) {
			Debug.Log (port);
		}
		*/
		//Debug.Log (portList [3]);

		//sp = new SerialPort(portList[3], 9600, Parity.None, 8, StopBits.One);

		sp = new SerialPort ("COM5", 9600);
		Debug.Log (transform.position);

		OpenConnection();

		oldAccX = 0;
		oldAccY = 0;
		oldAccZ = 0;
		// portConnect = new SerialPortConnectorMac ();
		// portConnect.Open ();
		// Debug.Log("PORT: " + portConnect.Readline ());

	}

	List<string> GetPortNames ()
	{
		List<string> serialPorts = new List<string> ();
		string[] ttys = Directory.GetFiles ("/dev/", "tty.*");
		foreach (string dev in ttys) {
			// if (dev.StartsWith ("/dev/tty.*"))
				serialPorts.Add (dev);
		}

		string[] cus = Directory.GetFiles ("/dev/", "cu.*");
		foreach (string dev in cus) {
			// if (dev.StartsWith ("/dev/cu.*"))
				serialPorts.Add (dev);
		}

		return serialPorts;

	}

	//Function connecting to Arduino
	public void OpenConnection() 
	{
		if (sp != null) 
		{
			Debug.Log (sp.IsOpen);
			if (sp.IsOpen) 
			{
				sp.Close();
				Debug.Log( "Closing port, because it was already open!");
			}
			else 
			{
				sp.Open();  // opens the connection
				sp.ReadTimeout = 50;  // sets the timeout value before reporting error
				Debug.Log("Port Opened!");
			}
		}
		else 
		{
			if (sp.IsOpen)
			{
				print("Port is already open");
			}
			else 
			{
				print("Port == null");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (sp != null) {
			try{
				//Read incoming data
				strIn = sp.ReadLine ();
				if(! string.IsNullOrEmpty(strIn)){
					// Split string into an array
					string[] arduinoData = strIn.Split(',');
					MoveObject(arduinoData);

					//detect button
					//only want to simulate a click on the frame the button goes from 0 to 1
					int button = int.Parse(arduinoData[3]);
					if (oldButton == 0 && button == 1){
						gameManager.GetComponent<GameManager>().shoot();
					}
					oldButton = button;
				}
			}
			catch(Exception ex){
				// Do nothing - just ignore	
			}
		}
	}

	void OnApplicationQuit() 
	{
		sp.Close();
	}

	void MoveObject(string[] arduinoData){
		if (arduinoData.Length == 7) {
			
			/*
			 * We need to calculate new position of the object based on acceleration.
			 * The data that comes in from the accelerometer is in meters per second per second (m/s^2)
			 * The equation is: s = ut + (1/2)a t^2
			 * where s is position, u is velocity at t=0, t is time and a is a constant acceleration.
			 * For example, if a car starts off stationary, and accelerates for two seconds with an 
			 * acceleration of 3m/s^2, it moves (1/2) * 3 * 2^2 = 6m
			 */

			float accX = float.Parse(arduinoData [0]) * 100; // Accelerometer X
			float accY = float.Parse(arduinoData [1])* 100; // Accelerometer Y
			float accZ = float.Parse(arduinoData [2])* 100; // Accelerometer Z


			float deltaX = accX - oldAccX;
			float deltaY = accY - oldAccY;
			//float deltaZ =0;


			/*float newAccX = transform.position.x + deltaX;

			float newAccY = transform.position.y + deltaY;
			float newAccZ = transform.position.z;
			transform.position = new Vector3(newAccX, newAccY, newAccZ);

			oldAccX = accX;
			oldAccY = accY;
			oldAccZ = accZ;
            */

			float gyroX = float.Parse (arduinoData [4]);
			float gyroY = float.Parse (arduinoData [5]);
			//float gyroZ = float.Parse (arduinoData [6]);

			float newGyroX = transform.rotation.x + gyroX;
			float newGyroY = transform.rotation.y + gyroY;
            //float newGyroZ = transform.rotation.z + gyroZ;

            camera.GetComponent<CameraController>().unityRotate(gyroX/255, gyroY/255, 0);


            // transform.rotation = new Vector3(newGyroX, newGyroY, newGyroZ);
            //Quaternion target = Quaternion.Euler(newGyroX, newGyroY, 0);
			 //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);


		}
	}


	public bool IsNumber(string s) {
		bool value = true;
		foreach(char c in s.ToCharArray()) {
			value = value && char.IsDigit(c);
		}

		return value;
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

}
