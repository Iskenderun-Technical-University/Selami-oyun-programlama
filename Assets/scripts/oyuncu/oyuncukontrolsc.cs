using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyuncukontrolsc : MonoBehaviour
{
    
    public GameObject GameManager;

    public GameObject oyuncumermisi;
    public GameObject merminok1;
    public GameObject merminok2;
    public GameObject patlamaani;

    public Text oyuncucan;

    const int maxcan = 3; //maximum oyuncu can�
    int lives; //oyuncu can

    public float speed;

    public void Init()
    {
        lives = maxcan;

        oyuncucan.text = lives.ToString ();

        transform.position = new Vector2 (0, 0);

        gameObject.SetActive(true);

    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<AudioSource>().Play();

            GameObject mermi01 = (GameObject)Instantiate(oyuncumermisi);
            mermi01.transform.position = merminok1.transform.position;

            GameObject mermi02 = (GameObject)Instantiate(oyuncumermisi);
            mermi02.transform.position = merminok2.transform.position;

        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;


        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        // oyuncunun harita d���na ��kmas�n� engelleme
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);


        transform.position = pos; //oyuncu yerinin de�i�mesi
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if((col.tag == "dusmangemisiTag") || (col.tag == "dusmanmermisiTag"))
        {
            patlamaoynat();

            lives--;
            oyuncucan.text = lives.ToString(); //can�n de�i�mesi

            if(lives == 0) //oyuncu �l�rse
            {

                GameManager.GetComponent<GameManagersc>().SetGameManagerState(GameManagersc.GameManagerState.gameover);
                
                gameObject.SetActive(false); //oyuncu gemisini saklama

            }

        }
    }


    void patlamaoynat()
    {
        GameObject patlama = (GameObject)Instantiate(patlamaani);

        patlama.transform.position = transform.position;
    }
}
