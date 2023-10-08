using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlazmaMermiKod : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    float hizCarpani;
    public GameObject patlamaSablon;
    public GameObject isabetSablon;
    public OyuncuKod oyuncu;
    private void Awake()
    {
        oyuncu = GameObject.Find("Oyuncu").GetComponent<OyuncuKod>();
    }
    void Start()
    {

        hizCarpani = 3.0f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(hizCarpani, 0.0f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "SagSinir")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dusman"))
        {
            var yeniPatlama = Instantiate(patlamaSablon);
            yeniPatlama.transform.position = collision.gameObject.transform.position;

            Destroy(gameObject);
            Destroy(collision.gameObject);
            oyuncu.skorArttir();
        }
        if (collision.CompareTag("BuyukAsteroit"))
        {
            Destroy(gameObject);
            bool yokOldumu = collision.gameObject.GetComponent<BuyukAsteroitKod>().vuruldu();
            if (yokOldumu)
            {
                var yeniPatlama = Instantiate(patlamaSablon);
                yeniPatlama.transform.position = collision.gameObject.transform.position;
                oyuncu.skorArttir();
            }
            else
            {
                var isabet = Instantiate(isabetSablon);
                isabet.transform.position = gameObject.transform.position;
            }

        }
        if (collision.CompareTag("KucukAsteroit"))
        {
            var yeniPatlama = Instantiate(patlamaSablon);
            yeniPatlama.transform.position = collision.gameObject.transform.position;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            oyuncu.skorArttir();
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
