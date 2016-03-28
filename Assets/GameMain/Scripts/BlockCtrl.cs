using UnityEngine;
using System.Collections;

public class BlockCtrl : MonoBehaviour {
	
	public int blockHp;

	int blockRotateX = 0;
	int blockRotateY = 0;
	int blockRotateZ = 0;

	public CharacterController cc;

	PlayerCtrl pC;

	// Use this for initialization
	void Start () {

		name = "Block";

		blockRotateX = Random.Range(-3,3);
		blockRotateY = Random.Range(-3,3);
		blockRotateZ = Random.Range(-3,3);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.localPosition = new Vector3(transform.localPosition.x,
		                                      transform.localPosition.y,
		                                      transform.localPosition.z - 0.5f);

		transform.Rotate(blockRotateX, blockRotateY, blockRotateZ);
		cc.Move(new Vector3());

		if(transform.position.z <= -1){
			Destroy(gameObject);
		}

		pC = GameObject.Find("Player").GetComponent<PlayerCtrl>();

	}

	void OnTriggerEnter(Collider hit){
		if(hit.tag == "Player"){
			pC.audioFlg = true;
			TitleScene.GameOver();
		}
	}

}
