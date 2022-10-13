using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highestHeight : MonoBehaviour
{
    public Text PalingTinggi;
    // Start is called before the first frame update
    void Start()
    {
        PalingTinggi.text = PlayerPrefs.GetInt("HighHeight", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PalingTinggi.text = PlayerPrefs.GetInt("HighHeight", 0).ToString();
    }
}
