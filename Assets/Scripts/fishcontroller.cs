using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishcontroller : MonoBehaviour {
    float timeToGo;
    float rand1;
    float rand2;
    float rand3;
    float rand4;
    // Use this for initialization
    void Start () {
        timeToGo = Time.fixedTime + 3.0f;
    }
	
	
    void FixedUpdate()
    {
        transform.Translate(new Vector3(rand1, rand2, rand3),Space.Self);
        if (Time.fixedTime >= timeToGo)
        {
            rand1 = Random.Range(-5f, 5f);
            rand2 = Random.Range(-5f, 5f);
            rand3 = Random.Range(-5f, 5f);
            rand4 = Random.Range(-5f, 5f);
            if (rand3 > 0)
            {
                transform.localEulerAngles = new Vector3(0, 90, 0);
            }
            else {
                transform.localEulerAngles = new Vector3(0, 270, 0);
            }
            timeToGo = Time.fixedTime + 3.0f;
        }
       
    }


}
