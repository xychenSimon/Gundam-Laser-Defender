using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	public float health = 200f;
	public GameObject projectile;
	public float projectileSpeed = 10f;
	public float shotsPS = 0.5f;
	public AudioClip deathSound;
	public AudioClip enemySound;

	private int scoreValue = 150;
	private Rigidbody2D missile;
	private ScoreKeeper scorekeeper;


	// Use this for initialization
	void Start () {
		scorekeeper = GameObject.Find ("_Score").GetComponent<ScoreKeeper> ();
	}
	
	// Update is called once per frame
	void Update () {
		float probabilty = Time.deltaTime * shotsPS;
		if (Random.value < probabilty) {
			Fire ();
		}
	}

	void Fire() {
		Vector3 startPosition = transform.position + new Vector3 (0, -1, 0);
		GameObject missile = Instantiate (projectile, startPosition, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -projectileSpeed, 0);
		AudioSource.PlayClipAtPoint (enemySound, transform.position);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			missile.Hit ();
			health -= missile.GetDamage ();
			if (health <= 0) {
				AudioSource.PlayClipAtPoint (deathSound, transform.position);
				Destroy (gameObject);
				scorekeeper.Score (scoreValue);
			}
			//Debug.Log ("Hit by a projectile");
		}
	}
}
