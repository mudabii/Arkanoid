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
    public int puntos;
    
    

    void Start()
    {
        pelotitaRB = GetComponent<Rigidbody2D>();
    }

    
    
    void Update()
  
    {
        if (!isMoving)
        {
            pelotitaRB.velocity = velocidadInicial;
            isMoving = true;
        }
        Lvl2();

    }
    private void OnCollisionEnter2D(Collision2D choque)
    {
        if (choque.gameObject.CompareTag("Brick"))
        {
            sumarScore.Contador(puntos);
            Destroy(choque.gameObject);
        }
        if (choque.gameObject.CompareTag("Fall"))
        {
            GameOver();
        }
        if (choque.gameObject.CompareTag("AeriLS"))
        {
            GameOver();
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene(3);
    }
    void Lvl2()
    {
        {
            GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
            if (bricks.Length == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}