using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    [SerializeField]
    private GameObject _enemyLaserPrefab;
    private Player _player;
    private Animator _anim;
    [SerializeField]
    private AudioSource _audioSource;
    private float _enemyFireRate = 3.0f;
    private float _canFire = -1f;
    //handle to animator component
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
        if (_player == null)
        {
            Debug.LogError("The Player is NULL");
        }
        _anim = GetComponent<Animator>();

        if (_anim == null)
        {
            Debug.LogError("The Animator is NULL");
        }
        //assign the component to Anim
    }

    
    void Update()
    {
        CalculateMovement();

        if (Time.time > _canFire)
        {
            _enemyFireRate = Random.Range(3f, 7f);
            _canFire = Time.time + _enemyFireRate;
            GameObject _enemyLaser = Instantiate(_enemyLaserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = _enemyLaser.GetComponentsInChildren<Laser>();

            for (int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();
            }
        }
        
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -7f)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, 8f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            //trigger anim
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _audioSource.Play();
            Destroy(this.gameObject, 2.8f);
            
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
           
            
            
            //Destroy(this.gameObject);

            if (_player != null)
            {
                _player.AddScore(10);
            }

            //trigger anim
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _audioSource.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.8f);
        }

        
    }
}
