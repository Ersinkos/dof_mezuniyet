using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanKod : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 hareketVectoru;
    float hareketCarpani;
    public GameObject klon;
    float mesafe; //arkaplanlar�n merkez noktalar�n�n x pozisyonlar� aras�ndaki fark� tutuyor.
    void Start()
    {
        hareketCarpani = 1.0f;
        mesafe = klon.transform.position.x - transform.position.x;
    }

    // Update is called once per frame
    void Update() //update i�inde arka planlar� hareket ettiriyoruz.
    {
        hareketVectoru.x = -Time.deltaTime * hareketCarpani;
        //bu iki if i�erisinde arka planlardan biri sahnenin d���na tamamen ��kt��� an
        //pozisyonu di�er arka plan�n hemen sa��na olarak g�ncelleniyor.
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
