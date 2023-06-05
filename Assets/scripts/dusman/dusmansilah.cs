using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusmansilah : MonoBehaviour
{

    public GameObject dusmanmermisi;
    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    
    void Update()
    {
        
    }


    void FireEnemyBullet()
    {

        GameObject playerShip = GameObject.Find("oyuncu");

        if (playerShip != null)
        {

            GameObject mermi = (GameObject)Instantiate(dusmanmermisi);

            mermi.transform.position = transform.position;

            Vector2 yon = playerShip.transform.position - mermi.transform.position;

            mermi.GetComponent<dusmanmermisisc>().Setyon(yon);
        }
    }
}
