using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucukAsteroitKod : MonoBehaviour
{

    Rigidbody2D rb;
    float hizCarpani;
    private void Awake()
    {
        hizCarpani = 0.3f;
        rb = GetComponent<Rigidbody2D>();
    }
    public void yonAta(float yon)
    {
        rb.velocity = new Vector3(-1.0f, yon, 0.0f) * hizCarpani;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "UstSinir" || collision.name == "AltSinir" || collision.CompareTag("KucukAsteroit"))
        {
            var hiz = rb.velocity;
            hiz.y = -hiz.y;
            rb.velocity = hiz;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "SolSinir")
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, 1.5f);
    }
}
