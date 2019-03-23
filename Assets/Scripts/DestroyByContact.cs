using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject explosionPlayer;
    public int scoreValue = 10;
    public GameController gameController;


     void Start()
    {
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");
        
        if(gameControllerObj != null)
        {
            gameController = gameControllerObj.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("cannot find game controller script on object");
        }
    }
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
        gameController.AddScore(scoreValue);
        //Instantiate asteroid explosion animation
        Instantiate(explosion, this.transform.position, this.transform.rotation);

            
            Destroy(this.gameObject);  //Asteroid
            Destroy(other.gameObject); //Laser
        }
    
}
