using UnityEngine;
using System.Collections;

public class GameContoller : MonoBehaviour {
	public GameObject player;
	private Controller playerScript;
	public	int currentHP = 5; 
	public int score = 0;
	public GUIText scoreObj;
	public GameObject healthObj;
	public GameObject[] enemies;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		playerScript = player.GetComponent<Controller> ();
		scoreObj.text = "Score:" + score;
	}
	
	// Update is called once per frame
	void Update () {
	
		int tempHP = playerScript.getHP ();
		if (currentHP != tempHP) {
			currentHP = tempHP;
			adjustHP();
		}
		if (currentHP <= 0) {
			gameOver ();
		}
	}

	public int getHealth(){
		return currentHP;
	}
	public int getScore(){
		return score;
	}

	public void increaseScore(int points){
		score += points;
		scoreObj.text = "Score:" + score;
	}

	void adjustHP(){
		healthObj.GetComponent<HealthMeterController> ().changeHP (currentHP);
			enemies = GameObject.FindGameObjectsWithTag("Enemy");
		
		/*foreach (GameObject enemy in enemies) {
			Debug.Log(enemy.name);
			if(enemy.name == "RainEnemy (Clone)"){
			   enemy.GetComponent<RainController>().hpChanged(currentHP);
			 }
		}*/
	}

	void gameOver(){
		Application.LoadLevel ("Game Over");
	}
}
