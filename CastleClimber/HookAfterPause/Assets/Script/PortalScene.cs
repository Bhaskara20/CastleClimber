using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScene : MonoBehaviour
{
    public GameObject win;
    //public string sceneToLoad;
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger){
            win.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
