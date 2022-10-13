using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    //public GameObject button;

    /*public void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        gameObject.SetActive(false);
    }*/
    private void Update()
    {
        TriggerDialogue();
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        gameObject.SetActive(false);
    }
}
