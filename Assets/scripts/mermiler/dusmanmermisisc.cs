using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusmanmermisisc : MonoBehaviour
{

    float speed;
    Vector2 yon;
    bool hazir;

    void Awake()
    {
        speed = 5f;
        hazir = false;

    }

    void Start()
    {
        
    }

    public void Setyon(Vector2 direction)
    {

        yon = direction.normalized;

        hazir = true;
    }


    void Update()
    {
        if (hazir)
        {
            Vector2 position = transform.position;

            position += yon * speed * Time.deltaTime;

            transform.position = position;


            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));


            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "oyuncugemisiTag")
        {
            Destroy(gameObject);
        }
    }
}
