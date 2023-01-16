using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerCollected : MonoBehaviour
{

    [SerializeField]
    private IntVariables _beerCollected;

    [SerializeField]
    private int _pointBeer;

    private void Awake()
    {
        _beerCollected.m_value = 0;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            _beerCollected.m_value++; //+= _pointBeer   => pour ajouter des points en fonction des bieres
            Destroy(gameObject);


        }


    }
}
