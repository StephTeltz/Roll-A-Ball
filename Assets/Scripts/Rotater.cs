using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {
	/// <summary>
	/// Rotates collectable cubes 
	/// </summary>
	 
	void Update () {
		// Rotate the cube's transform
		transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
