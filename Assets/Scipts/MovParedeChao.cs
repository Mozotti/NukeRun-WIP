using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovParedeChao : MonoBehaviour
{
    float velocidade = .5f;
        
    void Update()
    {
        //define o movimento e a velocidade da textura da parede e do chão.
        float movimentoTex = Time.time * velocidade;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -movimentoTex);
    }
}
