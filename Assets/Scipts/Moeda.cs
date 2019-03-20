using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    private float velocidadeMoeda = 20.0f;
    public HUD hud;
    public int quantidade = 0;


    private void Start()
    {
        hud = GameObject.Find("Canvas").GetComponent<HUD>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player") 
        {
            hud.atualizaMoedas();
            Destroy(this.gameObject);

        }
        if(other.tag == "Moeda" || other.tag == "Caixote")
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * velocidadeMoeda);

        if (transform.position.z < -10)
        {
            float randomX = Random.Range(-4.3f, 4.3f);
            float randomY = Random.Range(1f, 2f);
            transform.position = new Vector3(randomX, randomY, 20f);
        }
    }
}