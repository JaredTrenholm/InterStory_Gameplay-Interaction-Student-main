using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject InteractObject = null;

    private ObjectInteraction InteractScript = null;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(InteractObject != null)
            {
                InteractScript.Interaction();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Interactable")
        {
            InteractObject = other.gameObject;
            InteractScript = other.gameObject.GetComponent<ObjectInteraction>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(InteractObject.GetComponent<ObjectInteraction>().info == true)
        {
            InteractObject.GetComponent<ObjectInteraction>().EndInfo();
        }
        InteractObject = null;
        InteractScript = null;
    }
}
