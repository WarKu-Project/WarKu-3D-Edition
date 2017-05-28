﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherUnitProperty : MonoBehaviour {

    public string action, uid, name;
    Vector3 next;
    Quaternion nextRo;
    float speed;

	// Use this for initialization
	void Start () {
        next = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speed = 3;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, next, Time.deltaTime * speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRo, Time.deltaTime * speed);
    }

    public void UpdatePosition(float x,float y,float r,string action)
    {
        next = new Vector3(x, transform.position.y, y);
        nextRo = new Quaternion(0, r, 0,transform.rotation.w);
        if (action == "walk") speed = 3;
        else if (action == "run") speed = 6;
        GetComponent<Animator>().Play(action,0);
    }
}
