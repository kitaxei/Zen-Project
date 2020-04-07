using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    
 void Start()
    {

    }

void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke(); //Fire Event 
            }
        }
    }
    private void OnTriggerEnter3D(Collider2D collision)
    { if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
    }

    private void OnTriggerExit3D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = false;
                Debug.Log("Player now in range");
            }
        }
}