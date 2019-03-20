using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject caixote;
    [SerializeField]
    private GameObject moeda;

    private GameManager _manager;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(obstaculos());
        StartCoroutine(moedas());
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

   IEnumerator obstaculos()
    {
        while(true)
        {
            Instantiate(caixote, new Vector3(Random.Range(-4.3f, 4.3f), .32f, 20f), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }

    IEnumerator moedas()
    {
        while (true)
        {
            Instantiate(moeda, new Vector3(Random.Range(-4.3f, 4.3f), 1f, 20f), Quaternion.identity);
            yield return new WaitForSeconds(8.0f);
        }
    }

    public void paraSpawn()
    {
        if(_manager.gameOver == true)
        {
            StopAllCoroutines();
        }
    }

}