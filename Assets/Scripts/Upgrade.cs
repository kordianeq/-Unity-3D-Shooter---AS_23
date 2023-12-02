using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    BoxCollider boxcolider;
    // Start is called before the first frame update
    void Start()
    {
        boxcolider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (gameObject.CompareTag("Player") == true)
        {
            
            if(Input.GetKey(KeyCode.E))
            {
                Debug.Log("LevelUp");
            }
        }
    }
}
