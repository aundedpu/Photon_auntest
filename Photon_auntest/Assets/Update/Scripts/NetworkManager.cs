using UnityEngine;
using System.Collections;
using System.Collections.Generic ;
using PlayFab;
using PlayFab.ClientModels;
public class NetworkManager : Photon.MonoBehaviour {

	const string Version = "v0.0.1";
	public string roomName = "VVR" ;
	public string playerPrefabName ;
	public Transform spawnPoint;
	public UIGrid gridPanel;
	public GameObject roomItemPref;

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings (Version);

	}

	private bool  editBug = false ;
	// Update is called once per frame
	void Update () {
//		Debug.Log ("COUNT "+ PhotonNetwork.GetRoomList().Length);

		if(PhotonNetwork.insideLobby)
		{
			Debug.Log("Inside a Lobby");
			Debug.Log("roomsize"+PhotonNetwork.GetRoomList().Length.ToString());
			Debug.Log("gridsize " + gridPanel.GetChildList().size);
			if(PhotonNetwork.GetRoomList ().Length == 0 && gridPanel.GetChildList().size == 1  ){
				editBug = true;
				if(editBug == true){
					NGUITools.Destroy(gridPanel.GetChild(0).gameObject);
					editBug = false;
				}
			}
		}

	}

	void OnJoinedLobby(){
//		RoomOptions roomOptions = new RoomOptions (){ isVisible = false, maxPlayers = 2 };
//		PhotonNetwork.CreateRoom (roomName , roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom(){
		GUIControllerDemo.instance.closeLobby ();
		GUIControllerDemo.instance.openHpbar ();
		GameObject go =	PhotonNetwork.Instantiate (playerPrefabName,
				spawnPoint.position,
				spawnPoint.rotation,
				0);
		

	}

	public void CreateRoom(){
		RoomOptions roomOptions = new RoomOptions (){ isVisible = true, maxPlayers = 2  };
		PhotonNetwork.CreateRoom(DataPlayer.dataPlayer, roomOptions, TypedLobby.Default); 
		GUIControllerDemo.instance.closeLobby ();
		GUIControllerDemo.instance.openHpbar ();

	}

	void OnReceivedRoomListUpdate()
	{
		
		//List here.
		if (PhotonNetwork.GetRoomList ().Length == 0) {
			
		
		} else {

//			for(int i = 0 ;i<PhotonNetwork.GetRoomList().Length ;i++) {
//				if(gridPanel.GetChildList().size > 0){
//					gridPanel.RemoveChild (gridPanel.GetChild(i));
//					NGUITools.Destroy(gridPanel.GetChild(i).gameObject);
//				}
//			}	
			RoomInfo[] roomList = PhotonNetwork.GetRoomList ();

			if(roomList.Length == 0){

			}else{
				if(gridPanel.GetChildList().size <= 0) {
					for (int i = 0; i < roomList.Length; i++) {
						if (roomList.Length != (gridPanel.GetChildList ().size)) {
							GameObject go_store = (GameObject)Instantiate (roomItemPref, new Vector3 (-141, 72, 0), Quaternion.identity);
							gridPanel.AddChild (go_store.transform);
							go_store.transform.localScale = new Vector3 (1f, 1f, 1f);
							go_store.GetComponent<RoomData> ().room_Name.text = roomList [i].name;
						}
					}
				}else if (roomList.Length >= (gridPanel.GetChildList ().size)) {
					for (int i = 0; i < roomList.Length; i++) {
						if (roomList.Length != (gridPanel.GetChildList ().size)) {
							GameObject go_store = (GameObject)Instantiate (roomItemPref, new Vector3 (-141, 72, 0), Quaternion.identity);
							gridPanel.AddChild (go_store.transform);
							go_store.transform.localScale = new Vector3 (1f, 1f, 1f);
							go_store.GetComponent<RoomData> ().room_Name.text = roomList [(roomList.Length - 1)].name;
						}
					}
				}else if (roomList.Length <= (gridPanel.GetChildList ().size)){
					foreach(Transform transformGrid in gridPanel.GetChildList()) {
						NGUITools.Destroy(transformGrid.gameObject);
					}
					foreach (RoomInfo roominfo in PhotonNetwork.GetRoomList()) {
						GameObject go_store = (GameObject)Instantiate (roomItemPref, new Vector3 (-141, 72, 0), Quaternion.identity);
						gridPanel.AddChild (go_store.transform);
						go_store.transform.localScale = new Vector3 (1f, 1f, 1f);
						go_store.GetComponent<RoomData> ().room_Name.text = roominfo.name;
					}
				}
			}
//			Debug.Log ("Size " + gridPanel.GetChildList ().size);

		}
	}
		
}
