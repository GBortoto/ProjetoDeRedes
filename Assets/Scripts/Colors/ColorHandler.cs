using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColorHandler : MonoBehaviour {

	protected Color currentColor;		// Cor atual --> Muda durante o processo de alteração de cores
	private Color finalColor;			// Cor final --> Representa o objetivo final atual em relação a cor
	protected Renderer rend;			// Render deste objeto --> Utilizado para a mudança de cor
	Light objectLight;	// Luz referente ao objeto

	// Variáveis utilizadas no processo de alteração de cores
	private bool updateRGB = false;		// Devo modificar a cor atual?
	private bool doneR = true;			// O R de RGB está com o valor certo?
	private bool doneG = true;			// O G de RGB está com o valor certo?
	private bool doneB = true;			// O B de RGB está com o valor certo?
	public float gap = 0.1f;			// Limite mínimo de diferença entre um valor errado e um valor certo

	 
	/*
	// ------------------------ currentPowerUp --> Mostra qual power-up está ativo no momento ---------------

	private int currentPowerUp = 0;

	public int getCurrentPowerUp(){
		return currentPowerUp;
	}
	*/

	// ------------------------------------------------------------------------------------------------------

	// Start --> Criar uma referência para o render e a luz do objeto
	protected void Start() {
		rend = GetComponent<Renderer> ();
		objectLight = gameObject.GetComponent<Light> (); 

    }

	// Checa uma vez por frame se é necessário mudar a cor deste objeto
	protected void Update () {
		updateObjectColor ();
	}

	// Checa se é necessário mudar a cor deste objeto
	void updateObjectColor(){
		if(updateRGB){
			updateObjectRGB();
		}
	}

	// Comando para modificar a cor --> ESTE É O COMANDO A SER CHAMADO EXTERNAMENTE
	public bool changeColor(Color color, float speed = 10f){
		if(rend == null){
			rend = GetComponent<Renderer> ();
		}

		// A cor já está sendo modificada?
		if(updateRGB){
			return false;
		}
			
		currentColor = rend.material.color;	// Cor atual é atualizada
		finalColor = color;					// Cor final é atualizada
		gap = 0.01f * speed;				// Limite mínimo de diferença é atualizado
		updateRGB = true;					// A cor está sendo modificada
		doneR = false;						// Ainda não está completo a parte R de RGB
		doneG = false;						// Ainda não está completo a parte G de RGB
		doneB = false;						// Ainda não está completo a parte B de RGB

		return true;
	}
		

	// Checa se todas as parcelas de RGB estão no valor certo. As modifica caso contrário
	protected void updateObjectRGB(){
		ColorUpdateReturn retorno;
		if(!doneR){
			retorno = updateColor(currentColor.r , finalColor.r);
			currentColor.r = retorno.getColorComponent();
			doneR = retorno.isfinished ();
		}
		if(!doneG){
			retorno = updateColor(currentColor.g , finalColor.g);
			currentColor.g = retorno.getColorComponent();
			doneG = retorno.isfinished ();
		}
		if(!doneB){
			retorno = updateColor(currentColor.b , finalColor.b);
			currentColor.b = retorno.getColorComponent();
			doneB = retorno.isfinished ();
		}

		if(doneR && doneG && doneB){
			updateRGB = false;
		}

		rend.material.color = currentColor;
		objectLight.color = currentColor;
	}

	private ColorUpdateReturn updateColor(float currentColorComponent, float finalColorComponent)
	{
		ColorUpdateReturn retorno = new ColorUpdateReturn ();
		if (Math.Abs(currentColorComponent - finalColorComponent) < gap ) {
			retorno.setColorComponent(finalColorComponent);
			retorno.setfinished (true);
		} else {
			if (currentColorComponent > finalColorComponent) {
				retorno.setColorComponent(currentColorComponent - gap);
			} else if (currentColorComponent < finalColorComponent) {
				retorno.setColorComponent(currentColorComponent + gap);
			}
		}
		return retorno;
	}
    public Color getfinalColor() {
        return finalColor;
    }
}
