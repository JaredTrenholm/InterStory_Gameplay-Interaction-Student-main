using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    [Header("Interaction Type")]
    public bool pickup;
    public bool info;
    public string message;

    private Text infoText;

    public bool dialogue;
    [TextArea]
    public string[] sentences;

    public float DespawnTimer = 2f;
    private float TimePassed = 0f;
    private bool InfoUp = false;


    private void Start()
    {
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
    }
    public void Interaction()
    {
        if (pickup)
        {
            Pickup();
        } else if (info)
        {
            Info();
            TimePassed = 0f;
        } else if (dialogue)
        {
            Dialogue();
        }
    }

    private void Update()
    {
        if (InfoUp)
        {
            if(TimePassed >= DespawnTimer)
            {
                InfoUp = false;
                infoText.text = null;
            } else
            {
                TimePassed = TimePassed + Time.deltaTime;
            }
        }
    }

    private void Pickup()
    {
        this.gameObject.SetActive(false);
    }

    private void Info()
    {
        infoText.text = message;
        InfoUp = true;
    }

    public void EndInfo()
    {
        InfoUp = false;
        infoText.text = null;
    }

    private void Dialogue()
    {
        Debug.Log("Searching");
        FindObjectOfType<DialogueManager>().StartDialogue(sentences);
        Debug.Log("Finished");
    }
}
