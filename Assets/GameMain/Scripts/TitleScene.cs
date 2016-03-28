using UnityEngine;
using System.Collections;

public class TitleScene : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip audioClip;

	public GameObject title;
	public GameObject game;
	public GameObject result;
	int scene;
	public static bool gameOverflg;

	public GameObject player;
	public GameObject playerCore;

	public static int scoreStock;

	public Score sc;

	FadeoutCtrl foc;

	public bool sceneupdateFlg;

	public bool allStopFlg;

	BlockCtrl bC;

	// Use this for initialization
	void Start () {

		scene = 0;
		scoreStock = 0;

		sceneupdateFlg = false;

		allStopFlg = false;

		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = audioClip;

	}
	
	// Update is called once per frame
	void Update () {
		foc = GameObject.Find("fadeout").GetComponent<FadeoutCtrl>();
		switch(scene){
		case 0:
			if(Input.GetKeyDown("z")){
				audioSource.Play();
				sceneupdateFlg = true;
				foc.fadeFlg = true;
			}
			if(sceneupdateFlg == true){
				if(foc.fadeFlg == false){
					title.SetActive(false);
					game.SetActive(true);
					result.SetActive(false);
					scene = 1;
					sceneupdateFlg = false;
				}
			}
			break;
		case 1:
			if(gameOverflg == true){
				foc.fadeFlg = true;
				allStopFlg = true;
				if(sceneupdateFlg == true){
					scoreStock = sc.score;
					title.SetActive(false);
					game.SetActive(false);
					result.SetActive(true);
					scene = 2;
					gameOverflg = false;
					sceneupdateFlg = false;
					allStopFlg = false;
				}
			}
			break;
		case 2:
			if(Input.GetKeyDown("z")){
				audioSource.Play();
				sceneupdateFlg = true;
				foc.fadeFlg = true;
			}
			if(sceneupdateFlg == true){
				if(foc.fadeFlg == false){
					Application.LoadLevel("Title");
					sceneupdateFlg = false;
				}
			}
			break;
		}
	}
	public static void GameOver(){
		gameOverflg = true;
	}

}