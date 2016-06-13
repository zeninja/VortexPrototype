using UnityEngine;
using System.Collections;

public class LaneManager : MonoBehaviour {

	public static int numLanes = 5;
	public static Vector2[] lanePositions = new Vector2[numLanes];

	float spaceBetweenLanes;

	public Vector2 worldSpacing;
	
	// Use this for initialization
	void Start () {
		spaceBetweenLanes = Screen.width/numLanes;
		worldSpacing = (Vector2)Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2 + spaceBetweenLanes, 0)) + new Vector2(0, 3);

		for (int i = 0; i < lanePositions.Length; i++) {
			lanePositions[i] = (i - numLanes/2) * worldSpacing;
		}
	}

	void OnDrawGizmos() {
		for (int i = 0; i < lanePositions.Length; i++) {
			Gizmos.DrawWireSphere(lanePositions[i], .5f);
		}
	}
}
