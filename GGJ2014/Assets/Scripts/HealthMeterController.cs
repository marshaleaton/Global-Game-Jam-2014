using UnityEngine;
using System.Collections;

public class HealthMeterController : MonoBehaviour {
	public GameObject[] suns;
	public GameObject[] clouds;
	public bool[] health = {true, true, true, true, true};
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void adjustCounts(int numSuns){
		
	}

	public void changeHP(int currentHP){
		Vector3 vectorAdjust;
		for (int i = 0; i < 5; i++) {
			if(i < currentHP){
				vectorAdjust = suns[i].transform.position;
				vectorAdjust.z = -1;
				suns[i].transform.position = vectorAdjust;
				vectorAdjust = clouds[i].transform.position;
				vectorAdjust.z = 1;
				clouds[i].transform.position = vectorAdjust;
			}
			else{
				vectorAdjust = suns[i].transform.position;
				vectorAdjust.z = 1;
				suns[i].transform.position = vectorAdjust;
				vectorAdjust = clouds[i].transform.position;
				vectorAdjust.z = -1;
				clouds[i].transform.position = vectorAdjust;
			}
		}
	}
}
