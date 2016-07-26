using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float damage = 100f;

	public float GetDamage() {
		return damage;
	}

	public void Hit() {
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
