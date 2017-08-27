﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;

	public void OnValueChanged()
	{
		speed = GameObject.Find ("Speed Slider").GetComponent <Slider> ().value;
	}


	private PlayerMotor motor;

	void Start(){
		motor = GetComponent<PlayerMotor> ();
	}

	void Update(){
		// Calculate movement velocity as a 3D vector
		float _xMov = Input.GetAxisRaw("Horizontal");
		//float _zMov = Input.GetAxisRaw("Vertical");

		Vector3 _movHorizontal = transform.right * _xMov;
		//Vector3 _movVertical = transform.forward * _zMov;

		// Final movement vector
		//Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;
		Vector3 _velocity = _movHorizontal * speed;

		// Apply movement
		motor.Move(_velocity);

	}

}
