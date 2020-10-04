using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyPlayerBullets : MonoBehaviour
{
    public GameManagment_Script gamemanager;
    
    public int scoreValue;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameController");
        if (gameManagerObject != null)
        {
            gamemanager = gameManagerObject.GetComponent<GameManagment_Script>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullets")
        {
            gamemanager.AddScore(scoreValue);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
