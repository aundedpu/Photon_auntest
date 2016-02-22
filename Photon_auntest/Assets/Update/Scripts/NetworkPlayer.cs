using UnityEngine;
using System.Collections;

public class NetworkPlayer : Photon.MonoBehaviour {

	public Camera camMyself;
	public float p_Hearth ;


	private Vector3 correctPlayerPos = Vector2.zero; //We lerp towards this
	private Quaternion correctPlayerRot = Quaternion.identity; //We lerp towards this
	private bool appliedInitialUpdate;


	// Use this for initialization
	void Start () {
		if(photonView.isMine){
			camMyself.gameObject.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!photonView.isMine)
		{
			//Update remote player (smooth this, this looks good, at the cost of some accuracy)
			transform.position = Vector3.Lerp(transform.position, correctPlayerPos, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp(transform.rotation, correctPlayerRot, Time.deltaTime * 5);
//			Debug.Log ("" + photonView.viewID + " " + p_Hearth );
		}


	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if (stream.isWriting) {
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
			stream.SendNext (GetComponent<Rigidbody2D> ().velocity);
			stream.SendNext (p_Hearth);
		} else {
			correctPlayerPos = (Vector3)stream.ReceiveNext();
			correctPlayerRot = (Quaternion)stream.ReceiveNext();
			GetComponent<Rigidbody2D>().velocity = (Vector2)stream.ReceiveNext();
			p_Hearth = (float)stream.ReceiveNext();
			if(p_Hearth <= 0 ){
				GUIControllerDemo.instance.winOpen ();
				GUIControllerDemo.instance.isEnd = true;
			}

			Debug.Log ("photonId "+ photonView.viewID + " " + p_Hearth);
			if (!appliedInitialUpdate) {
				appliedInitialUpdate = true;
				transform.position = correctPlayerPos;
				transform.rotation = correctPlayerRot;
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				p_Hearth = 0;
			}
		}
	}

}
