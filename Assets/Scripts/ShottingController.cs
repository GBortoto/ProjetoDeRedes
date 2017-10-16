using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottingController : MonoBehaviour {
    [Header("Bullet Types")]
    public GameObject whiteBullet;
    public GameObject redBullet;
    public GameObject blueBullet;
    public GameObject yellowBullet;
    public GameObject greenBullet;

    [Header("FirePoint")]
    public Transform firePoint;
    float timePassed = 100f;
    
    float[] delayTime = new float[] { 1.2f, 1.2f, 1.2f, 1.2f , 1.2f };
    float[] speed = new float[] { 0.3f, 0.3f, 0.3f, 0.3f, 0.3f };
    float[] destroyTime = new float[] { 2, 2, 2, 2, 2 };

    // Use this for initialization
    void Start() {
    }


    // Update is called once per frame
    void Update() {
        timePassed += Time.deltaTime;
    }

    public void Shoot(Vector3 mousePosition , int powerUpAtual) {
		// Get what bullet is going to be shot
        GameObject currentBulletObject = getCurrentBullet(powerUpAtual);
    
		Bullet currentBullet = currentBulletObject.GetComponent<Bullet>(); 
		if (timePassed > currentBullet.delaytime) {
            // Set up the shot direction
			Vector3 direction = mousePosition - firePoint.position;
            direction = Vector3.Normalize(direction) * 400;
            
			// Instantiate the bullet above
			GameObject newBullet = (GameObject) Instantiate(currentBulletObject, firePoint.position, firePoint.rotation);
			//GameObject newBullet = (GameObject) Instantiate(redBullet, firePoint.position , firePoint.rotation);
            
			newBullet.GetComponent<Rigidbody>().AddRelativeForce(direction *  currentBullet.speed);
            Destroy(newBullet, currentBullet.timeBeforeDestroy + 1);
            timePassed = 0;
        }
    }

    private GameObject getCurrentBullet(int powerUpAtual) {
        switch(powerUpAtual){
            case 0: return whiteBullet;
			case 1: return redBullet;
			case 2: return greenBullet;
            case 3: return blueBullet;
			case 4: return yellowBullet;    
			default: return whiteBullet;
        }
    }
}
