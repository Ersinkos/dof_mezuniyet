using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuyukAsteroitKod : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    float hizCarpani;
    int can;
    public GameObject canYazisi;
    TextMeshPro canYazisiTxt;
    public GameObject kucukAsteroitSablon;
    void Start()
    {
        can = 4;
        hizCarpani = 0.3f;
        rb = GetComponent<Rigidbody2D>();
        int yon = Random.Range(0, 2);
        float y = 2.0f;
        float x = -1.0f;
        if (yon == 1)//asagi
        {
            y = -y;
        }
        canYazisiTxt = canYazisi.GetComponent<TextMeshPro>();
        canYazisiTxt.text = can.ToString();
        rb.velocity = new Vector3(x, y, 0.0f) * hizCarpani;
    }
    public bool vuruldu()
    {
        can--;
        if (can == 0)
        {
            var kYukari = Instantiate(kucukAsteroitSablon);
            var kAsagi = Instantiate(kucukAsteroitSablon);
            var konum = transform.position;
            kYukari.transform.position = konum + new Vector3(0.0f, 0.1f, 0.0f);
            kAsagi.transform.position = konum + new Vector3(0.0f, -0.1f, 0.0f);
            kYukari.GetComponent<KucukAsteroitKod>().yonAta(1.0f);
            kAsagi.GetComponent<KucukAsteroitKod>().yonAta(-1.0f);

            Destroy(gameObject);
            return true;
        }
        canYazisiTxt.text = can.ToString();
        return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "UstSinir" || collision.name == "AltSinir")
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
        transform.Rotate(0.0f, 0.0f, 0.5f);
    }
}
