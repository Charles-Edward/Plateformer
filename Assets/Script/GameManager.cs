using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject _spawn;

    [SerializeField]
    GameObject _player;

    [SerializeField]
    SpriteRenderer _secretWall;

    [SerializeField]
    int _nameScene;

    void Start()
    {




        
    }

    void Update()
    {




        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Void"))
        {
            IsDead();
            _player.transform.position = _spawn.transform.position;

        }

        if (collision.CompareTag("Door"))
        {
            _nameScene++;
            ChangeScene();
        }

        

    }

    private void IsDead()
    {
        
        Debug.Log("Dead");
        
        
    }

    private void Respawn()
    {

        /*if ()
        {
            _player.transform.position = _spawn.transform.position;

        }*/
        


    }

    private void ChangeScene()
    {

        SceneManager.LoadScene(_nameScene);

    }
}
