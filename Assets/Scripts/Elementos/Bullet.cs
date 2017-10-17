using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class Bullet : NetworkBehaviour {
    public float speed = 0.3f;
    public float explosionRadius = 1.2f;
    public float delaytime = 2.0f;
    public float timeBeforeDestroy = 2.0f;
    public float damage = 5.0f;
    public GameObject explosion;

    private bool isExploded= false; 
    private float currentTime;
    // Use this for initialization
    void Start () {
        currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if((currentTime > timeBeforeDestroy) && (!isExploded)) {
            if(explosionRadius > 0 ){
                GameObject explosionParticles = (GameObject)Instantiate(explosion, this.GetComponent<Rigidbody>().position, this.GetComponent<Rigidbody>().rotation);
                Destroy(explosionParticles, 5);
                isExploded = true;
                foreach (Collider col in Physics.OverlapSphere(this.GetComponent<Rigidbody>().position, explosionRadius)) {
                    Rigidbody rb = col.GetComponent<Rigidbody>();
                    if((rb != null) && (col.gameObject.tag.Equals("Enemy"))) {
                        EnemyCubulus inimigo = rb.GetComponent<EnemyCubulus>();
                        rb.AddExplosionForce(10f, this.GetComponent<Rigidbody>().position, explosionRadius ,2);
                        inimigo.receiveDamage(damage);
                    }
                }
                this.gameObject.SetActive(false);
            }
        }
	}
}
