using UnityEngine;
using System.Collections;

public enum ColorType { red, blue, yellow };


public class ColorTypes : MonoBehaviour {

	public Color redColor 	 = Color.red;
	public Color blueColor   = Color.blue;
	public Color yellowColor = Color.yellow;

	public static Color[] colors = new Color[3];

	// Use this for initialization
	void Awake () {
		colors[0] = redColor;
		colors[1] = blueColor;
		colors[2] = yellowColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static Color ColorByType(ColorType type) {
		if(type == ColorType.red) 	 { return colors[0]; }
		if(type == ColorType.blue)   { return colors[1]; }
		if(type == ColorType.yellow) { return colors[2]; }
		return Color.white;
	}
}
