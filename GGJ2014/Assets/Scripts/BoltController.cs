using UnityEngine;
using System.Collections;

public class BoltController : MonoBehaviour {
	public int direction = 0;
	public float speed;
	public int hp = 3;
	public int points = 200;
	public Vector3 moveDirection = new Vector3(0, 0, 0);
	private Transform groundCheck;
	private bool grounded = false;
	public float jumpSpeedMax = 1.0f;
	public float jumpSpeedMin = 0.1f;
	public float gravity = 1.0f;
	public AudioClip hurt;

	// Use this for initialization
	void Start () {
		groundCheck = transform.Find("groundCheck");
		float dir = Random.value;
		if (dir > .5) {
			direction = 1;
		}
		else{
			direction = -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		boltBehavior ();
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall") {
						direction *= -1;
				} else if (coll.gameObject.tag == "Sunbeam") {
						hp--;
						AudioSource.PlayClipAtPoint(hurt, gameObject.transform.position);
						if (hp <= 0) {
								GameObject gameController = GameObject.Find ("GameController");
								gameController.GetComponent<GameContoller> ().increaseScore (points);
								Destroy (gameObject);
						}
				} else if (coll.gameObject.name == "Block") {
						if (moveDirection.y > 0) {
								moveDirection.y = 0;
						}
				} else if (coll.gameObject.name == "bar") {
						if (moveDirection.y > 0) {
								moveDirection.y = 0;
						}
				}
			else{
				direction *= -1;
			}
	}

	void boltBehavior(){
		if (grounded) {
			moveDirection.y = Random.Range(jumpSpeedMin, jumpSpeedMax);
		}
		if (!grounded) {
			moveDirection.y -= gravity * Time.deltaTime;
		}
		moveDirection.x = speed * direction;
		gameObject.transform.Translate (moveDirection);
	}

	public void hpChanged(int hp){
		
	}
	
}