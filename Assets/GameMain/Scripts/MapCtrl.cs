using UnityEngine;
using System.Collections;

public class MapCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(transform.position.x,
		                                 transform.position.y,
		                                 transform.position.z - 1);
		if (transform.position.z <= -55) {
			transform.position = new Vector3(transform.position.x,
			                                 transform.position.y,
			                                 245);
		}

	}
}
		                               