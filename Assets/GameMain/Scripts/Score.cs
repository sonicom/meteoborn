using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;

	TitleScene ts;

	public int score;

	// Use this for initialization
	void Start () {

		scoreText.text = "Score : 0 km";
		score = 0;

		ts = GameObject.Find("Scene").GetComponent<TitleScene>();

	}
	
	// Update is called once per frame
	void Update () {

		if(ts.allStopFlg == false){
			score += 1;
		}
		scoreText.text = "Score : " + score.ToString() + " km";

	}
}
