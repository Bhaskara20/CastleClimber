using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text DialogueText;
    public Animator animator;
    public string scene;
    private Queue<string> kata;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        kata = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        //Debug.Log("Memulai scene");
        nameText.text = dialogue.name;
        kata.Clear();

        foreach (string kalimat in dialogue.kalimat)
        {
            kata.Enqueue(kalimat);
        }

        DisplayNextKalimat();
    }

    public void DisplayNextKalimat()
    {
        if (kata.Count == 0)
        {
            EndDialogue();
            return;
        }

        string kalimat = kata.Dequeue();
        //Debug.Log(kalimat);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(kalimat));
       // DialogueText.text = kalimat;
    }

    IEnumerator TypeSentence(string kalimat)
    {
        DialogueText.text = "";
        foreach (char huruf in kalimat.ToCharArray())
        {
            DialogueText.text += huruf;
            yield return new WaitForSeconds(.05f);
        }
    }
    

    public void EndDialogue()
    {
        float r, g, b = 39;
        float a = 255;
        animator.SetBool("isOpen", false);
        Debug.Log("Selesai!");
        GameObject varGameObject = GameObject.FindWithTag("NPC");
        Color color;
        if (ColorUtility.TryParseHtmlString("#333333", out color))
        {
            varGameObject.GetComponent<SpriteRenderer>().color = color;
        }
        varGameObject.GetComponent<Pergi>().enabled = true;
        //SceneManager.LoadScene(scene);
    }

    public void EndBoss()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("Selesai!");
    }
}
