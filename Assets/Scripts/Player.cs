using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    [SerializeField]
    private float _speed = 3.5f;
    
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _fireRate = 0.15f;
    private float _canFire = -1f;
    [SerializeField]
    private bool _tripleShotActive = false;
    [SerializeField]
    private int _lives = 3;

    private SpawnManager _spawnManager;



    
   
    void Start()
    {
       
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

       
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }

       
    }

    void CalculateMovement()
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }

        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }
        
        if (transform.position.x >= 11)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x <= -11)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }

        
    }

    void FireLaser()
    {

        _canFire = Time.time + _fireRate;

        if (_tripleShotActive == true)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }

        else
        {
            Instantiate(_laser, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }

        



        
     

     
        
        //if Space Key pressed, 
        //if tripleShotActive is true
             //fire 3 lasers (triple shot prefab)

        //else fire 1 laser

        //instantiate 3 lasers (Triple Shot prefab)

    }

    public void Damage()
    {
        _lives -= 1;

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();

            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        _tripleShotActive = true;

        StartCoroutine(TripleShotPowerDownRoutine());

    }

    //IEnumerator TripleShotPowerDownRoutine
    //Wait for 5 seconds
    //set Triple Shot to false

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _tripleShotActive = false;
    }

}
