using UnityEngine;
using System.Collections;

public class TitleBlock1 : MonoBehaviour {
	
	public GameObject blockPrefab;

	GameObject title;

	GameObject clone;

	int titleBlockRotateX = 0;
	int titleBlockRotateY = 0;
	int titleBlockRotateZ = 0;

	// Use this for initialization
	void Start () {
		name = "TitleBlock1";

		//GetComponent<Renderer>().sortingLayerName = "foreground";
		//GetComponent<Renderer>().sortingOrder = 3;

		titleBlockRotateX = Random.Range(-3,3);
		titleBlockRotateY = Random.Range(-3,3);
		titleBlockRotateZ = Random.Range(-3,3);

	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0.1f, -0.2f, 0.0f);
		transform.Rotate(titleBlockRotateX, titleBlockRotateY, titleBlockRotateZ);
		if (transform.position.y <= -10.0f) {
			clone = (GameObject)Instantiate(blockPrefab, new Vector3(Random.Range(-15, 5), Random.Range(7, 20), 0), Quaternion.identity);
			title = GameObject.Find("Title");
			clone.transform.parent = title.transform;
			Destroy(gameObject);
		}
	}
}
