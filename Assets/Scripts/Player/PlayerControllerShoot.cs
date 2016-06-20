using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ColorManager))]
public class PlayerControllerShoot : MonoBehaviour {

	SpriteRenderer sprite;
	ColorManager colorManager;

	[System.NonSerialized]
	public float inputHorizontal;
	[System.NonSerialized]
	public bool inputSwitch;

	public float xBound = 5;
	public float moveSpeed = 1;
	public float fireRate = .2f;

	public int hp = 10;

	int colorIndex = 0;

	public static Vector2 currentPos;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		colorManager = GetComponent<ColorManager>();
		colorManager.UpdateSpriteColor();

		//InvokeRepeating("Fire", 0, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
		ManageInput();
		CheckBounds();

		currentPos = transform.position;
	}

	void ManageInput() {
//
	}
	void OnTap( TapGesture gesture ) 
	{ 
		if(gesture.Selection != null){

			if (gesture.Selection.name == "Player") {
				Fire (); 
			} 
		}
	}

/*	void IncrementColor() {
		colorIndex++;
		if (colorIndex >= 3) {
			colorIndex = 0;
		}

		colorManager.SetColorByIndex(colorIndex);
	}
*/

	void CheckBounds() {
		if (Mathf.Abs(transform.position.x) > xBound) {
			transform.position = new Vector3(Mathf.Sign(transform.position.x) * xBound, 0, 0);
		}
	}

	void Fire() {
		GameObject bullet = ObjectPool.instance.GetObjectForType("Bullet", false);
		bullet.transform.position = transform.position;
		bullet.transform.rotation = transform.rotation;

		bullet.GetComponent<BulletController>().owner = gameObject;
		bullet.GetComponent<ColorManager>().myColor = colorManager.myColor;
		bullet.GetComponent<ColorManager>().UpdateSpriteColor();
	}

	void HandleHit(int dmg) {
		hp -= dmg;
	//	Flash();

		if (hp <= 0) {
		//	HandleDeath();
		}
	}

}
