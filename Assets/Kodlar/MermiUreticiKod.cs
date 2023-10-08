using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiUreticiKod : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform uzayMekigiTransform;
    public GameObject mermiSablon;
    public float mermiAtilmaSuresi = 0.2f;
    public float oncekiMermiSuresi = 0.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (oncekiMermiSuresi >= mermiAtilmaSuresi)
            {
                var yeniMermi = Instantiate(mermiSablon);
                yeniMermi.transform.position = uzayMekigiTransform.position;

                oncekiMermiSuresi = 0.0f;
            }
            oncekiMermiSuresi += Time.deltaTime;
        }
    }
}
