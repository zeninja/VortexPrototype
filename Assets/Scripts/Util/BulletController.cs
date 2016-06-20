using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ColorManager))]
public class BulletController : MonoBehaviour {

	public GameObject owner;
	ColorManager colorManager;

	public int damage;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		colorManager = GetComponent<ColorManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!enabled) { return; }
		transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Bullet")) { return; }

		ColorType otherColor = other.gameObject.GetComponent<ColorManager>().myColor;

		if (other.gameObject != owner) {

			if (other.CompareTag("Player")) {
				// The player should ONLY be damaged by bullets of other colors
				if (!ColorManager.CompareColorType(colorManager.myColor, otherColor)) {
					other.SendMessage("HandleHit", damage);
					HandleDeath();
				}
			} else {
				// Enemies should be damaged by bullets of all colors
				if (other.name == "Enemy") {
					other.SendMessage ("HandleHit", damage);
					HandleDeath ();
				}
			}
		}
	}

	public void SetRotation() {
		Vector3 diff = PlayerController.currentPos - (Vector2)transform.position;
        diff.Normalize();
 
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}

	void HandleDeath() {
		ObjectPool.instance.PoolObject(gameObject);
	}

	void Reset() {
		owner = null;
		transform.rotation = Quaternion.identity;
	}
}
