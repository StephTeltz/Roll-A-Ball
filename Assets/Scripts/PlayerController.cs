using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	/// Public variables become available in the Unity object inspector 
	public float speed;
	public Text countText;
	public Text winText;

	// Private variables are not available in the Unity object inspector
	// They may only be adjusted here
	// Must add a UI component to display score to the user 
	private Rigidbody rb;
	private int count;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		count = 0; 
		SetCountText ();
		winText.text = "";
	}

	/// Check every frame for player input
	/// Apply input to the object every frame  

	///
	/// void Update() is called before rendering a frame
	/// Most of the game code is there
	///
	/// void FixedUpdate() is called before physics calculations
	/// Physics code goes there
	///
	void FixedUpdate () {

		/// We move the ball by applying forces to the RigidBody
		/// CMD + ' for API

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		/// Translate x, y, z to Vector3
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		/// Apply a force to the sphere
		rb.AddForce(movement * speed);
	}
		
	///  Detects collisions 
	/// Called when an object touches a trigger collider 
	void OnTriggerEnter(Collider other) {
		/// Tag must be created, added and applied to all pre-fabs
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1; // Add 1 to score
			SetCountText ();
		}
	}

	void SetCountText () {
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
