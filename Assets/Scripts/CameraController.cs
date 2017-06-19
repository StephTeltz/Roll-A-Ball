using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	/// <summary>
	/// Controls the third-person camera relative to the player
	/// </summary>

	public GameObject player;

	private Vector3 offset;

	// Start () is used for initialization
	void Start () {
		// Calculate initial camera offset relative to player 
		offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called after each frame has been processed
	void LateUpdate () {
		// Calculate camera offset after each player transform
		transform.position = player.transform.position + offset;
	}
}
