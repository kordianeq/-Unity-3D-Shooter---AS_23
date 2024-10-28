using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //[SerializeField] GameObject UI;
 
    public GameObject interactionUIPrefab; // Reference to the keybind icon UI prefab
    private GameObject interactionUI; // Reference to the instantiated UI element

    void Start()
    {
        // Instantiate the UI element
        interactionUI = Instantiate(interactionUIPrefab, transform.position, Quaternion.identity);
        interactionUI.SetActive(false);
    }

    void Update()
    {
        // Check if the player is within the interaction area
        // You might want to customize the condition based on your collider and player setup
        if (Input.GetKeyDown(KeyCode.E)) // Replace with your desired key
        {
            // Perform the interaction logic here
            Debug.Log("Player interacted with NPC!");
        }
    }

  

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Show the interaction UI when the player enters the interaction area
            interactionUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Hide the interaction UI when the player exits the interaction area
            interactionUI.SetActive(false);
        }
    }
}

