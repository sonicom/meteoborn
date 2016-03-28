using UnityEngine;
using System.Collections;

public class BlockGenerator : MonoBehaviour {
	
	public GameObject block1;
	public GameObject block2;
	
	float timer;
	float timer2;
	float kasokutimer;

	Score sc;

	GameObject bGenerator;
	GameObject clone;

	// Use this for initialization
	void Start () {

		sc = GetComponent<Score>();

		timer = 0;
		timer2 = 0;
		kasokutimer = 1.5f;

		bGenerator = GameObject.Find ("Block Generator");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// 乱数 10/1 でクリエ関数呼び出し
		/*timer = Random.Range(0,60);
		if(timer == 0){
			BlockCreate();
		}*/

		timer += Time.deltaTime;
		if(timer >= kasokutimer){
			BlockCreate1();
			BlockCreate2();

			timer = 0;
		}
		timer2 += Time.deltaTime;
		if(kasokutimer >= 0.1f && timer2 >= 0.5f){
			kasokutimer -= 0.02f;
			timer2 = 0;
		}

	}
	
	void BlockCreate1(){
		clone = (GameObject)Instantiate(block1,
		            transform.position + new Vector3(Random.Range(-4,5),Random.Range(-4,5)),
		            Quaternion.Euler(0,180,0));
		clone.transform.parent = bGenerator.transform;
	}
	void BlockCreate2(){
		clone = (GameObject)Instantiate(block2,
		            transform.position + new Vector3(Random.Range(-4,5),Random.Range(-4,5)),
		            Quaternion.Euler(0,180,0));
		clone.transform.parent = bGenerator.transform;
	}

}
