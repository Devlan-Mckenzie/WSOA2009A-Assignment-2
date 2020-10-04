using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManagment_Script : MonoBehaviour
{
    public GameObject EnemyType1;
    public GameObject EnemyType2;
    public GameObject EnemyType3;
    public float E_posx = 16;
    public float E_posy = 4.5f;
    public float E_posz = 0;
    public float E_Gap = 1;
    public float spawnWait;
    public float waveWait;
    public float startWait;
    public int EnemyCount;
    private bool Wave1 = true;
    private bool Wave2 = false;
    private bool Wave3 = false;
    public float yOffset = 2f;
    public Text scoreText;
    public Text HighscoreText;
    public int score;
    int highscore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(Spawn());
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        HighscoreText.text = "HighScore: " + highscore;
        if (score > highscore )
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore",highscore);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    IEnumerator Spawn()
    {
        Wave1 = true;
        Wave2 = false;
        Wave3 = false;
        yield return new WaitForSecondsRealtime(startWait);
        GameObject EnemyInstance;
        bool downwards = true;

        while (Wave1)
        {
            EnemyCount = 9;
           
            for (int i = 0; i < EnemyCount; i++)
            {
                if (E_posy < -4.4f)
                {
                    E_posy = 3.3f;
                }
                Vector3 SpawnPos = new Vector3(E_posx, E_posy, E_posz);               
                EnemyInstance = Instantiate(EnemyType1, SpawnPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);                
                E_posy -= E_Gap;
                if (i == EnemyCount-1)
                {
                    Wave1 = false;
                    Wave2 = true;
                }
            }
            yield return new WaitForSeconds(waveWait);
        }

        while (Wave2)
        {
            EnemyCount = 18;
            E_posy = 4.5f;
            for (int i = 0; i < EnemyCount; i++)
            {   
                Vector3 SpawnPos = new Vector3(E_posx,E_posy, E_posz);
                EnemyInstance = Instantiate(EnemyType2, SpawnPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
                if (i == EnemyCount - 1)
                {
                   Wave2 = false;
                   Wave3 = true;
                }
                
                if (E_posy< -4.5f)
                {
                    downwards = false;
                }
                if (E_posy > 4.5f)
                {
                    downwards = true;
                }

                if (!downwards)
                {
                    E_posy += yOffset;
                }
                else
                {
                    E_posy -= yOffset;
                }
            }
            yield return new WaitForSeconds(waveWait);
        }

        while (Wave3)
        {
            EnemyCount = 1;
            E_posx = 13;
            E_posy = 0;
            for (int i = 0; i < EnemyCount; i++)
            {                
                Vector3 SpawnPos = new Vector3(E_posx, E_posy, E_posz);
                EnemyInstance = Instantiate(EnemyType3, SpawnPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);                
                if (i == EnemyCount - 1)
                {                   
                    Wave3 = false;                    
                }
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
}
