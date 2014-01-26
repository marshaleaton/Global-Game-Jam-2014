using UnityEngine;
using System.Collections;

public class TwisterController : MonoBehaviour {
	public int direction = 0;
	public float speed;
	public int hp = 3;
	public Vector3 moveDirection = new Vector3(0, 0, 0);
	public int points = 300;
	// Use this for initialization
	void Start () {
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
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall") {
			
		}
		if (coll.gameObject.tag == "Sunbeam") {
			hp--;
			if(hp <= 0){
				GameObject gameController = GameObject.Find("GameController");
				gameController.GetComponent<GameContoller> ().increaseScore(points);
				Destroy (gameObject);
			}
		}
		if (coll.gameObject.name == "Block") {
		}
		else{
			direction *= -1;
		}
	}
	
	void OnCollisionExit2D(Collision2D coll){
		
	}
	
}