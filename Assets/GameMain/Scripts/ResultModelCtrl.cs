using UnityEngine;
using System.Collections;

public class ResultModelCtrl : MonoBehaviour {

	float speed;
	bool qFlg;

	// Use this for initialization
	void Start () {

		speed = 0;
		qFlg = false;

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate(0, 0, 0.5f);

		if(Input.GetKeyDown(KeyCode.Q)){
			qFlg = true;
		}

		if(qFlg == true){
			speed += 0.01f;
			transform.position += transform.forward * speed;
		}

	}
}
