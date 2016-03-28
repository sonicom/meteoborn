using UnityEngine;
using System.Collections;

public class EnemyCtrl : MonoBehaviour {

	public int enemyhp;

	// Use this for initialization
	void Start () {

		enemyhp = 4;

	}
	
	// Update is called once per frame
	void Update () {

		transform.localPosition = new Vector3(transform.localPosition.x,
		                                      transform.localPosition.y,
		                                      transform.localPosition.z - 0.1f);

		if(transform.position.z <= -10){
			Destroy(gameObject);
		}

	}
}
