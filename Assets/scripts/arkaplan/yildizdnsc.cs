using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yildizdnsc : MonoBehaviour
{
    public GameObject yildiz;
    public int maxyildiz;

    Color[] yildizrenk =
    {
        new Color(0.5f, 0.5f, 1f), //mavi
        new Color(0, 1f, 1f), //yeþil
        new Color(1f, 1f, 0), //sarý
        new Color(1f, 0, 0), //kýrmýzý
    };

    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        for(int i = 0; i < maxyildiz; ++i)
        {
            GameObject star = (GameObject)Instantiate(yildiz);

            star.GetComponent<SpriteRenderer>().color = yildizrenk[i % yildizrenk.Length];

            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            star.GetComponent<yildizsc>().hiz = -(1f * Random.value + 0.5f);

            star.transform.parent = transform;
        }
    }

    
    void Update()
    {
        
    }
}
