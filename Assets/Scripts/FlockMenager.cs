using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockMenager : MonoBehaviour
{
    public GameObject = fishPrefab;
    public int numFish = 20;
    public GameObject[] = allFish;
    public Vector3 swimLimits = new Vector3(5, 5, 5);

    // Start is called before the first frame update
    void Start()
    {
        allFish = new GameObject[numFish];
        for (int i = 0; i < numFish; i++)
        {
            Vector3 pos - this.transform.position + new Vector3(Random.Range(-swinLimits.x, swinLimits.x)
                                                                Random.Range(-swinLimits.y, swinLimits.y)
                                                                Random.Range(-swinLimits.z, swinLimits.z));
            allFish[i] = Instantiate(fishPrefab, pos, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
