using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;

    private float velocidadePlayer = 5.0f;
    private float velocidadePulo = 8.0f;
    private float velocidadePuloDuplo = 16f;
    private float gravidade = 20.0f;
    private bool pulando;
    
    public int lifes = 3;

    private Vector3 direcao = Vector3.zero;
    private CharacterController controlador;

    public HUD _hud;
    public GameManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(0, 0.25f, -7f);

        pulando = false;
        
        controlador = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        _hud = GameObject.Find("Canvas").GetComponent<HUD>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (_hud != null)
        {
            _hud.atualizaVidas(lifes);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
        _hud.atualizaScore();
        
    }

    //funçao que define o calculo de movimentação do player
    private void Movimentacao()
    {

        if (controlador.isGrounded)
        {
            //Seta os inputs, movimentação/pulos e a direção
            float inputHorizontal = Input.GetAxis("Horizontal");
            direcao = new Vector3(inputHorizontal, 0.0f, 0.0f);
            direcao = transform.TransformDirection(direcao);
            direcao = direcao * velocidadePlayer;
            //Pulo
            if (Input.GetButton("Jump") && null != anim)
            {
                anim.SetTrigger("Pulo");
                direcao.y = velocidadePulo;
                pulando = true;
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    if (Input.GetKeyDown(KeyCode.Space) && pulando == true)
                    {
                        anim.SetTrigger("Pulo");
                        direcao.y = direcao.y + (velocidadePuloDuplo * Time.deltaTime);
                        pulando = false;
                    }
                }
            }
            //animação de se abaixar
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && null != anim)
            {
                anim.SetTrigger("Abaixar");
            }
        }
        //define a gravidade
        direcao.y = direcao.y - (gravidade * Time.deltaTime);
        //define o movimento conforme o tempo real
        controlador.Move(direcao * Time.deltaTime);
    }

    //Define o calculo de dano
    public void Dano()
    {
        lifes--;
        _hud.atualizaVidas(lifes);
        if (lifes < 1)
        {
            anim.SetTrigger("Morte");
            Destroy(this.gameObject, 2f);
            manager.gameOver = true;
            _hud.mostraTela();
        }

    }
    //colisão com obstáculos
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstaculo")
        {
            Dano();
        }
    }
    /*private void OnDestroy()
    {
        anim.SetTrigger("Morte");
    }*/


}
