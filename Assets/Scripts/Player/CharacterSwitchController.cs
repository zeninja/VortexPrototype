using UnityEngine;
using System.Collections;

public class CharacterSwitchController : MonoBehaviour {

	public enum ColorType { red, blue, yellow };
	public ColorType color;
	public ColorManager playerColorManager; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTap(TapGesture gesture){
		if (gesture.Selection != null) {
			if (gesture.Selection.name == "CharacterR" && color == ColorType.red) {
				Debug.Log (color);
				playerColorManager.SetColorByIndex (0);
			} else if (gesture.Selection.name == "CharacterB" && color == ColorType.blue) {
				Debug.Log (color);
				playerColorManager.SetColorByIndex (1);
			} else if (gesture.Selection.name == "CharacterY" && color == ColorType.yellow) {
				Debug.Log (color);
				playerColorManager.SetColorByIndex (2);
			} else {
				Debug.Log ("color error");
			}

		}

	}
}
