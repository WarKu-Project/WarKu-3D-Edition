﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
	private double score = 0;
	private Vector3 currentLocation;
	public GameObject explosion;
	public GameObject player;
	private GameObject aura; 
	public bool chceckCurrentLocation(Vector3 currentLocation){
		if(currentLocation.x >= 213.5 && currentLocation.x <= 273.5){
			if (currentLocation.z >= 216.5 && currentLocation.z <= 270.5){
				return true;
			}
		}
		return false;
	}

	public void setScore(Vector3 currentLocation){
		if (chceckCurrentLocation (currentLocation)) {
			score += 0.1;
			aura = Instantiate (explosion, currentLocation, Quaternion.identity);
			Debug.Log (score);
		} else {
			score = 0;
		}
		Destroy (aura,0.5f);
	}

	// Use this for initialization
	public void Start () {
		
	}
	
//	 Update is called once per frame
	void Update () {
		
	}
}