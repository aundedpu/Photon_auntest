using UnityEngine;
using System.Collections;

public class RoomData : MonoBehaviour {

	public UILabel room_Name ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void JoinRoom(){
		PhotonNetwork.JoinRoom (room_Name.text);
	}
}
