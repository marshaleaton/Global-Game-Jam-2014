using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public float speed = 0.5F;
	public float jumpSpeed = .50F;
	public float gravity = 10.0F;
	private Vector3 moveDirection = Vector3.zero;
	private Transform groundCheck;
	private bool grounded = false;
	// Use this for initialization
	void Start () {
		groundCheck = transform.Find("groundCheck");
	}
	
	// Update is called once per frame
	void Update() {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		//on demand output diagnostics to log
		if (Input.GetKeyUp("l")) {
			Debug.Log ("Is Grounded: "+grounded);
		}

		if (Input.GetKeyUp("a")) {
			Debug.Log ("Is Grounded: "+grounded);
		}
		if (Input.GetKeyUp("w")) {

			if(grounded){
				moveDirection.y = jumpSpeed;
			}
		}

		if(Input.GetKeyUp("space")){
			SpreadSunshine ();
		}
		if (!grounded) {
			moveDirection.y -= gravity * Time.deltaTime;
		}
		gameObject.transform.Translate (moveDirection);
		/*CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);*/
	}

	void SpreadSunshine(){
		Debug.Log ("Fire");
	}

	//Basic collision detection checking for two differently named objects
	void OnCollisionEnter (Collision col){
		if(col.gameObject.name == "Block"){
				Debug.Log("Hit the block");
			}
		if(col.gameObject.name == "platform"){
			Debug.Log("Hit the platform");
		}
	}
}
