using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour {
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
                this.gameObject.SetActive(false);
                foreach (Collider col in Physics.OverlapSphere(this.GetComponent<Rigidbody>().position, explosionRadius)) {
                    Debug.Log("Entra no forEach");
                    Debug.Log(col.GetComponent<Rigidbody>());
                    Debug.Log(col.gameObject.tag );
                    if ((col.GetComponent<Rigidbody>() != null) && (col.gameObject.tag =="Enemy")){
                        
                        this.GetComponent<Rigidbody>().AddExplosionForce(3.0f, this.GetComponent<Rigidbody>().position, explosionRadius);
                    }
                }
                isExploded = true;
            }
        }
	}
}
