using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip audioClip;
	public AudioClip audioCliptoGameover;
	public bool audioFlg;

	TitleScene ts;

	CharacterController cc;

	GameObject shotcursor;

	Camera maincamera;
	Camera subcamera;

	public GameObject bullet;

	// プレイヤーを回転させるコア
	public GameObject core;
	// プレイヤーの回転軸値
	float angleX = 0;
	float angleY = 0;
	float angleZ = 0;
	
	// プレイヤーの向き
	Vector3 movement;
	// プレイヤーの移動速度
	float speed = 8.0f;

	// 弾タイマー
	float bullettimer = 0;

	TitleScene tS;

	// Use this for initialization
	void Start () {
	
		cc = GetComponent<CharacterController>();

		shotcursor = GameObject.Find("ShotCursor");

		maincamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		subcamera =GameObject.Find("Sub Camera").GetComponent<Camera>();
		subcamera.enabled = false;

		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = audioClip;
		audioSource.clip = audioCliptoGameover;
		audioFlg = false;

		ts = GameObject.Find("Scene").GetComponent<TitleScene>();

	}
	
	// Update is called once per frame
	void Update () {

		if(ts.allStopFlg == false){
			PlayerMove();
			ShotCreate();
		}

		LookCursor();

		if(audioFlg == true){
			audioSource.PlayOneShot(audioCliptoGameover);
			audioFlg = false;
		}

		//CameraChange();

	}

	// PlayerMove関数
	void PlayerMove(){
		movement = Vector3.zero;
		if(Input.GetKey(KeyCode.UpArrow)){
			movement += transform.up;
			if(angleX > -15){
				angleX -= 0.5f;
			}
		}else if(angleX < 0){
			angleX += 0.5f;
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			movement += -transform.up;
			if(angleX < 15){
				angleX += 0.5f;
			}
		}else if(angleX > 0){
			angleX -= 0.5f;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			movement += transform.right;
			if(angleZ > -35){
				angleZ -= 5.0f;
			}
			if(angleY < 15){
				angleY += 0.5f;
			}
		}else{
			if(angleZ < 0){
				angleZ += 1.0f;
			}
			if(angleY > 0){
				angleY -= 0.5f;
			}
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			movement += -transform.right;
			if(angleZ < 35){
				angleZ += 5.0f;
			}
			if(angleY > -15){
				angleY -= 0.5f;
			}
		}else{
			if(angleZ > 0){
				angleZ -= 1.0f;
			}
			if(angleY < 0){
				angleY += 0.5f;
			}
		}
		core.transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);
		//Debug.Log ("Euler:" + core.transform.rotation.eulerAngles + "Angle(" + angleX + "," + angleZ + ")");
		if(Input.GetKey(KeyCode.LeftShift)){
			cc.Move (movement * speed / 2 * Time.deltaTime);
		}else{
			cc.Move (movement * speed * Time.deltaTime);
		}
	}

	// 弾作る関数
	void ShotCreate(){
		bullettimer += Time.deltaTime;
		if(Input.GetKey(KeyCode.Z)){
			if(bullettimer > 0.1f){
				Instantiate(bullet, transform.position + core.transform.forward + core.transform.right / 2, core.transform.rotation);
				Instantiate(bullet, transform.position + core.transform.forward - core.transform.right / 2, core.transform.rotation);
				bullettimer = 0;
				audioSource.PlayOneShot(audioClip);
			}
		}
	}

	// ショットカーソルをプレイヤーの向きに合わせる
	void LookCursor(){
		shotcursor.transform.rotation = Quaternion.identity;
	}

	// CameraChange関数
	void CameraChange(){
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if(maincamera.enabled){
				maincamera.enabled = false;
				subcamera.enabled = true;
			}else{
				maincamera.transform.position = new Vector3(transform.position.x,
				                                            transform.position.y,
				                                            maincamera.transform.position.z);
				maincamera.enabled = true;
				subcamera.enabled = false;
			}
		}
	}

}
