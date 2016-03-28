using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class ResultScore : MonoBehaviour {

	public Text resultText;

	// Use this for initializstion
	void Start () {

	}

	// Update is called once per frame
	void Update () { 
	
		resultText.text = "Score : " + TitleScene.scoreStock.ToString() + " km";

	}
}
