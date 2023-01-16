using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    [SerializeField]
    private IntVariables _beerCount;


    // Private & Protected
    private TextMeshProUGUI _label;




    private void Awake()
    {
        _label = GetComponent<TextMeshProUGUI>();



    }

    void Start()
    {




        
    }

    void Update()
    {

        _label.text = _beerCount.m_value.ToString();



        
    }




}



