using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OyuncuKod : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    Vector2 hareketVectoru;
    float dikeyHizCarpani;
    float yatayHizCarpani;
    TextMeshProUGUI skorTabelasi;
    private int skor;
    public GameObject patlamaSablon;
    // Start is called before the first frame update
    void Start()
    {
        skor = 0;
        yatayHizCarpani = 2.0f;
        dikeyHizCarpani = yatayHizCarpani * 0.75f;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        skorTabelasi = GameObject.Find("SkorTabelasi").GetComponent<TextMeshProUGUI>();
    }
    public void skorArttir()
    {
        skor += 10;
        skorYaz();
    }
    public void skorAzalt()
    {
        skor -= 10;
        skorYaz();
    }
    public void skorYaz()
    {
        skorTabelasi.text = "Skor:" + skor.ToString();
    }
    private void FixedUpdate()
    {
        hareketVectoru.x = 0.0f;
        hareketVectoru.y = 0.0f;
        bool asagiBasildimi = false;
        bool yukariBasildimi = false;
        if (Input.GetKey(KeyCode.W))
        {
            yukariBasildimi = true;
            hareketVectoru.y = dikeyHizCarpani;

        }
        if (Input.GetKey(KeyCode.S))
        {
            asagiBasildimi = true;
            hareketVectoru.y = -dikeyHizCarpani;
        }
        if (Input.GetKey(KeyCode.D))
        {
            hareketVectoru.x = yatayHizCarpani;
        }
        if (Input.GetKey(KeyCode.A))
        {
            hareketVectoru.x = -yatayHizCarpani;
        }
        animator.SetBool("YukariBasildimi", yukariBasildimi);
        animator.SetBool("AsagiBasildimi", asagiBasildimi);
        rb.velocity = hareketVectoru;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dusman") ||
            collision.CompareTag("BuyukAsteroit") ||
            collision.CompareTag("KucukAsteroit"))
        {
            skorAzalt();
            var patlama = Instantiate(patlamaSablon);
            patlama.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            if (skor < 0)
            {
                var patlama2 = Instantiate(patlamaSablon);
                patlama2.transform.position = gameObject.transform.position;
                Destroy(gameObject);                
                Time.timeScale = 0.0f;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
