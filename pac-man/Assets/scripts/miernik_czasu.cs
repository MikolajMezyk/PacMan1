using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miernik_czasu : MonoBehaviour
{
    private float fps = 30f;

    void OnGUI()
    {
        float newFPS = 1.0f / Time.smoothDeltaTime;
        fps = Mathf.Lerp(fps, newFPS, 0.0005f);
        GUI.Label(new Rect(0, 0, 100, 100), "FPS: " + ((int)fps).ToString());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
