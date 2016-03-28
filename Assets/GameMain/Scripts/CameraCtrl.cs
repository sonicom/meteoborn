using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour {

	// 底辺
	float a;
	// 高さ
	float xb;
	float yb;
	// 斜辺
	float xc;
	float yc;

	// カメラの縦画角
	float cameraHeight;

	Camera mC;

	PlayerCtrl player;

	// Use this for initialization
	void Start () {

		mC = GameObject.Find("Main Camera").GetComponent<Camera>();

		player = GameObject.Find("Player").GetComponent<PlayerCtrl>();

		cameraHeight = 33.75f;

		a = mC.transform.position.z;

		xc = a / Mathf.Cos(mC.fieldOfView / 2 * Mathf.PI / 180);

		xb = Mathf.Sqrt(xc * xc - a * a);

		yc = a / Mathf.Cos(cameraHeight / 2 * Mathf.PI / 180);

		yb = Mathf.Sqrt (yc * yc - a * a);

	}
	
	// Update is called once per frame
	void Update () {

		if(player.transform.position.x >= mC.transform.position.x + xb){
			mC.transform.position = new Vector3(player.transform.position.x - xb,
			                                    mC.transform.position.y,
			                                    mC.transform.position.z);
		}
		if(player.transform.position.x <= mC.transform.position.x - xb){
			mC.transform.position = new Vector3(player.transform.position.x + xb,
			                                    mC.transform.position.y,
			                                    mC.transform.position.z);
		}
		if(player.transform.position.y >= mC.transform.position.y + yb){
			mC.transform.position = new Vector3(mC.transform.position.x,
			                                    player.transform.position.y - yb,
			                                    mC.transform.position.z);
		}
		if(player.transform.position.y <= mC.transform.position.y - yb){
			mC.transform.position = new Vector3(mC.transform.position.x,
			                                    player.transform.position.y + yb,
			                                    mC.transform.position.z);
		}

	}
}
