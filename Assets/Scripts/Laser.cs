using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;
    private bool _isEnemyLaser = false;
    void Update()
    {
        if (_isEnemyLaser == false)
        {
            MoveLaserUp();
        }
        else
        {
            MoveLaserDown();
        }
        
    }

    void MoveLaserUp()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);



        if (transform.position.y >= 8f)
        { 
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    void MoveLaserDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);



        if (transform.position.y < -8f)
        {

            
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true; 
    }

  
}
