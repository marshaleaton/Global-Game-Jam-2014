using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public float speed = 0.5F;
	public float jumpSpeed = .50F;
	public float gravity = 10.0F;
	public Transform sunBeam;
	private Vector3 moveDirection = Vector3.zero;
	private Transform groundCheck;
	private bool grounded = false;
	protected Animator animator;
	private int facing = 1;
	// Use this for initialization
	void Start () {
		groundCheck = transform.Find("groundCheck");
		animator = GetComponent<Animator>();
		moveDirection = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update() {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		//on demand output diagnostics to log
		if(Input.GetKey("d")){
			if(facing < 0){
				facing = 1;
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
			}

			moveDirection.x = speed * Time.deltaTime;
		}
		if(Input.GetKey("a")){
			if(facing > 0){
				facing = -1;
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
			}
			moveDirection.x = -1 *( speed * Time.deltaTime);
		}


		if (Input.GetKeyUp("l")) {
			Debug.Log ("Is Grounded: "+grounded);
		}

		if(grounded){
			moveDirection.y = 0;
			animator.SetBool("grounded", true);
			if (Input.GetKeyDown("w")) {
				moveDirection.y = jumpSpeed;
				animator.SetBool("grounded", false);
			}
		}
		if (moveDirection.x == 0) {
			animator.SetBool ("walking", false);
		} else {
			animator.SetBool ("walking", true);
		}

		if(Input.GetKeyDown("space")){
			SpreadSunshine ();
		}
		if (!grounded) {
			moveDirection.y -= gravity * Time.deltaTime;
		}
		gameObject.transform.Translate (moveDirection);
		moveDirection.x = 0;
	}

	void SpreadSunshine(){
		Debug.Log ("Fire");
		Transform temp;
		Vector3 vectorAdjust = gameObject.transform.position;
		vectorAdjust.x += .2f * facing;
		temp = (Transform)Instantiate (sunBeam, vectorAdjust, Quaternion.identity);
		temp.GetComponent<SunBeamController> ().setDir (facing);
	}

	//Basic collision detection checking for two differently named objects
	void OnCollisionEnter (Collision col){
		if(col.gameObject.name == "Block"){
				Debug.Log("Hit the block");
			}
	}
}
