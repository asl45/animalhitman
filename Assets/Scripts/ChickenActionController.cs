using UnityEngine;
using System.Collections;

//based off of rabbit action controller but I don't actually think you could even call it that anymore


[RequireComponent(typeof(Animator))]
public class ChickenActionController : MonoBehaviour {
	
	/*
	private Animator animator;
	private CharacterController controller;
    
	private int hashHit = Animator.StringToHash("Base Layer.Hit");
	private int hashDead = Animator.StringToHash("Base Layer.Dead");
	private int hashWalk = Animator.StringToHash("Base Layer.Walk");
	private int hashJump = Animator.StringToHash("Base Layer.Jump");
	private int hashPick = Animator.StringToHash("Base Layer.Pick");
	private int hashIdle = Animator.StringToHash("Base Layer.Idle");
    */
	float rand1;
    int reached=0;
	int switcher=0;
    int switcher2=0;

	// Use this for initialization
	void Start () {
		//animator = GetComponent<Animator>();
		//controller = GetComponent<CharacterController>();
	}


	
	// Update is called once per frame
	void Update () {


		if (switcher == 0) {
			transform.position = transform.position + new Vector3(1.5f, 0f, 0f);

			if (transform.position.x > 270)
			{
				switcher = 1;
				transform.Rotate(0, 180, 0);

			}
		}
		if (switcher == 1) {
			transform.position = transform.position + new Vector3 (-1.5f, 0f, 0f);

			if (transform.position.x < -270) {
				switcher = 0;
				transform.Rotate (0, 180, 0);
			}

		}









       /*if (reached == 1)
        {

            //animator.speed = 1.1f;

            if (switcher == 0)
            {
                //animator.Play(hashJump);
                transform.position = transform.position + new Vector3(rand1, 5.0f, rand1);

                if (transform.position.y > 350)
                {
                    switcher = 1;
                    //rand1 = Random.Range(-2f, 2f);
                }
            }
            if (switcher == 1)
            {
                //animator.Play(hashIdle);
                transform.position = transform.position + new Vector3(-rand1, -5.0f, -rand1);
                if (transform.position.y < 56)
                {

                    switcher = 0;

                }
            }
        }
        else
        {

            //animator.Play(hashWalk);
            //walk right
            //if at certain x
            //walk up
            //if at certain z (444,59,255)
            //reached=1;

            if (switcher2 == 0)
            {
               
                transform.position = transform.position + new Vector3(1.5f, 0f, 0f);

                if (transform.position.x > 225)
                {
                    switcher2 = 1;
                    transform.Rotate(0, 180, 0);
                    
                }
            }
            if (switcher2 == 1)
            {
                //animator.Play(hashIdle);
                transform.position = transform.position + new Vector3(0f, 0.45f, 1.0f);
                if (transform.position.z > 92)
                {

                    switcher2 = 2;
                    transform.Rotate(0, 90, 0);
                }
            }

            if (switcher2 == 2)
            {
                //animator.Play(hashIdle);
                transform.position = transform.position + new Vector3(3.0f, 0.0f, 0.0f);
                if (transform.position.x > 400)
                {

                    reached = 1;
                    transform.Rotate(0, 90, 0);
                }
            }



        }*/


        //animator.SetFloat("Speed", move ? 1.0f : 0.0f);


    }

	void OnAnimatorMove() {


	}
}
