﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ColorManager))]
public class PlayerController : MonoBehaviour {

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

		InvokeRepeating("Fire", 0, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
		ManageInput();
		CheckBounds();

		currentPos = transform.position;
	}

	void ManageInput() {
//		transform.position += new Vector3(inputHorizontal * moveSpeed * Time.deltaTime, 0, 0);

		if (inputSwitch) {
			IncrementColor();
		}
	}

	void IncrementColor() {
		colorIndex++;
		if (colorIndex >= 3) {
			colorIndex = 0;
		}

		colorManager.SetColorByIndex(colorIndex);
	}

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
		Flash();

		if (hp <= 0) {
			HandleDeath();
		}
	}

	void Flash() {
		StartCoroutine("FlashColor");
	}

	IEnumerator FlashColor() {
		sprite.color = Color.white;
		yield return new WaitForSeconds(.05f);
		colorManager.UpdateSpriteColor();
	}

	void HandleDeath() {
		Debug.Log("Game over!!");
		Time.timeScale = 0;
	}

}
