using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject PopUpBox;
    public Text PopUpText;
    public string Text;
    public bool PopUpActive;



    // Update is called once per frame
    void Update()
    {
        if(PopUpActive){
            if(PopUpBox.activeInHierarchy && !PopUpActive){
                PopUpBox.SetActive(false);
            }
            else{
                PopUpBox.SetActive(true);
                PopUpText.text = Text;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
           PopUpActive = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            PopUpActive = false;
            PopUpBox.SetActive(false);
        }
    }
}