using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    GameObject rope;
    private Transform destination;
    public bool isOrange;
    public float distance = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        if (isOrange == false)
        {
            destination = GameObject.FindGameObjectWithTag("orange").GetComponent<Transform>();
        }else
        {
            destination = GameObject.FindGameObjectWithTag("blue").GetComponent<Transform>();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        //rope.SetActive(false);
        if (Vector2.Distance(transform.position, other.transform.position)>distance)
        {
            //disable rope
            other.transform.position = new Vector2 (destination.position.x , destination.position.y);
            //enable rope
            //rope.SetActive(true);
        }
    }
}
