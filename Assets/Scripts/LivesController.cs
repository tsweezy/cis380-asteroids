using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivesController : MonoBehaviour
{
    public Text lives;
    public static int lifeCount = 3;

    // Start is called before the first frame update
    void Start()
    {
    
        lives = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = "Lives: " + lifeCount;
    }
}
