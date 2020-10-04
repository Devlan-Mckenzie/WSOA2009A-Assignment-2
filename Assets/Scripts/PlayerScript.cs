using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    public GameObject Bullet;
    private float xCord;
    private float yCord;
    private float Timer = 0f;
    public int BPS = 2;
    int Lifes = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public Text gameoverText;
    public Text startscreenText;
    public GameManagment_Script gamemanager;
    AudioSource mySource;

    // Start is called before the first frame update
    void Start()
    {
         mySource = GetComponent<AudioSource>();

        GameObject gameManagerObject = GameObject.FindWithTag("GameController");
        if (gameManagerObject != null)
        {
            gamemanager = gameManagerObject.GetComponent<GameManagment_Script>();
        }

        rb2d = GetComponent<Rigidbody2D>();
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        Lifes = 3;
        gameoverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        BPS = (gamemanager.score / 30)+1;
        Timer += Time.deltaTime;
        xCord = rb2d.transform.position.x;
        yCord = rb2d.transform.position.y;
        Vector3 CurrentPos = new Vector3(xCord, yCord, 0);

        if (gameoverText.enabled == false)
        {
            if (Input.GetButton("Jump"))
            {
                Time.timeScale = 1;
                startscreenText.enabled = false;
                if (Timer > (1f / BPS))
                {
                    mySource.Play();
                    GameObject BulletInstance;
                    BulletInstance = Instantiate(Bullet, CurrentPos, Quaternion.identity);
                    Timer = 0;

                }
            }
        }
        else
        {
            startscreenText.enabled = true;
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
       
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal * speed,moveVertical * speed);
        rb2d.velocity = movement; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Enemy") || (collision.gameObject.tag == "EnemyBullets"))
        {            
            Lifes--;
            if (Lifes == 3)
            {
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
            }
            if (Lifes == 2)
            {
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
            }
            if (Lifes == 1)
            {
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
            }

            if (Lifes == 0)
            {
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                //Destroy(gameObject);
                gameObject.GetComponent<Renderer>().enabled = false;
                Time.timeScale = 0;
                gameoverText.enabled = true;
            }
            Destroy(collision.gameObject);
        }
    }
}
