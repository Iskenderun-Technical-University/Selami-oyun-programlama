using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gezegensc : MonoBehaviour
{
    public float hiz;
    public bool hareket;

    Vector2 min;
    Vector2 max;

    void Awake()
    {
        hareket = false;

        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if (!hareket)
            return;

        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + hiz * Time.deltaTime);

        transform.position = position;

        if(transform.position.y < min.y)
        {
            hareket = false;
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);
    }
}
