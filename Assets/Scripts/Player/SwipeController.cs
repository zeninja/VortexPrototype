using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour {

	public Image chargeBar;
	ColorManager colorManager;
	int colorIndex;

	int laneIndex = 0;
	bool canMove;

	static int MAX_CHARGE = 100;
	public float chargePower;
	public float chargeRate = 1;

	// Use this for initialization
	void Start () {
		colorManager = GetComponent<ColorManager>();
		colorManager.UpdateSpriteColor();
	}
	
	// Update is called once per frame
	void Update () {
		ManageInput();
	}

	void ManageInput() {
		if(Input.GetAxis("Horizontal") != 0 && canMove) {
			ChangeLanes((int)Mathf.Sign(Input.GetAxis("Horizontal")));
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			//UpdateColor();
		}

		canMove = Input.GetAxis("Horizontal") == 0;
	}

	void OnSwipe(SwipeGesture gesture) {
		switch(gesture.Direction) {
			case FingerGestures.SwipeDirection.Left:
				ChangeLanes(-1);
				break;
			case FingerGestures.SwipeDirection.Right:
				ChangeLanes(1);
				break;
		}
	}

	void OnTap(TapGesture gesture) {
		//UpdateColor();
	}

	 void UpdateColor() {
		colorIndex++;
		if (colorIndex >= 3) {
			colorIndex = 0;
		}

		colorManager.SetColorByIndex(colorIndex);
	}
	public void UpdateColorChoice() {
		colorIndex++;
		if (colorIndex >= 3) {
			colorIndex = 0;
		}

		colorManager.SetColorByIndex(colorIndex);
	}


	void ChangeLanes(int offset) {
		laneIndex += offset;

		if(Mathf.Abs(laneIndex) > LaneManager.numLanes/2) {
			laneIndex = (int)Mathf.Sign(laneIndex) * LaneManager.numLanes/2;
		}

		// Need to offset the index because it starts at 0
		// 0 is center lane, -1, -2 are left and 1, 2 are right
		transform.position = LaneManager.lanePositions[laneIndex + LaneManager.numLanes/2];
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			if(!ColorManager.CompareColorType(colorManager.myColor, other.GetComponent<ColorManager>().myColor)) {
				HandleHit();
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag("Power strip")) {
			ChargePower(other.GetComponent<ColorManager>().myColor);
		}

		if (other.CompareTag("Enemy")) {
			HandleHit();
		}
	}

	void ChargePower(ColorType chargeColor) {
		if (colorManager.myColor == chargeColor) {
			chargePower += chargeRate * Time.fixedDeltaTime;
			chargePower = Mathf.Min(chargePower, MAX_CHARGE);

			chargeBar.fillAmount = (float)chargePower/MAX_CHARGE;
		}
	}

	void HandleHit() {
		HandleGameOver();
	}

	void HandleGameOver() {
		Time.timeScale = 0;
		Debug.Log("GAME OVER");
	}
}
