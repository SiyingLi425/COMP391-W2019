using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [Header ("Wave Settings")]
    //Define variables that control spawning my waves of enemies
    public GameObject hazard; //what are we spawning?
    public Vector2 spawnValue; //where do we spawn our hazards?
    public int hazardCount; //how many hazards do I want?
    public float startWait; //how long until the first wave?
    public float spawnWait; //how much time between each hazard in a wave?
    public float waveWait;// how long between waves of hazards?

    [Header ("UI Options")]
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    //private variables
    private int score = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        //Run a separate function from the rest of the code in its own thread
        StartCoroutine(SpawnWaves());
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    // IEumerator return type is required for Coroutines
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); //"Pause" this will "wait" for "startWait" second
        while (true) //now we want to spawn some stuff
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValue.x,Random.Range(-spawnValue.y, spawnValue.y));

                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait); //wait time between spawning each asteroid
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    //updates my scores text
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    //accepts score values, then calls update score.
    public  void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
}
