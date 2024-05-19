using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -7f)
        {
            float randomX = Random.Range(-9f, 9f);
            transform.position = new Vector3(randomX, 8f, 0);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        //if other is Player
        //damage the Player
        //destroy Enemy

        //if other is Laser
        //Destroy Laser
        //Destroy Enemy
    }
}
