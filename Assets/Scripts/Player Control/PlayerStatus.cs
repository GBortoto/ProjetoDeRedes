using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerStatus : Seres {
    //checkPoint Inicial
    Vector3 lastCheckPoint = new Vector3(1.26f, -2.75f, 0f);

    Rigidbody bodyPlayer;

    public override void death()
    {
        Debug.Log(this.gameObject.name + " morreu");
        bodyPlayer.position = lastCheckPoint;
    }

    public override float getInitialLifePoints()
    {
        return 10;
    }

    // Use this for initialization
    void Start () {
        bodyPlayer = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setLastCheckPoint(Vector3 posCheckPoint){
        lastCheckPoint = posCheckPoint;
    }
}
