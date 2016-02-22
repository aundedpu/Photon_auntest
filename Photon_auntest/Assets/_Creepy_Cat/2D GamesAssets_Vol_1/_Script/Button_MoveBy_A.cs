using UnityEngine;
using System.Collections;

public class Button_MoveBy_A : MonoBehaviour {

//	 TO UN-COMMENT

//	public Sprite NormalSprite;
//	public Sprite PressedSprite;
//
//	public GameObject ObjectToPunchScale;
//	public AudioClip SoundWhenClicked;
//
//	public float PunchX = 0.2f;
//	public float PunchY = 0.3f;
//	public float PunchZ = 0.0f;
//
//	public GameObject ObjectToMove;
//
//
//	 public iTween.EaseType EaseType = iTween.EaseType.easeOutElastic;
//
//	public float MoveX = 0.0f;
//	public float MoveY = 0.0f;
//	public float MoveZ = 0.0f;
//	
//	public float Speed = 2.0f;
//	public float Delay = 0.1f;
//
//
//	private bool MouseOnButton;
//
//	// Init at start
//	void Start(){
//		// Audio clip setup
//		if (SoundWhenClicked != null){
//			audio.clip = SoundWhenClicked;
//		}
//	}
//
//	// When mouse release a sprite
//	void OnMouseExit() {
//		MouseOnButton = false;
//	}
//
//	// When mouse is on sprite
//	void OnMouseOver() {
//
//		// If there is a object to move
//		if (ObjectToPunchScale != null){
//
//			// If the mouse is on button
//			if (MouseOnButton == false){
//
//
//				iTween.PunchScale(ObjectToPunchScale, iTween.Hash("x", PunchX, "y", PunchY ,"z", PunchZ  , "time", 0.8f , "islocal" , true));
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
//		// I change the sprite
//		this.GetComponent<SpriteRenderer>().sprite = PressedSprite;
//
//		MouseOnButton = true;
//
//		// If audio ok
//		if (SoundWhenClicked != null){
//			audio.Play();
//		}
//	
//	}
//
//	// When mouse release
//	void OnMouseUp() {
//
//		// I change the sprite and i change the text
//		this.GetComponent<SpriteRenderer>().sprite = NormalSprite;
//
//		// If mouse release
//		if (MouseOnButton == true){
//
//			// Launch animation
//			if (ObjectToMove != null){
//				iTween.Stop(ObjectToMove);
//				iTween.MoveBy(ObjectToMove, iTween.Hash("x", MoveX, "y",MoveY, "z",MoveZ, "delay", Delay, "time", Speed, "easeType", EaseType, "islocal" , true));
//
//				MouseOnButton = false;
//			}
//		}
//
//	}

}
