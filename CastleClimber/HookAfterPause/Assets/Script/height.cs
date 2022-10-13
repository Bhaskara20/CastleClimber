using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class height : MonoBehaviour
{
    public Text ketinggian;
    private float tinggiF;
    private int tinggi;
    public Text PalingTinggi;
  
    // Start is called before the first frame update
    void Start()
    {
       
        PalingTinggi.text = PlayerPrefs.GetInt("HighHeight", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tinggiF = gameObject.transform.position.y;
        if (tinggiF <= 0)
        {
            tinggiF = 0;

        }

        tinggi = (int)tinggiF;

        if (tinggi > PlayerPrefs.GetInt("HighHeight", 0))
        {
            PlayerPrefs.SetInt("HighHeight", tinggi);
            PalingTinggi.text =  tinggi.ToString();
        }
        
        ketinggian.text = tinggi.ToString();

    }

 
}
