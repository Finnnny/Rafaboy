using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Switch to 640 x 480 full-screen
        Screen.SetResolution(1920,1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
