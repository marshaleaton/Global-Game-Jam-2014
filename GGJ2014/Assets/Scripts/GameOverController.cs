using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int score = GameObject.Find("GameController").GetComponent<GameContoller>().getScore();
		GUIText scoreText= GameObject.Find ("ScoreText").GetComponent<GUIText>();
		scoreText.text = "Your Score: " + score;
		Destroy (GameObject.Find ("GameController"));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp ("return") || Input.GetKeyUp ("enter")){
			Application.LoadLevel ("Title");
		}
	}
}
