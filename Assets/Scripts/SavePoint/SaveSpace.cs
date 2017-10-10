using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSpace : MonoBehaviour
{

    bool playerIsPresent = false;

    private GameObject player;
    private GameObject floatingKey;
    private Renderer floatingKeyRenderer;

    void OnTriggerEnter(Collider other)
    {
        player = other.gameObject;
        PlayerStatus playerStatus = player.GetComponent(typeof(PlayerStatus)) as PlayerStatus;
        
        if (playerStatus != null)
        {
            playerIsPresent = true;
            showActivateButton();
            Debug.Log(player.name + " Entrou");
            playerStatus.setLastCheckPoint(this.gameObject.transform.position);
        }
    }

    void OnTriggerExit(Collider other)
    {
        player = other.gameObject;
        playerIsPresent = false;
        hideActivateButton();
        Debug.Log(player.name + " Saiu");
    }

    void showActivateButton()
    {

    }

    void hideActivateButton()
    {

    }
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        // If the user press SPACE while inside the save point, enter the menu
        if (ExtraUtilities.checkPress(" ") && playerIsPresent)
        {
            Debug.Log("Spawn point - Interaction");
            //Interact (player);
        }
    }

    /*
	void Interact(GameObject player){
		if(floatingKey){
			if(floatingKeyRenderer){
				floatingKeyRenderer.material.color.a = ;
			} else {
				gameObject.GetComponent<Renderer>();
			}
		}
		(GameObject)Instantiate (powerUpPrefab, myPosition, transform.rotation, gameObject.transform);
	}

	void fadeInKeyBox(){
		
	}

	void fadeOutKeyBox(){
		
	}

	*/
}
