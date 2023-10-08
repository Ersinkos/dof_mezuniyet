using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanKod : MonoBehaviour
{
    Rigidbody2D rb;
    public float hizCarpani;
    // Start is called before the first frame update
    void Start()
    {
        hizCarpani = 1.0f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-hizCarpani, 0.0f);

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

    }
}
