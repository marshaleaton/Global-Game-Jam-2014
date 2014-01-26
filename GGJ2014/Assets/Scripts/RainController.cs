using UnityEngine;
using System.Collections;

public class RainController : MonoBehaviour {
	public int direction = 0;
	public float speed;
	private int hp = 1;
	public Vector3 moveDirection = new Vector3(0, 0, 0);
	public int points = 100;
	public float pauseDelay = 1.0f;
	public float pauseTimer = 1.0f;
	public float moveDelay = 2.0f;
	public float moveTimer = 0.0f;
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
			speed+=(speed/2);
		}
		
		else if (playerHP == 3) {
			//gets harder to kill
			hp = 2;
		}
		
		else if (playerHP == 2) {
			//gets faster
			moveDelay += (moveDelay/2);
		}
		
		else if (playerHP == 1) {
			//gets even harder to kill
			pauseDelay += pauseDelay;
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
		RainPattern ();
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

	void RainPattern(){
		if (moveTimer <= moveDelay) {
			moveDirection.x = speed * direction;
			gameObject.transform.Translate (moveDirection);
			moveTimer += Time.deltaTime;
		}
		else if (pauseTimer >= pauseDelay){
			moveTimer = 0.0f;
			if (Random.value >= .5f) {
				direction *= -1;
			}
			pauseTimer = 0.0f;
		}
		else{
			pauseTimer += Time.deltaTime;
		}
	}

	public void hpChanged(int playerHP){
		
	}
		
}
