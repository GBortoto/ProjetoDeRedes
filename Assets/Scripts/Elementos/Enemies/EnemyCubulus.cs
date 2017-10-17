using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCubulus : Seres {

    public Image healthBar;
    public GameObject explosion;

    public override void death()
    {
        Rigidbody bodyPlayer = this.GetComponent<Rigidbody>();
        this.GetComponent<MeshRenderer>().enabled = false;
        GameObject effectExp = (GameObject)Instantiate(explosion, bodyPlayer.position, bodyPlayer.rotation);
        effectExp.GetComponent<ParticleSystemRenderer>().material.color = this.GetComponent<ColorHandler>().getfinalColor();
        Destroy(effectExp, 0.5f);
        Destroy(this.gameObject, 0.03f);
    }

    public override float getInitialLifePoints()
    {
        return 10;
    }

    public new void receiveDamage(float damage) {
        base.receiveDamage(damage);
        healthBar.fillAmount = this.getlifePoints() / this.getMaxLifePoints();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
