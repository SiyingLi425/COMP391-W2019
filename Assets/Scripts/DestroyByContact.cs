using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject explosionPlayer;
    void OnTriggerEnter2D(Collider2D other)
        {

           

            if (other.tag == "Boundary")
            {
                return;
            }
            if (other.tag == "Player")
            {
            //trigger game over logic in here
            GameObject temp =  Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            
                Destroy(other.gameObject);
            }

        //Instantiate asteroid explosion animation
        Instantiate(explosion, this.transform.position, this.transform.rotation);

            Destroy(this.gameObject);  //Asteroid
            Destroy(other.gameObject); //Laser
        }
    
}
