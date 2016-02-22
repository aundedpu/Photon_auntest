using UnityEngine;
using System.Collections;

public class Lauch : MonoBehaviour {
	public GameObject bulletPref ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void shoot(){
//		GameObject bullet_Go = (GameObject)Instantiate(bulletPref,transform.position,Quaternion.identity);
//		if(transform.rotation.y == 0){
//			bullet_Go.GetComponent<Rigidbody2D> ().AddForce(new Vector2 (500*1, 0),ForceMode2D.Force);
//		}else{
//			bullet_Go.GetComponent<Rigidbody2D> ().AddForce(new Vector2 (500*-1, 0),ForceMode2D.Force);
//		}	
		GameObject bullet_Go = PhotonNetwork.Instantiate ("Bullet",
			transform.position,
			transform.rotation,
			0);
		if(transform.rotation.y == 0){
			bullet_Go.GetComponent<Rigidbody2D> ().AddForce(new Vector2 (1500*1, 0),ForceMode2D.Force);
		}else{
			bullet_Go.GetComponent<Rigidbody2D> ().AddForce(new Vector2 (1500*-1, 0),ForceMode2D.Force);
		}	
	}
}
