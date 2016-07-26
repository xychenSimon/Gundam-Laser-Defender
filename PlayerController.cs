using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 1.5f;
	public GameObject beam;
	public AudioClip fireSound;
	//public Sprite[] sprites;

	private float fireRate = 0.15f;	
	private float beamSpeed = 8.0f;	
	private Rigidbody2D fire;
	private float health = 300;
	//private SelectionMenu selectionMenu;
	//private int num;

	float xmin = -5;
	float xmax = 5;
	// ymin ymax?

	// Use this for initialization
	void Start () {
		//selectionMenu = GetComponent<SelectionMenu> ();
		//num = selectionMenu.getIndex();
		//print (num);
		//LoadSprites ();

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		//maybe add a upmost and a lowermost later?

		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Fire () {
		Vector3 offset = new Vector3 (0, 1, 0);
		GameObject fire = Instantiate (beam, transform.position + offset, Quaternion.identity) as GameObject;
		fire.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, beamSpeed, 0);
		AudioSource.PlayClipAtPoint (fireSound,transform.position);
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.000001f, fireRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;		
		}
		// upArrow and downArrow?	


		// restricting the player to the screen in the x direction
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

		//resticting the player to the screen in the y direction?
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			missile.Hit ();
			health -= missile.GetDamage ();
			if (health <= 0) {
				Die ();
			}
			//Debug.Log ("Hit by a projectile");
		}
	}

	void Die() {
		LevelManager man = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		man.LoadLevel ("Win Screen");
		Destroy (gameObject);
	}

	/*void LoadSprites () {
		int spriteIndex = 5; // add cases later
		this.GetComponent<SpriteRenderer> ().sprite = sprites [spriteIndex];
		resetCollider ();
	}

	void resetCollider() {
		Destroy(GetComponent<PolygonCollider2D>());
		gameObject.AddComponent<PolygonCollider2D>();
	}*/
}
