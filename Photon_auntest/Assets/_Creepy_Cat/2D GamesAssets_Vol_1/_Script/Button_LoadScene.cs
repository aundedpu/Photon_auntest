using UnityEngine;
using System.Collections;

public class Button_LoadScene : MonoBehaviour {

	// TO UN-COMMENT


//	public Sprite NormalSprite;
//	public Sprite PressedSprite;
//	public string LevelToGo;
//	public string PressedText;
//
//	public GameObject ObjectToPunchScale;
//	public AudioClip SoundWhenClicked;
//
//	public float PunchX = 0.2f;
//	public float PunchY = 0.3f;
//	public float PunchZ = 0.0f;
//
//	private string OriginalText;
//	private bool MouseOnButton;
//
//	void Start() {
//		// Grab original button text
//		OriginalText = this.GetComponentInChildren<TextMesh>().text ;
//
//		// Audio clip setup
//		if (SoundWhenClicked != null){
//			audio.clip = SoundWhenClicked;
//		}
//	}
//
//	void OnMouseExit() {
//		MouseOnButton = false;
//	}
//
//	void OnMouseOver() {
//
//		// If there is a object to move
//		if (ObjectToPunchScale != null){
//
//			// If the mouse is on button
//			if (MouseOnButton == false){
//				iTween.PunchScale(ObjectToPunchScale, iTween.Hash("x", PunchX, "y", PunchY ,"z", PunchZ  , "time", 0.8f , "islocal" , true));
//				//iTween.MoveBy(ObjectToPunchScale, iTween.Hash("x", 2, "easeType", "easeOutElastic", "loopType", "pingPong", "delay", 0.0f));
//			}
//
//		}
//
//		MouseOnButton = true;
//	}
//
//	// When mouse click
//	void OnMouseDown() {
//
//		// I change the sprite and i change the text
//		this.GetComponent<SpriteRenderer>().sprite = PressedSprite;
//		this.GetComponentInChildren<TextMesh>().text = PressedText;
//
//		this.GetComponentInChildren<TextMesh>().transform.localPosition = new Vector3(0.06f, -0.06f, -0.2f);
//
//		MouseOnButton = true;
//
//		// If audio ok
//		if (SoundWhenClicked != null){
//			audio.Play();
//		}
//	}
//
//	// When mouse release
//	void OnMouseUp() {
//
//		// I change the sprite and i change the text
//		this.GetComponent<SpriteRenderer>().sprite = NormalSprite;
//		this.GetComponentInChildren<TextMesh>().text = OriginalText;
//
//		this.GetComponentInChildren<TextMesh>().transform.localPosition = new Vector3(0.0f, -0.0f, -0.2f);
//
//		// If mouse release the load level
//		if (MouseOnButton == true){
//			Application.LoadLevel(LevelToGo);
//		}
//
//	}

}
