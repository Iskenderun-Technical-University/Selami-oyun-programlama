using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagersc : MonoBehaviour
{

    public GameObject playButton;
    public GameObject oyuncugemisi;
    public GameObject dusmand;
    public GameObject gameoverob;
    public GameObject skortextgo;
    public GameObject starwars;
    public enum GameManagerState
    {
        opening,
        gameplay,
        gameover,
    }

    GameManagerState GMState;

    void Start()
    {
        GMState = GameManagerState.opening;
    }


    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.opening:

                gameoverob.SetActive(false); //game over gizleme

                starwars.SetActive(true);

                playButton.SetActive(true);


                break;
            case GameManagerState.gameplay:

                skortextgo.GetComponent<oyunskor>().Skor = 0; //skorun s�f�rlanmas�

                playButton.SetActive(false); //play butonunu oyun i�inde gizleme

                starwars.SetActive(false); //oyun ismini oyun i�inde gizleme

                oyuncugemisi.GetComponent<oyuncukontrolsc>().Init();

                dusmand.GetComponent<dusmandnsc>().dusmandz(); // d��man do�umunu ba�latma

                break;

            case GameManagerState.gameover:

                dusmand.GetComponent<dusmandnsc>().sonrakidusmandd(); // d��man do�umunu durdurma

                gameoverob.SetActive(true);

                Invoke("openingegecis", 8f);

                break;

        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void Startgameplay()
    {
        GMState = GameManagerState.gameplay;
        UpdateGameManagerState ();
    }

    public void openingegecis()
    {
        SetGameManagerState(GameManagerState.opening);
    }
}
