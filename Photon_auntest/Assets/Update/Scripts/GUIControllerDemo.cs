using UnityEngine;
using System.Collections;

public class GUIControllerDemo : MonoBehaviour {
	
	public UISlider hp_Bar;
	public static GUIControllerDemo instance ;
	private int hp ;
	public UILabel Win;
	public UILabel Lose;

	public UIPanel JoinLobby;
	[HideInInspector]
	public bool isEnd = false;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OndecreaseHp(float php){
		hp_Bar.value = php / 100;
	}

	public void winOpen(){
		Win.gameObject.SetActive (true);
	}

	public void loseOpen(){
		Lose.gameObject.SetActive (true);
	}

	public void closeLobby(){
		JoinLobby.gameObject.SetActive (false);
	}

	public void openHpbar(){
		hp_Bar.gameObject.SetActive (true);

	}

}
