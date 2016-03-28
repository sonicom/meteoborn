using UnityEngine;
using System.Collections;

public class BulletCtrl : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip audioClip;

	float deletetimer;

	BlockCtrl bc;

	Score sc;

	PlayerCtrl pC;

	// Use this for initialization
	void Start () {

		sc = GameObject.Find ("Canvas").GetComponent<Score>();

		pC = GameObject.Find("Player").GetComponent<PlayerCtrl>();

		audioSource = GetComponent<AudioSource>();
		audioSource.clip = audioClip;

		deletetimer = 0;

	}
	
	// Update is called once per frame
	void Update () {

		deletetimer += Time.deltaTime;

		transform.position += transform.forward * 1.5f;

		if(deletetimer > 1.5f){
			Destroy(gameObject);
		}

	}

	void OnTriggerEnter(Collider hit){
		bc = hit.gameObject.GetComponent<BlockCtrl>();
		if(hit.tag == "Block"){
			bc.blockHp--;
			Destroy(gameObject);
			if(bc.blockHp <= 0){
				pC.audioSource.PlayOneShot(audioClip);
				Destroy(hit.gameObject);
				//sc.score++;
			}
		}
	}

}
