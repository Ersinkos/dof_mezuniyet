using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanUreticiKod : MonoBehaviour
{
    // Start is called before the first frame update
    float uretmeMaxY;
    float uretmeMinY;
    float uretmeX;
    public GameObject dusmanSablonu;
    float dusmanUretmeAraligi = 2.0f;
    float gecenSure = 0.0f;
    void Start()
    {
        uretmeMaxY = GameObject.Find("DusmanUretmeNoktasiMax").transform.position.y;
        uretmeMinY = GameObject.Find("DusmanUretmeNoktasiMin").transform.position.y;
        uretmeX = GameObject.Find("DusmanUretmeNoktasiMax").transform.position.x;
    }
    private void FixedUpdate()
    {
        if (gecenSure >= dusmanUretmeAraligi)
        {
            var dusman = Instantiate(dusmanSablonu);
            
            float uretmeY = Random.Range(uretmeMinY, uretmeMaxY);

            dusman.transform.position = new Vector3(uretmeX, uretmeY, 0.0f);

            gecenSure = 0.0f;
        }
        gecenSure += Time.fixedDeltaTime;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
