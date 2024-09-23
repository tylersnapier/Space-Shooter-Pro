using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 3.0f;
    [SerializeField]
    private GameObject _explosionPrefab;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }

    //check for Laser collission (Trigger)
    //instantiate explosion at the position of the asteroid 
    //destroy the explosion after 3 seconds
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.tag == "Laser")
      {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.25f);
      }
    }
}
