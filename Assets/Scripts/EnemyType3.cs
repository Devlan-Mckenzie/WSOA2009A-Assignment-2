using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyType3 : MonoBehaviour
{
    Vector3 pos;
    Vector3 top = new Vector3(7, 3.5f, 0);
    Vector3 bottom = new Vector3(7, -3.5f, 0);
    public float moveSpeed = 1f;
    bool Up = true;
    bool Down = false;
    public int HitPoints = 20;
    int currentHits = 0;
    private Rigidbody2D rb2d;
    public GameObject EnemyBullet;
    private float Timer = 0f;
    public int BPS = 2;
    private float xCord;
    private float yCord;
    public GameManagment_Script gamemanager;
    public int scoreValue;
    public Text gameOver;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        GameObject gameManagerObject = GameObject.FindWithTag("GameController");
        if (gameManagerObject != null)
        {
            gamemanager = gameManagerObject.GetComponent<GameManagment_Script>();
        }
        GameObject gameoverText = GameObject.FindWithTag("GameOver");
        if (gameoverText != null)
        {
            gameOver = gameoverText.GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        xCord = rb2d.transform.position.x;
        yCord = rb2d.transform.position.y;
        Vector3 CurrentPos = new Vector3(xCord, yCord, 0);
        if (Timer > (1f / BPS))
        {
            GameObject EnemyBulletInstance;
            EnemyBulletInstance = Instantiate(EnemyBullet, CurrentPos, Quaternion.identity);
            Timer = 0;
        }

        if (transform.position.x > 7)
        {
            pos -= transform.right * Time.deltaTime * moveSpeed;
            transform.position = pos;
        }
        else
        {
            if (Up)
            {
                moveUp();
                if (transform.position.y == 3.5)
                {
                    Up = false;
                    Down = true;
                }
            }

            if (Down)
            {
                moveDown();
                if (transform.position.y == -3.5)
                {
                    Down = false;
                    Up = true;
                }
            }
        }
        
    }

    void moveUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, top, 0.1f);
    }

    void moveDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, bottom, 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullets")
        {
            currentHits++;
            if (currentHits == HitPoints)
            {
              Destroy(gameObject);
              gamemanager.AddScore(scoreValue);
               gameOver.enabled = true;
              Time.timeScale = 0;
            }
            Destroy(collision.gameObject);
        }
    }
}
