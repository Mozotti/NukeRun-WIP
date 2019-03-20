using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{

    public Sprite[] vidas;
    public Image mostraVidas;
    public int lifes;

    public Text textScore;
    public float calculaScore = 0;
    public int totalScore;
    
    private GameManager manager;

    public Text textMoedas;
    public int totalMoedas = 0;
    public int moedas;
    private int scorefinal;
    string HighscoreKey;
    public int highScore; 
    public GameObject menuPrincipal;

    public Text bemvindo;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(HighscoreKey, 0);
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void atualizaVidas(int vidasAtivas)
    {
        lifes = vidasAtivas;
        mostraVidas.sprite = vidas[lifes];
    }

    public void atualizaScore()
    {
        float tempo = 1.5f;
        calculaScore = calculaScore + Time.deltaTime * tempo;
        totalScore = (int)calculaScore + (totalMoedas * 10); 
        textScore.text = "Score: " + totalScore;

       if (manager.gameOver == true)
        {
            scorefinal = totalScore;
        }
    }


    public void scoreBoard()
    {

        if (scorefinal > highScore)
        {
            PlayerPrefs.SetInt(HighscoreKey, scorefinal);
            PlayerPrefs.Save();
        }
    }

    public void mostraScoreboard()
    {
        bemvindo.text = "Bem vindo ao NukeRun Game! :D\n" +
            "\n"+
            "aperte espaço para começar!";


    }

    public void atualizaMoedas()
    {
        moedas++;
        totalMoedas = moedas;
        textMoedas.text = "" + totalMoedas;
    }

    public void mostraTela()
    {
        //scorefinal[] = totalScore;
        menuPrincipal.SetActive(true);
        mostraScoreboard();
        
               
    }

    public void ocultaTela()
    {
        moedas = 0;
        calculaScore = 0;
        menuPrincipal.SetActive(false);
        
    }

    

}
