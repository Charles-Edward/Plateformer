//[]



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed = 5;

    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    int _maxJump;


    [SerializeField]
    int _fallGravity;

    [SerializeField]
    float _jumpGravity;

    [SerializeField]
    Animator _animator;

    [SerializeField]
    [Range(0,1f)]
    float _radius;


    [SerializeField]
    [Range(-10,20)]
    float _offsetYGroundChecker;


    [SerializeField]
    LayerMask _layer;


    // Private & protected
    private Rigidbody2D _rb2D;
    private Vector2 _direction;
    private bool _isJumping;
    private int _numbJump = 0;



    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
    }

    void Update()
    {
        // Groundchecker

        Vector3 positionTransformOffset = new Vector3(transform.position.x, transform.position.y - _offsetYGroundChecker, transform.position.z);
        Collider2D floorCollider = Physics2D.OverlapCircle(positionTransformOffset, _radius, _layer);




        // Recuperation des bouttons pour le déplacement
        _direction.x = Input.GetAxisRaw("Horizontal") * _moveSpeed;

        _animator.SetFloat("moveSpeedX",Mathf.Abs (_direction.x));
        _animator.SetFloat("moveSpeedY", _direction.y);
       

        // Recuperation des bouttos pour le saut
        if (Input.GetButtonDown("Jump") && _numbJump < _maxJump)
        {
            _isJumping = true;

        }

        if (floorCollider != null)
        {
            if(floorCollider.tag == "Floor")
            {
                _animator.SetTrigger("Grounded");
                _numbJump = 0;
                //GroundCheck();
            }

        }


    }

    private void FixedUpdate()                      // Gerer les collisions, la physique 
    {
        // Application de la gravité

        _direction.y = _rb2D.velocity.y;


        // Application de la force pour le déplacement
        _rb2D.velocity = _direction;

        // Application de la force pour le saut
        if (_isJumping && _numbJump < _maxJump)
        {
            _numbJump++;
            _isJumping = false;
            /*Vector2 jumpinForce = new Vector2(_direction.x, _direction.y = _jumpForce);     // Addforce additione les forces pour que le deuxieme saut soit plus puissant
            _rb2D.AddForce(jumpinForce);*/


            _direction.y = _jumpForce;
            _rb2D.velocity = _direction * Time.fixedDeltaTime;

        }




        // Gerer la vitesse de chutte du player
        if (_rb2D.velocity.y < -0.1f)
        {
            _rb2D.gravityScale = _fallGravity;

        }
        else if (_rb2D.velocity.y >0.1f)
        {
            _rb2D.gravityScale = _jumpGravity;

        }


        else
        {

            _rb2D.gravityScale = 1;
        }


        // Retrouner le personnage dans la bonne direction     2 Methodes

        if(_direction.x < 0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); //transform.localScale = new Vector3(-1, 1, 1);


        }
        else if(_direction.x > 0f)
        {

            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); //transform.localScale = new Vector3(1, 1, 1);
        }

        /*if(_direction.x < 0.1f || _direction.x > 0.1f)
        {

            transform.right = new Vector2 (_direction.x, 0);


        }*/
        



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "SecretWay")
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;


        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SecretWay")
        {
            collision.GetComponent<SpriteRenderer>().enabled = true;


        }


    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Floor"))
        {
            _animator.SetTrigger("Grounded");
            _numbJump = 0; 

        }



        
    }*/


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 positionTransformOffset = new Vector3(transform.position.x, transform.position.y - _offsetYGroundChecker, transform.position.z);


        Gizmos.DrawWireSphere(positionTransformOffset, _radius);


    }

   /* void GroundCheck()
    {
        // GroundChcker
        Vector3 positionTransformOffset = new Vector3(transform.position.x, transform.position.y - _offsetYGroundChecker, transform.position.z);
        Collider2D floorCollider = Physics2D.OverlapCircle(positionTransformOffset, _radius, _layer);

        if (floorCollider != null)
        {

            _animator.SetTrigger("Grounded");
            _numbJump = 0;

            if (floorCollider.CompareTag("Plateforme"))
            {
                transform.SetParent(floorCollider.transform);


            }
        }
            else
            {
                transform.SetParent(null);

            }
    }*/

        


    


}




