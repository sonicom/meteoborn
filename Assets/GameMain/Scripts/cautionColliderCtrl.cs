using UnityEngine;
using System.Collections;

public class cautionColliderCtrl : MonoBehaviour {

	AudioSource audioSource;

	public AudioClip audioClip;

	float timer;

	// Use this for initialization
	void Start () {
	
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = audioClip;

		timer = 0;

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}

	void OnTriggerStay(Collider hit){
		if(hit.tag == "Block"){
			if(timer >= 0.2f){
				audioSource.PlayOneShot(audioClip);
				timer = 0;
			}
		}
	}
}
