using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCubulus : Seres {

    public Image healthBar;

    public override void death()
    {
        
    }

    public override float getInitialLifePoints()
    {
        return 5;
    }

    public void receiveDamage(float damage)
    {
        healthBar.fillAmount = this.getlifePoints()/this.getMaxLifePoints();
        this.receiveDamage(damage);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
