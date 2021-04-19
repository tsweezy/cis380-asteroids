using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    int variantNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        //after 1 second every 3 seconds it will call SpawnAsteroid
        InvokeRepeating("SpawnAsteroid", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Hopefully spawns an asteroid
    void SpawnAsteroid()
    {
        // instantiate new asteroid GameObject
        GameObject asteroid = Instantiate(Resources.Load("Asteroid" + variantNumber++ % 6), gameObject.transform) as GameObject;
    }
}
