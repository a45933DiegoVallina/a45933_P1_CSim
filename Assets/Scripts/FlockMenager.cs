using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Não está igual ao código original pois deu erro e eu tive de tirar as Listas para funcionar
public class FlockMenager : MonoBehaviour
{
    public GameObject allFish ;
    public int numFish = 20;
    
    public Vector3 swimLimits = new Vector3(5, 5, 5);

    // Start is called before the first frame update
    void Start()
    {
        //allFish = new GameObject[numFish];
        for (int i = 0; i < numFish; i++)
        {
            
            //Mexer os peixes - com limits 
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x), Random.Range(-swimLimits.y, swimLimits.y), Random.Range(-swimLimits.z, swimLimits.z));
            allFish = Instantiate(allFish, pos, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
