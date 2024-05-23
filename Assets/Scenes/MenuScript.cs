using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject MenuHolder;
    [SerializeField] GameObject HowToPlayHolder;

    [SerializeField] GameObject fadePanel;
    [SerializeField] GameObject fadePanel2;

    [SerializeField] GameObject justAnormalPanel;

    private void Awake()
    {
        justAnormalPanel.SetActive(true);
        fadePanel.SetActive(false);
        fadePanel2.SetActive(false);
    }

    void Start()
    {
        BackButton();
        StartCoroutine(StartWait());
    }

    public void BackButton()
    {
        MenuHolder.SetActive(true);
        HowToPlayHolder.SetActive(false);
    }

    public void HowToPlayButton()
    {
        MenuHolder.SetActive(false);
        HowToPlayHolder.SetActive(true);
    }

    public void Play()
    {
        StartCoroutine(startGame());
    }

    public void Quit()
    {
        StartCoroutine(quitGame());
    }

    IEnumerator startGame()
    {
        fadePanel2.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }

    IEnumerator quitGame()
    {
        fadePanel2.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        Application.Quit();
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(1.5f);
        fadePanel.SetActive(true);
        justAnormalPanel.SetActive(false);
        Destroy(fadePanel, 3);
    }
}
