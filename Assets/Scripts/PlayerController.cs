using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required namespace for UI

public class PlayerController : MonoBehaviour {
	/// <summary>
	/// Controls the player's movements and tracks collectables picked up
	/// </summary>

	// Public variables become available in the Unity object inspector 
	public float speed;
	public Text countText;
	public Text winText;

	// Private variables are only accessible within the class
	// Must add a UI component to display private variables such as score to the user 
	private Rigidbody rb;
	private int count;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		count = 0; 
		SetCountText ();
		winText.text = ""; 
	}

	void FixedUpdate () {
		/// <summary>
		/// Applies force to the ball, causing it to move according to the user's input
		/// </summary>

		// Get horiz. and vert. input from the user 
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Translate x, y, z coords. to a Vector3
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // y = 0.0f because only 2D motion allowed

		// Move the sphere by applying a force to it's Rigidbody 
		rb.AddForce(movement * speed);
	}
		
	void OnTriggerEnter(Collider other) {
		/// <summary>
		/// Detects collisions , called when an object touches a trigger collider 
		/// </summary>

		// Deactivates (hides) collectables when the player collides with them, and keeps score
		if (other.gameObject.CompareTag ("Pick Up")) { // Note: Tags must be created, added and applied to all pre-fabs within Unity
			other.gameObject.SetActive (false);
			count = count + 1; // Add 1 to score
			SetCountText ();
		}
	}

	void SetCountText () {
		/// <summary>
		/// Displays current collectables count and a message when the player wins 
		/// </summary>
		countText.text = "Count: " + count.ToString ();
		if (count >= 16) {
			winText.text = "You Win!";
		}
	}
}

/// Notes:
///
/// Any Unity object with a Collider and a Rigidbody is dynamic
/// Any Unity object with a Collider and no Rigidbody is static 
/// Unity updates the static collider cache each frame
/// If a dynamic object is static it will cause unnecessary overhead
/// So be sure dynamic objects have a Rigidbody
/// 
/// void Update() is called before rendering a frame => where most game code lives 
/// void FixedUpdate() is called before physics calculations => where physics code lives 
/// void LateUpdate() is called after frame updates are complete => where camera code lives
