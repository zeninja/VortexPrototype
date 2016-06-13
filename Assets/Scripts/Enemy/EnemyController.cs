using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ColorManager))]
public class EnemyController : MonoBehaviour {

	ColorManager colorManager;
	SpriteRenderer sprite;

	public int startingHP = 1;
	int hp;

	bool initialized;

//	public float fireRate = .2f;
//	public float bulletSpeed = 10;

//	public ColorType bulletColor;

	// Use this for initialization
	void Start () {
		colorManager = GetComponent<ColorManager>();
		sprite = GetComponent<SpriteRenderer>();
//		BasicFire();

//		RandomizeColor();
		hp = startingHP;

		initialized = true;
	}

	void OnEnable() {
		// OnEnable happens before start so we need to make sure we wait for start to be called
		if(initialized) {
			RandomizeColor();
			hp = startingHP;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void RandomizeColor() {
		// Randomizes the enemy color
		colorManager.RandomizeColor();
	}

//	void Fire() {
//		GameObject bullet = ObjectPool.instance.GetObjectForType("Bullet", false);
//		bullet.transform.position = transform.position;
//
//		bullet.GetComponent<BulletController>().SetRotation();
//		bullet.GetComponent<BulletController>().owner = gameObject;
//		bullet.GetComponent<BulletController>().moveSpeed = bulletSpeed;
//		bullet.GetComponent<ColorManager>().RandomizeColor();
////		bullet.GetComponent<ColorManager>().myColor = bulletColor;
////		bullet.GetComponent<ColorManager>().UpdateSpriteColor();
//	}
//
//	void BasicFire() {
//		InvokeRepeating("Fire", 0, fireRate);
//	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			
		}
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
		Color originalColor = sprite.color;
		sprite.color = Color.white;
		yield return new WaitForSeconds(.05f);
		sprite.color = originalColor;
	}

	void HandleDeath() {
		Reset();
		ObjectPool.instance.PoolObject(gameObject);
	}

	void Reset() {
		hp = startingHP;
	}
}
