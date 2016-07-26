using UnityEngine;
using System.Collections;

public class LoadPlayer : MonoBehaviour {

	public Sprite[] sprites;

	private SelectionMenu selectionMenu;
	private int num = 0;

	// Use this for initialization
	void Start () {
		selectionMenu = GetComponent<SelectionMenu> ();
		print (num);
		LoadSprites ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadSprites () {
		int spriteIndex = selectionMenu.index; // add cases later
		this.GetComponent<SpriteRenderer> ().sprite = sprites [spriteIndex];
		resetCollider ();
	}

	void resetCollider() {
		Destroy(GetComponent<PolygonCollider2D>());
		gameObject.AddComponent<PolygonCollider2D>();
	}
}
