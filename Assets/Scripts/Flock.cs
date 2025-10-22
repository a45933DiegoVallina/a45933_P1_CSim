using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = Random.Range(FlockManager_Original.FM.minSpeed, FlockManager_Original.FM.maxSpeed);
    }

    void Update()
    {
        if (Random.Range(0, 100) < 10)
        {
            speed = Random.Range(FlockManager_Original.FM.minSpeed, FlockManager_Original.FM.maxSpeed);
        }
        if (Random.Range(0, 100) < 10)
        {
            ApplyRules();
            StayWithinBounds(); // <- A alteração que fiz. mantém o peixe dentro do limite. Lá embaixo tem um void só pra ela
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    void ApplyRules()
    {
        GameObject[] gos = FlockManager_Original.FM.allFish;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, transform.position);
                if (nDistance <= FlockManager_Original.FM.vizinhoDistance)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if (nDistance < 1.0f)
                        vavoid += (transform.position - go.transform.position);

                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed += anotherFlock.speed;
                }
            }
        }

        if (groupSize > 0)
        {
            vcentre = vcentre / groupSize + (FlockManager_Original.FM.goalPos - transform.position);
            speed = gSpeed / groupSize;
            //if (speed > FlockManager_Orignal.FM.maxSpeed)
                //speed = FlockManager_Orignal.FM.maxSpeed;
            
                
            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(direction),
                    FlockManager_Original.FM.rotationSpeed * Time.deltaTime
                );
            }
        }
    }

    //Aqui que me diferenciei do tutorial. Tem os mesmos princípios matemáticos e até pedaços de código reaproveitados, mas com um void próprio

    void StayWithinBounds()
    {
        Vector3 pos = transform.position;
        Vector3 centre = FlockManager_Original.FM.transform.position;
        Vector3 limit = FlockManager_Original.FM.swimLimits;

        if (Mathf.Abs(pos.x - centre.x) > limit.x ||
            Mathf.Abs(pos.y - centre.y) > limit.y ||
            Mathf.Abs(pos.z - centre.z) > limit.z)
        {
            Vector3 directionToCentre = centre - pos;
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(directionToCentre),
                FlockManager_Original.FM.rotationSpeed * Time.deltaTime
            );
        }
    }
}
