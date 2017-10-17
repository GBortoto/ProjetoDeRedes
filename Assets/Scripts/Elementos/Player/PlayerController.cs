using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	// for jumping
	bool grounded = false;
	Collider[] groundCollisions;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	private int currentPowerUp = 0;				// Valor do power up atual

	private bool powerUpOnCooldown = false;

	private float defaultSpeed = 5f;

	private float howLongOnCooldown = 1f;

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
		powerUpColors = new Color[] {new Color(1, 1, 1), new Color(1, 0, 0), new Color(0, 1, 0), new Color(0, 0, 1), new Color(1, 1, 0)};
	}


	void updateMovimento(){
		float _xMov = Input.GetAxisRaw("Horizontal");		// Calculate movement velocity as a 3D vector
		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _velocity = _movHorizontal * speed;
		bool jumped = false;

		Vector3 _yandxMov = _velocity;
		if (jumped = jump () == true) {
			Vector3 _jump = new Vector3 (0, jumpHeight, 0);
			_yandxMov += _jump;
		}
			
		motor.Move(_yandxMov , jumped);								// Apply movement
	}

	bool jump () {
		if (grounded && Input.GetAxis ("Jump") > 0) {
			grounded = false;
			return true;
		}

		// Draw a sphere on the feet of the soldier and get it's collisions with the groundLayer
		groundCollisions = Physics.OverlapSphere (groundCheck.position, groundCheckRadius, groundLayer);
		if (groundCollisions.Length > 0)
			grounded = true;
		else
			grounded = false;

		return false;
	}

	void Update(){
		updateMovimento ();
		updateShoot ();
	}
	private void updateShoot() {
		if (Input.GetMouseButtonDown(0)) {
           
			Camera cam = Camera.main;
			Vector3 mousePosition = Input.mousePosition;

			mousePosition.z = 20f;
			Vector3 worldMousePosition = cam.ScreenToWorldPoint(mousePosition);
			worldMousePosition.z = 0f;
			Color corAtual = this.GetComponent<ColorHandler>().getfinalColor();
			int powerUpAtual = findColorNumber(corAtual);
            this.GetComponent<ShottingController>().CmdShoot(worldMousePosition, powerUpAtual);
		}
	}

	private int findColorNumber(Color corAtual) {
		for (int i = 0; i < powerUpColors.Length; i++) {
			if (powerUpColors[i] == corAtual) {
				return i;
			}
		}
		return 0;
	}

	// ESTE É O MÉTODO PÚBLICO QUE DEVE SER CHAMADO
	public bool applyPowerUp(int powerUpOption){
		bool result1 = gameObject.GetComponent<PowerUps> ().setPowerUp (powerUpOption);
		bool result2 = gameObject.GetComponent<ColorHandler> ().changeColor (powerUpColors[powerUpOption]);
		// Se a troca de cor e as particulas foram devidamente atualizadas, então aplicar o efeito do power up
		if (result1 && result2) {

			// Efeito 0) Sem power up --> Estado inicial
			if(powerUpOption == 0){
				this.speed = defaultSpeed;
			}

			// Efeito 1) Vermelho --> Ainda sem efeito
			if(powerUpOption == 1){
				this.speed = defaultSpeed;
			}

			// Efeito 2) Verde --> Ainda sem efeito
			if(powerUpOption == 2){
				this.speed = defaultSpeed;
			}

			// Efeito 3) Azul --> Velocidade de movimento dobrada
			if(powerUpOption == 3){
				this.speed = defaultSpeed;
			}

			// Efeito 4) Amarelo --> Ainda sem efeito
			if(powerUpOption == 4){
				this.speed = defaultSpeed;
			}
			return true;
			// Se, por algum motivo, a troca de cor ou o spawn das particulas não for devidamente atualizada, voltar para o estado padrão
		} else {
			gameObject.GetComponent<PowerUps> ().setPowerUp (0);
			gameObject.GetComponent<ColorHandler>().changeColor(powerUpColors[0]);

			this.speed = defaultSpeed;
			return false;
		}
	}

	// Esta função aplica o cooldown dos power ups - Roda em uma nova thread
	IEnumerator countCooldown(){
		powerUpOnCooldown = true;
		//Debug.Log ("powerUpOnCooldown: " + powerUpOnCooldown);
		yield return new WaitForSeconds (howLongOnCooldown);
		powerUpOnCooldown = false;
		//Debug.Log ("powerUpOnCooldown: " + powerUpOnCooldown);
	}

	void OnTriggerStay(Collider other) {
		//Debug.Log(other.gameObject.tag);
		if (other.gameObject.CompareTag ("PowerUp") && !powerUpOnCooldown) {
			StartCoroutine (countCooldown ());
			applyPowerUp (other.gameObject.GetComponent<PowerUpElement> ().getPowerUpOption ());
			other.gameObject.GetComponent<PowerUpElement> ().consume ();
		}
	}


}

