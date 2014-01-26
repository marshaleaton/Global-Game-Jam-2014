using UnityEngine;
using System.Collections;

public class TwisterController : MonoBehaviour {
	public int direction = 0;
	public float speed;
	public int hp = 3;
	public Vector3 moveDirection = new Vector3(0, 0, 0);
	public int points = 200;
	public float changeDirectionThreshold = .95f;
	public AudioClip hurt;
	public int playerHP;
	// Use this for initialization
	void Start () {
		GameObject gameController = GameObject.Find("GameController");
		playerHP = gameController.GetComponent<GameContoller> ().getHealth();
		if (playerHP == 5) {

		}
		
		else if (playerHP == 4) {
			//gets more erratic
			changeDirectionThreshold = .85f;
		}
		
		else if (playerHP == 3) {
			//gets harder to kill
			hp = 4;
		}
		
		else if (playerHP == 2) {
			//gets faster
			speed+=speed;
		}
		
		else if (playerHP == 1) {
			//gets even harder to kill
			hp = 5;
		}
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
		moveDirection.x = speed * direction;
		gameObject.transform.Translate (moveDirection);
		DecideToChangeDirection ();

	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall") {
			direction *= -1;
		}
		else if (coll.gameObject.tag == "Sunbeam") {
			hp--;
			AudioSource.PlayClipAtPoint(hurt, gameObject.transform.position);
			if(hp <= 0){
				GameObject gameController = GameObject.Find("GameController");
				gameController.GetComponent<GameContoller> ().increaseScore(points);
				Destroy (gameObject);
			}
		}
		else if (coll.gameObject.name == "Block") {
		}
		else{
			direction *= -1;
		}
	}
	
	void OnCollisionExit2D(Collision2D coll){
		
	}

	void DecideToChangeDirection(){
		//Randome number generate to make decision to change direction
		if (Random.value >= changeDirectionThreshold) {
			direction *= -1;
		}
	}

	/*public void hpChanged(int playerHP){

	}*/
}