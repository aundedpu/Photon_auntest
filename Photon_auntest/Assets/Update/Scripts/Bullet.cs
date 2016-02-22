using UnityEngine;
using System.Collections;

public class Bullet : Photon.MonoBehaviour {

	public float time ;
	public float damage ;
	private Vector3 correctPlayerPos = Vector2.zero; //We lerp towards this
	private Quaternion correctPlayerRot = Quaternion.identity; //We lerp towards this
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		DestroyObject (gameObject, time);
		if (!photonView.isMine)
		{
			//Update remote player (smooth this, this looks good, at the cost of some accuracy)
			transform.position = Vector3.Lerp(transform.position, correctPlayerPos, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp(transform.rotation, correctPlayerRot, Time.deltaTime * 5);
		}

	}
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
		if (stream.isWriting) {
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
			stream.SendNext (GetComponent<Rigidbody2D> ().velocity);
		} else {
			correctPlayerPos = (Vector3)stream.ReceiveNext();
			correctPlayerRot = (Quaternion)stream.ReceiveNext();
			GetComponent<Rigidbody2D>().velocity = (Vector2)stream.ReceiveNext();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			if (!photonView.isMine) {
				NetworkPlayer player = other.gameObject.GetComponent<NetworkPlayer> ();
				player.p_Hearth -= damage;
				GUIControllerDemo.instance.OndecreaseHp (player.p_Hearth);
			}
			gameObject.SetActive (false);
		}
	}

}
