using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gezegenkontsc : MonoBehaviour
{
    public GameObject[] gezegenler;

    Queue<GameObject> mevcutgezegenler = new Queue<GameObject>();

    void Start()
    {

        mevcutgezegenler.Enqueue(gezegenler[0]);
        mevcutgezegenler.Enqueue(gezegenler[1]);
        mevcutgezegenler.Enqueue(gezegenler[2]);

        InvokeRepeating("gezegenhareket", 0, 20f);
    }

    
    void Update()
    {
        
    }

    void gezegenhareket()
    {
        Enqueuegezegenler();

        if (mevcutgezegenler.Count == 0)
            return;

        GameObject birgezegen = mevcutgezegenler.Dequeue();

        birgezegen.GetComponent<gezegensc>().hareket = true;
    }

    void Enqueuegezegenler()
    {
        foreach (GameObject birgezegen in gezegenler)
        {

            if((birgezegen.transform.position.y < 0) && (!birgezegen.GetComponent<gezegensc>().hareket))
            {

                birgezegen.GetComponent<gezegensc>().ResetPosition();

                mevcutgezegenler.Enqueue(birgezegen);
            }
        }
    }
}
