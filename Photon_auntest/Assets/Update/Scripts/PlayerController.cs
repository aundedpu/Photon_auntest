using UnityEngine;
using System.Collections;

public class PlayerController : Photon.MonoBehaviour {

	public float speed  ;
	public float jump  ;
//	public Camera cameraPlayer ;

	private Rigidbody2D playerrigidbody;
	public SpriteRenderer body;
	public Lauch lauchshoot;
	private Vector2 myselfRotate;

	// Use this for initialization
	void Start () {
		playerrigidbody = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		if(photonView.isMine){
			if ( GetComponent<NetworkPlayer>().p_Hearth > 0) {
				float moveHorizontal = Input.GetAxis ("Horizontal") * speed;
				playerrigidbody.velocity = new Vector2 (moveHorizontal * speed, playerrigidbody.velocity.y);
			
				if (Input.GetKeyDown (KeyCode.Space)) {
					playerrigidbody.AddForce (new Vector2 (0, jump * 150), ForceMode2D.Force);
				} 
				if (moveHorizontal > 0) {
					body.gameObject.transform.rotation = Quaternion.Euler (Vector3.zero);
				}
				if (moveHorizontal < 0) {
					body.gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
				}
				if (Input.GetMouseButtonDown (0)) {
					lauchshoot.shoot ();
				}
			} else {
				GUIControllerDemo.instance.loseOpen ();
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
//		if(other.tag == "bullet"){
//			photonView.RPC ("destroyGameObject",RPCMode.All,other.gameObject);
//			DestroyObject(other.gameObject);
//			NetworkPlayer networkplayer = GetComponent<NetworkPlayer> ();
//			networkplayer.p_Hearth -= 10;
//			if(photonView.isMine){
//				GUIControllerDemo.instance.OndecreaseHp (networkplayer.p_Hearth);
//			}
//		}

	}



}
