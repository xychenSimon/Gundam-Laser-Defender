using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 12.5f;
	public float height = 6f;
	public float speed = 5f;
	public float spawnDelay = 0.3f;

	private bool movingRight = true;
	float xmin = -5;
	float xmax = 5;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xmin = leftMost.x ;
		xmax = rightMost.x ;

		SpawnUntilFull ();
	}

	void SpawnEnemy() {
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull() {
		Transform freePostion = NextFreePostion ();
		if (freePostion) {
			GameObject enemy = Instantiate (enemyPrefab, freePostion.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePostion;
		}
		if (NextFreePostion ()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));
	}

	// Update is called once per frame
	void Update () {

		// how to make them move randomly?
		if (movingRight) {
			transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		} else {
			transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
		}

		float rightEdge = transform.position.x + (0.5f * width);
		float leftEdge = transform.position.x - (0.5f * width);
		if (leftEdge < xmin) {
			movingRight = true;
		} else if (rightEdge > xmax) {
			movingRight = false;
		}

		if (AllMembersDead ()) {
			Debug.Log ("All dead");
			SpawnUntilFull ();
		}
	}

	Transform NextFreePostion() {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;
	}

	bool AllMembersDead () {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
