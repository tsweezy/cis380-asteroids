using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject text;

    public static int gameOver = 0;

    public Text myVal;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Game Over Text");
        myVal = GetComponent<Text>();
        myVal.enabled = false;
    }

    void Update() {

        if(gameOver == 1) {
            myVal.enabled = true;

            if(Input.GetKey(KeyCode.V)) {
                SceneManager.LoadScene("SampleScene");
                myVal.enabled = false;
                LivesController.lifeCount = 3;
                ControllerScore.scoreCount = 0;
                Time.timeScale = 1;
                gameOver = 0;
            }
        }
       
    }

    
}
