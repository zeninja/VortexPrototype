using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public float timeBetweenEnemies = .75f;
	public float timeBetweenPowerStrips = .75f;


	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnEnemy", timeBetweenEnemies, timeBetweenEnemies);
		InvokeRepeating("SpawnPowerStrip", timeBetweenPowerStrips, timeBetweenPowerStrips);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnEnemy() {
		GameObject enemy = ObjectPool.instance.GetObjectForType("Enemy", false);
		enemy.transform.position = (Vector2)transform.position + LaneManager.lanePositions[Random.Range(0, LaneManager.numLanes)];
	}

	void SpawnPowerStrip() {
		GameObject enemy = ObjectPool.instance.GetObjectForType("PowerStrip", false);
		enemy.transform.position = (Vector2)transform.position + LaneManager.lanePositions[Random.Range(0, LaneManager.numLanes)];
		Vector3 pos = new Vector3 (enemy.transform.position.x, enemy.transform.position.y, 1);
		enemy.transform.position = pos;
	}
}