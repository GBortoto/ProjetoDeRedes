using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	private int currentPowerUp = 0;				// Valor do power up atual

	// Getter para currentPowerUp
	public int getCurrentPowerUp(){
		return currentPowerUp;
	}

	Color[] powerUpColors;						// Cores de cada power up, em ordem (Vermelho, Verde, Azul, Amarelo)

	[SerializeField] private float speed = 5f;	// Velocidade do player

	/* Código referente ao slider - não está sendo utilizado no momento
	public void OnValueChanged(){
		speed = GameObject.Find ("Speed Slider").GetComponent <Slider> ().value;
	}
	*/

	private PlayerMotor motor;					// Referência ao script "PlayerMotor", que controla a física do player

	void Start(){
		motor = GetComponent<PlayerMotor> ();
		powerUpColors = new Color[] {new Color(1, 0, 0), new Color(0, 1, 0), new Color(0, 0, 1), new Color(1, 1, 0)};
	}


	void updateMovimento(){
		
		float _xMov = Input.GetAxisRaw("Horizontal");		// Calculate movement velocity as a 3D vector
		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _velocity = _movHorizontal * speed;
		motor.Move(_velocity);								// Apply movement
	}

	void Update(){
		updateMovimento ();
	}

	// ESTE É O MÉTODO PÚBLICO QUE DEVE SER CHAMADO
	public void applyPowerUp(int powerUpOption){
		gameObject.GetComponent<PowerUps> ().setPowerUp (powerUpOption);
		gameObject.GetComponent<ColorHandler> ().changeColor (powerUpColors[powerUpOption-1]);
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log(other.gameObject.tag);
		if(other.gameObject.CompareTag("PowerUp")){
			applyPowerUp (other.gameObject.GetComponent<PowerUpElement>().getPowerUpOption());
			Destroy (other.gameObject);
		}
	}
}
