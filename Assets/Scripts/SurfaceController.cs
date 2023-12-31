﻿using UnityEngine;
using System.Collections;

public class SurfaceController : MonoBehaviour {

	public GameObject player = null;
	public Surface[] surfaces = null;
	private bool[] ifTouched = null;
	private int surTouched = 0;
	private PlayerController playerCont;

	private float timer = 1.0f;
	private bool timeExp = false; 

	public bool winCon = false;

	// Use this for initialization
	void Start () {
		playerCont = transform.GetComponent<PlayerController> ();
		ifTouched = new bool[20];
		for(int i= 0;i<ifTouched.Length;i++){
			ifTouched[i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer +=Time.deltaTime;
		for(int i = 0;i<surfaces.Length;i++){
			if(surfaces[i].touch && !ifTouched[i]){
				surTouched++;
				ifTouched[i] = true;
			}
		}
		if(surfaces.Length == surTouched){winCon = true;}
		Debug.Log ("# Touched: "+surTouched);
	}

	void OnGUI(){
		// Make a background box
		GUI.Box(new Rect(10,10,100,90), "Level 1");
		GUI.Label(new Rect(10, 30, 100, 30), "Time: "+timer.ToString("0")+"s");
		GUI.Label (new Rect (10, 50, 150, 30), "Tiles Touched: " +surTouched + "/20");
		if(winCon){
			Time.timeScale = 0; //Freeze time
			GUI.Box(new Rect(Screen.width/2 - 100, Screen.height/2,200,50), "You Won!\nYour Time: "+timer.ToString("0")+"s");
			if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 + 150, 200, 50),"Restart")){
				Application.LoadLevel(Application.loadedLevel); 
			}
		}
		else Time.timeScale = 1; //resume time
	}
}