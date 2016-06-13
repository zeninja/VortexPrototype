using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	PlayerController player;

	float inputHorizontal;
	bool inputSwitch;

	// Use this for initialization
	void Start () {
		player = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		inputHorizontal = Input.GetAxisRaw("Horizontal");
		inputSwitch 	= Input.GetKeyDown(KeyCode.Space);

		player.inputHorizontal = inputHorizontal;
		player.inputSwitch 	   = inputSwitch;
	}
}
