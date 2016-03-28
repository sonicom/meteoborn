using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public GameObject enemy;

	int i;

	// Use this for initialization
	void Start () {

		i = 0;

	}
	
	// Update is called once per frame
	void Update () {

		// 乱数 10/1 でクリエ関数呼び出し
		i = Random.Range(0,60);
		if(i == 0){
			EnemyCreate();
		}

	}

	void EnemyCreate(){
		Instantiate(enemy,
		            transform.position + new Vector3(Random.Range(-4,4),Random.Range(-4,4)),
		            Quaternion.Euler(0,180,0));
	}

}
