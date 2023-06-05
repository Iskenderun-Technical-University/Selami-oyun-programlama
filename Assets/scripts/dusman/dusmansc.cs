using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusmansc : MonoBehaviour
{
    GameObject skortextgo;

    public GameObject patlamaani;

    float speed;

    
    void Start()
    {
        speed = 2f;

        skortextgo = GameObject.FindGameObjectWithTag ("skortextTag");
    }

    
    void Update()
    {

        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));


        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "oyuncugemisiTag") || (col.tag == "oyuncumermisiTag"))
        {
            patlamaoynat();

            skortextgo.GetComponent<oyunskor>().Skor += 100;

            Destroy(gameObject);
        }
    }

    void patlamaoynat()
    {
        GameObject patlama = (GameObject)Instantiate(patlamaani);

        patlama.transform.position = transform.position;
    }
}
