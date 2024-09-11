using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pelota2 : MonoBehaviour
{
    public Vector2 velocidadInicial;
    private Rigidbody2D pelotitaRB;
    bool isMoving;
    public Score sumarScores;
    public int puntos;

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
            sumarScores.Contador(puntos);
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
    void Win()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        if (bricks.Length == 0)
        {
            SceneManager.LoadScene(4);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(3);
    }
}