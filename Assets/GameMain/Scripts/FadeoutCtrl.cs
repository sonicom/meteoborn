using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeoutCtrl : MonoBehaviour {

	public Image image;
	public float timer;
	public bool fadeFlg;

	TitleScene tS;

	void Start()
	{
		timer = 0;
		image = GetComponent<Image>();
		fadeFlg = false;

		tS = GameObject.Find("Scene").GetComponent<TitleScene>();

	}
	
	void Update()
	{
		if(fadeFlg == true){
			if(timer <=	1.5f){
				timer += Time.deltaTime;
				image.color = new Color(0,0,0,timer);
			}else{
				fadeFlg = false;
				timer = 0;
				tS.sceneupdateFlg = true;
			}
		}
	}
}