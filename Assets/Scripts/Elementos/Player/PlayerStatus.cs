﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerStatus : Seres {
    //checkPoint Inicial
    Vector3 lastCheckPoint = new Vector3(1.26f, -2.75f, 0f);

    //referencia ao objeto de explosão
    public GameObject explosion;

    Rigidbody bodyPlayer;
    public float deathCountDown = 3f;

    public override void death()
    {
        this.isAlive(false);
        deathCountDown = 3f;
        explosionEffect();
        resetPowerUps();
        hidingPlayer();
        //seta os life points de volta para o maximo
        this.setLifePoints(this.getMaxLifePoints());
    }
    private void explosionEffect() {
        GameObject effectExp = (GameObject)Instantiate(explosion, bodyPlayer.position, bodyPlayer.rotation);
        effectExp.GetComponent<ParticleSystemRenderer>().material.color = this.GetComponent<ColorHandler>().getfinalColor();
        Destroy(effectExp, 3f);
    }
    private void hidingPlayer() {
        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<Light>().intensity = 0;
    }

    private void resetPowerUps() {
		this.GetComponent<PowerUps>().hardReset();
        this.GetComponent<ColorHandler>().changeColor(Color.white);
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
        if (!this.isAlive())
        {
            //contagem para renascer
            if (deathCountDown > 0){
                //Debug.Log(DeathCountDown);
                deathCountDown -= Time.deltaTime;
            }else{
                this.isAlive(true);
                bodyPlayer.position = lastCheckPoint;
                //Debug.Log(bodyPlayer.position);
                this.GetComponent<MeshRenderer>().enabled = true;
                this.GetComponent<Light>().intensity = 4;
                resetPowerUps();
            }
        }
	}
    public void setLastCheckPoint(Vector3 posCheckPoint){
        posCheckPoint.y = posCheckPoint.y+10;
        lastCheckPoint = posCheckPoint;
    }
}
