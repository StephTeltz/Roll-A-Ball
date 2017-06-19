using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {
	
	/// Use Update () because we are not using forces 
	void Update () {

		/// Rotate the transform
		transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
