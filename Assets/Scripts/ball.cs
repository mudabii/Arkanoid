using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour

{
    public Vector2 velocidadInicial;
    private Rigidbody2D pelotitaRB;
    bool isMoving;
    public Score sumarScore;
    bool ismoving;
    // Start is called before the first frame update

    void Start()
    {
        pelotitaRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    void Update()
  
    {
        if (!isMoving)
        {
            pelotitaRB.velocity = velocidadInicial;
            isMoving = true;
        }
        Win();

    }
    private void OnCollisionEnter2D(Collision2D choque)
    {
        if (choque.gameObject.CompareTag("Brick"))
        {
            
            Destroy(choque.gameObject);
        }
        if (choque.gameObject.CompareTag("Fall"))
        {
            GameOver();
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene(2);
    }
    void Win()
    {
        {
            GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
            if (bricks.Length == 0)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}