using UnityEngine;
using System.Collections;

public class started : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.JoystickButton9)) Application.LoadLevel("Main");
	}
}
