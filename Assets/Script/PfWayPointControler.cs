// []


using System.Collections;
using System.Collections.Generic;
using UnityEngine;




enum WayPointMode
{
   LOOP,
   PINGPONG


}


public class PfWayPointControler : MonoBehaviour
{

    [SerializeField]
    private Transform[] _wayPoint;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _distTolerance;

    [SerializeField]
    private WayPointMode _mode = WayPointMode.LOOP;

    // Private & Protected

    private int _targetWayPoint;
    private bool _isForward = true;
    //private const float JUMP = 3.8f;



    void Start()
    {
        // On place la plateforme au premier waypoint et on lui donne la target suivante

        transform.position = _wayPoint[0].position;
        _targetWayPoint = 1;



        // Faire partir la plateforme d'un point aléatoire


        /*int startWayPoint = Random.Range(0, _wayPoint.Length -1);
        transform.position = _wayPoint[startWayPoint].position;
        _targetWayPoint = startWayPoint + 1;*/



    }

    void Update()
    {

       Vector3 newPosition = Vector3.MoveTowards(transform.position, _wayPoint[_targetWayPoint].position, _speed * Time.deltaTime);

        transform.position = newPosition;

        if(Vector3.Distance(transform.position, _wayPoint[_targetWayPoint].position) <= _distTolerance)
        {

            switch (_mode)
            {
                case WayPointMode.LOOP:
                    Loop();
                    break;

                case WayPointMode.PINGPONG:
                    PingPong();
                    break;

            }













        }
    }


    void Loop()
    {
        _targetWayPoint++;
        if(_targetWayPoint >= _wayPoint.Length)
        {

            _targetWayPoint = 0;
        }


    }

    void PingPong()
    {
        if (_isForward) // => _isForward == true
        {

            _targetWayPoint++;

            if (_targetWayPoint >= _wayPoint.Length - 1)
            {
                _isForward = false;
                //_targetWayPoint = 0;
            }

        }
        else //!_isForward // => _isForward == false
        {
            _targetWayPoint--;

            if (_targetWayPoint <= 0)
            {
                _isForward = true;
                //_targetWayPoint = 0;
            }

        }


    }





}
