using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanKod : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 hareketVectoru;
    float hareketCarpani;
    public GameObject klon;
    float mesafe; //arkaplanlarýn merkez noktalarýnýn x pozisyonlarý arasýndaki farký tutuyor.
    void Start()
    {
        hareketCarpani = 1.0f;
        mesafe = klon.transform.position.x - transform.position.x;
    }

    // Update is called once per frame
    void Update() //update içinde arka planlarý hareket ettiriyoruz.
    {
        hareketVectoru.x = -Time.deltaTime * hareketCarpani;
        //bu iki if içerisinde arka planlardan biri sahnenin dýþýna tamamen çýktýðý an
        //pozisyonu diðer arka planýn hemen saðýna olarak güncelleniyor.
        if (transform.position.x <= -mesafe) 
        {
            float x = klon.transform.position.x + mesafe;
            transform.position = new Vector3(x, 0.0f, 0.0f);
        }
        if (klon.transform.position.x <= -mesafe)
        {
            float x = transform.position.x + mesafe;
            klon.transform.position = new Vector3(x, 0.0f, 0.0f);
        }
        transform.position += hareketVectoru;
        klon.transform.position += hareketVectoru;
    }
}
