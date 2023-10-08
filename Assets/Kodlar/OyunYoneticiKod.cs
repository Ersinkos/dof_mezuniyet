using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunYoneticiKod : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject oyuncu;
    public GameObject menu;
    public GameObject devamButonu;
    RectTransform menuTransform;
    static float eskiZamanOlcegi;
    static bool yeniBasladi = true;
    void Start()
    {
        oyuncu.SetActive(false);
        devamButonu.SetActive(false);

        menuTransform = menu.GetComponent<RectTransform>();
        menuTransform.sizeDelta = new Vector2(700, 460);

        if (!yeniBasladi)
        {
            menuKapat();
            Time.timeScale = eskiZamanOlcegi;
        }
        else
        {
            eskiZamanOlcegi = Time.timeScale;
        }
    }
    public void menuKapat()
    {
        oyuncu.SetActive(true);
        menu.SetActive(false);
        devamButonu.SetActive(true);

        menuTransform.sizeDelta = new Vector2(700, 680);
    }
    public void YeniOyunTiklandi()
    {
        if (yeniBasladi)
        {
            menuKapat();
            yeniBasladi = false;
        }
        else
        {
            StartCoroutine(sahneYukleAsync());
        }


    }
    public void DevamTiklandi()
    {
        menuKapat();
        Time.timeScale = eskiZamanOlcegi;
    }
    public void CikisTiklandi()
    {
        Application.Quit();
    }
    private IEnumerator sahneYukleAsync()
    {
        var yukleme = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        while (!yukleme.isDone)
        {
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var aktifmi = !menu.activeSelf;
            Time.timeScale = 0;
            if (aktifmi == false)
            {
                Time.timeScale = eskiZamanOlcegi;
            }
            menu.SetActive(aktifmi);

        }
    }
}
