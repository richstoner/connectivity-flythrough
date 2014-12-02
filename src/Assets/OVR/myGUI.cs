using UnityEngine;
using System.Collections;

public class myGUI : MonoBehaviour {
	
	string text;
	string text2;
	string text3;
	
	CameraPick other;
	
	GUIStyle myStyle;
	GUIStyle detailStyle;
	
	public Texture2D cursorImage;
 
    private int cursorWidth = 32;
    private int cursorHeight = 32;
	
//	Texture2D cursorImage;
//	int cursorSizeX = 
//	
//	var yourCursor : Texture2D;  // Your cursor texture
//	var cursorSizeX : int = 16;  // Your cursor size x
//	var cursorSizeY : int = 16;  // Your cursor size y
//		
	// Use this for initialization
	void Start () {
			
		
	
		Screen.showCursor = false;
		
		this.other = GameObject.Find("Main Camera").GetComponent<CameraPick>();
		this.myStyle = new GUIStyle();
		this.myStyle.font = Resources.Load("Helvetica") as Font;
		this.myStyle.normal.textColor = Color.white;
		this.myStyle.fontSize = 20;
		
		this.detailStyle = new GUIStyle();
		this.detailStyle.font= Resources.Load("Helvetica") as Font;
		this.detailStyle.normal.textColor = Color.white;
		this.detailStyle.fontSize = 16;
  
	}
	
	// Update is called once per frame
	void Update () {
		
		ArrayList a = this.other.GetTextFromSomewhere();
	
		this.text = "" + a[0];
		this.text2 = "Site acronym: " + a[1];
		this.text3 = "Site name: " + a[2];

	}
	
	void OnGUI () {
		GUI.Label (new Rect (25, 25, 200, 30), this.text, this.myStyle);
		GUI.Label (new Rect (25, 50, 200, 30), this.text2, this.detailStyle);
		GUI.Label (new Rect (25, 75, 200, 30), this.text3, this.detailStyle);
		
		GUI.Label (new Rect (Screen.width - 400, 25, 200, 30), "Navigation - Arrow keys & mouse, or PS3 controller", this.detailStyle);
		GUI.Label (new Rect (25, Screen.height - 30, 200, 30), "Visualization by Rich Stoner, 2013. Original data from Allen Institute for Brain Sciences", this.detailStyle);
		
		
		
		        GUI.DrawTexture(new Rect(Input.mousePosition.x - cursorWidth / 2, Screen.height - Input.mousePosition.y - cursorHeight / 2, cursorWidth, cursorHeight), cursorImage);

		
	}
}
