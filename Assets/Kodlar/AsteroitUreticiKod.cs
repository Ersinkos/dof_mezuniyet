using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroitUreticiKod : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buyukAsteroitSablon;
    float asteroitUretmeSuresi = 5.0f;
    float gecenSure = 0.0f;
    float uretmeX;
    float uretmeY;
    void Start()
    {
        uretmeX = GameObject.Find("AsteroitUretmeNoktasi").transform.position.x;
        uretmeY = GameObject.Find("AsteroitUretmeNoktasi").transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gecenSure >= asteroitUretmeSuresi)
        {
            var asteroit = Instantiate(buyukAsteroitSablon);
            asteroit.transform.position = new Vector3(uretmeX, uretmeY, 0.0f);
            gecenSure = 0.0f;
        }
        gecenSure += Time.deltaTime;
    }
}
