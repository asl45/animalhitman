using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {
    public GameObject ammo1;
    public GameObject ammo2;
    public GameObject ammo3;
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumX = -160F;
    public float maximumX = 160F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;
    float rotationX = 0F;
    int switcher = 1;
    int ammo;
    
    void Update()
    {
        /*if (ammo == 0)
        {
            //should wait 5 seconds
            SceneManager.LoadScene("levelfail");
        }
        if (Input.GetMouseButtonDown(0)) {
            GetComponent<AudioSource>().Play();
            //raycast
            //if hit enemy, load victory scene
            if (ammo == 3)
            {
                ammo1.SetActive(false);
                ammo--;
            }
            else if (ammo == 2)
            {
                ammo2.SetActive(false);
                ammo--;
            }
            else if (ammo == 1)
            {
                ammo3.SetActive(false);
                ammo--;

            }
            // if(raycast...hit){
            //SceneManager.LoadScene("bunnieslevelsuccess");
            //}
            
        }*/


        if (Input.GetMouseButtonDown(1) && switcher==0 )
        {
            Camera.main.fieldOfView = 83;
            switcher = 1;
            sensitivityX = 15F;
            sensitivityY = 15F;
        }
        else if (Input.GetMouseButtonDown(1) && switcher == 1)
        {
            Camera.main.fieldOfView = 8;
            switcher = 0;
            sensitivityX = 5F;
            sensitivityY = 5F;
        }

        if (axes == RotationAxes.MouseXAndY)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

    void Start()
    {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
        //ammo = 3;
    }
    public void unityRotate(float x, float y, float z)
    {
        rotationX += x * sensitivityX;
        rotationY += y * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
