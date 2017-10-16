using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Seres : MonoBehaviour {

    private float maxHealthPoints;
	private float lifePoints;
	private bool alive = true;

    public Seres() {
        lifePoints = getInitialLifePoints();
        maxHealthPoints = lifePoints;
    }

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //usado para pegar a vida inicial de cada ser
	public abstract float getInitialLifePoints();
	public abstract void death ();	

	public void receiveDamage(float damage){
		lifePoints -= damage;
		if(lifePoints <= 0 ){
			alive = false;
			death();
		}
			
	}
	public float getlifePoints(){
		return lifePoints;	
	}
	public bool isAlive(){
		return alive;
	}
	public void setLifePoints(float lifePoints){
		this.lifePoints = lifePoints;
	}	
	public void isAlive(bool alive){
		this.alive = alive;
	}
    public void setMaxLifePoints(float lifePoints)
    {
        this.lifePoints = lifePoints;
    }
    public float getMaxLifePoints()
    {
        return maxHealthPoints;
    }
}
