using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public bool pausado;
    public GameObject Player;
    private HUD _hud;
    

    private void Start()
    {
        _hud = GameObject.Find("Canvas").GetComponent<HUD>();
        pausado = false;
    }

    void Update()
    {
        _hud.mostraScoreboard();
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Time.timeScale = 1;
                Instantiate(Player, new Vector3(0f, .32f, -7f), Quaternion.identity);
                gameOver = false;
                _hud.ocultaTela();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausado)
            {
                pauseGame();
            }
            else if (pausado)
            {
                continuaGame();
            }
        }

    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        pausado = true;
    }

    public void continuaGame()
    {
        Time.timeScale = 1;
        pausado = false;
    }
   
}
