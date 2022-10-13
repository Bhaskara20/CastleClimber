using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pergi : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "STOP")
        {
            speed = 0f;
        }
    }
}
