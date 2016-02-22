using UnityEngine;
using System.Collections;
using PlayFab;
using PlayFab.ClientModels;



public class GameInstance : MonoBehaviour {

	public static GameInstance instance ;
	public string TitleID;
	public string AppID ;

	void Awake(){
		PlayFabSettings.TitleId = TitleID;
	}

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
