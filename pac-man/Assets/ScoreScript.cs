using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text MyscoreText;
    private int Scorenum;
    // Start is called before the first frame update
    void Start()
    {
        Scorenum = 0;
        MyscoreText.text = "Score: " + Scorenum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
