using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	private Vector3 velocity = Vector3.zero;
    private GameObject player;
    private PlayerStatus status;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
        player = this.gameObject;
        status = player.GetComponent<PlayerStatus>();
    }

	// Gets a movement vector
	public void Move(Vector3 _velocity){
		velocity = _velocity;
	}

	// Run every physics iteration
	void FixedUpdate(){
        if (status.isAlive()) {
            PerformMovement();
        }
	}

	// Perform movement based on velocity variable
	void PerformMovement(){
		if (velocity != Vector3.zero) {
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
		}
	}
    public Vector3 getPosition() {
        return rb.position;
    }
}
