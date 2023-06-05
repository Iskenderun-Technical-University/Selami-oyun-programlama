using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yildizsc : MonoBehaviour
{
    public float hiz;

    void Start()
    {
        
    }

    
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2 (position.x, position.y + hiz * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.y < min.y)
        {
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
    }
}
