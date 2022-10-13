using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pluru2 : MonoBehaviour
{
    private Transform pos;
    private float speed = 10f;
    Collider2D lider;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        pos = GameObject.FindWithTag("target2").transform;
        lider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos.position, speed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            GameManager.instance.loseLife(1);
            lider.enabled = !lider.enabled;
            //SceneManager.LoadScene("castle");
        }
        if (other.CompareTag("target2") && !other.isTrigger)
        {
            lider.enabled = !lider.enabled;
        }
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        lider.enabled = !lider.enabled;

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            StartCoroutine(Delay());
            //SceneManager.LoadScene("castle");
        }
        if (collision.CompareTag("target2") && !collision.isTrigger)
        {
            lider.enabled = !lider.enabled;
        }
    }
}
