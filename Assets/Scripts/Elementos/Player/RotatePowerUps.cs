using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePowerUps : MonoBehaviour {


	public GameObject player;								// Referência ao player

	public float offset;									// Offset --> Em quantos graus o elemento deve estar no início?
	public float orbitRadius;								// Raio da orbita
	public float frequency;									// Velocidade de orbita
	public float nObjects;									// Número de elementos em órbita

	private Vector3 originalPosition = new Vector3 ();		// Posição inicial na órbita --> topo do centro (em um circulo, seria Pi/2) 
	private Vector3 nextPosition = new Vector3 ();			// Próxima posição --> utilizado para o cálculo de órbita


	void Start () {
		originalPosition = player.transform.position;
	}



	void Update () {
		// Cálculo de órbita
		originalPosition = player.transform.position;
		nextPosition.x = originalPosition.x + Mathf.Sin (Time.fixedTime * Mathf.PI * frequency + (offset*Mathf.PI/180)) * orbitRadius;
		nextPosition.y = originalPosition.y + Mathf.Sin (Time.fixedTime * Mathf.PI * frequency + (offset*Mathf.PI/180) + (Mathf.PI/2)) * orbitRadius;
		nextPosition.z = transform.position.z;
		transform.position = nextPosition;
	}
}