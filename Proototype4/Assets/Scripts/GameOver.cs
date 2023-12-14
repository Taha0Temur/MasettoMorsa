using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverScreen;

    void Start()
    {
        GameOverScreen.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            if (gameObject.tag == "gameOver")
            {
                GameOverScreen.SetActive(true);
            Time.timeScale = 0.0f;
            }
        }
    }
}
