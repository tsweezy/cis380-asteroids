using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    int variantNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawns an asteroid at increasing intervals
    IEnumerator SpawnAsteroid()
    {
        float delay = 5f;
        while(true)
        {
            print(delay);
            if (delay >= 0.125f)
                delay -= 0.0625f;
            if (Physics2D.OverlapCircle(gameObject.transform.position, 0.75f) == null)
            {
                // instantiate new asteroid GameObject
                Instantiate(Resources.Load("Asteroid" + variantNumber++ % 6), gameObject.transform);
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
