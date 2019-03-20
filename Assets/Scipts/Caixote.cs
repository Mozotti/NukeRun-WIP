using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixote : MonoBehaviour
{
    private float velocidadeCaixote = 20.0f;
    private Player player;

    private void Start()
    {
        
        Player player = GetComponent<Player>();
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * velocidadeCaixote);

        if(transform.position.z < -10)
        {
           //Destroy(this.gameObject);
           float randomX = Random.Range(-4.3f, 4.3f);
           float randomY = Random.Range(.32f, 2f);
           transform.position = new Vector3(randomX, randomY, 20f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Moeda" || other.tag == "Caixote")
        {
            Destroy(this.gameObject);
        }
    }
}