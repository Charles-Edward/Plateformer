// []

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    [SerializeField]
    Transform _target;

    [SerializeField]
    float _lerpTime = 5f;




    void Start()
    {




        
    }

    void Update()
    {




        
    }


    private void LateUpdate()       // Appeler à la fin de la frame     
    {
        


        // Suivi de la camera sur le player
        Vector3 newPosition = Vector3.Lerp(transform.position, _target.position, _lerpTime * Time.deltaTime);

        transform.position = new Vector3(newPosition.x, newPosition.y, -20f);


    }


}
