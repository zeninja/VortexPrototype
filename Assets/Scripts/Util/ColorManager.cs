using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour {

	public ColorType myColor;
	SpriteRenderer sprite;

	void Awake() {
		sprite = GetComponent<SpriteRenderer>();
	}

	public void SetNewType(ColorType newType) {
		myColor = newType;
		UpdateSpriteColor();
	}

	public void SetColorByIndex(int index) {
		myColor = (ColorType)index;
		UpdateSpriteColor();
	}

	public void UpdateSpriteColor() {
		sprite.color = ColorTypes.ColorByType(myColor);
	}

	public void RandomizeColor() {
		myColor = (ColorType)Random.Range(0, 3);
		UpdateSpriteColor();
	}

	public static bool CompareColorType(ColorType color1, ColorType color2) {
		return color1 == color2;
	}
}
