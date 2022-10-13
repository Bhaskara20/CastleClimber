using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTembak : MonoBehaviour
{
    //public Transform[] target;
    public GameObject[] pluru;
    private float currenttime = 0f;
    private float starttime = 0f;
    private GameObject currentPluru;
    private int RandomPluru;
    //public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        RandomPluru = Random.Range(0, pluru.Length);
        currenttime = starttime;
       
;    }

    // Update is called once per frame
    void Update()
    {
        spawnPluru();
    }

    void spawnPluru()
    {
        currenttime += 1 * Time.deltaTime;
        Debug.Log(currenttime);
        currentPluru = pluru[RandomPluru];
        currentPluru.SetActive(true);
        if (currenttime >= 3.00f)
        {
            currentPluru.SetActive(false);
            currentPluru.transform.position = new Vector2(0.6f, 12.53f);
            currentPluru.GetComponent<Collider2D>().enabled = true;
            currenttime = starttime;
            
            RandomPluru = Random.Range(0, pluru.Length);
            while (pluru[RandomPluru] == currentPluru)
            {
                RandomPluru = Random.Range(0, pluru.Length);
            }

        }
    }
}
