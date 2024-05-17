using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject MenuHolder;
    [SerializeField] GameObject AboutHolder;
    [SerializeField] GameObject HowToPlayHolder;
    void Start()
    {
        BackButton();
    }

    public void BackButton()
    {
        MenuHolder.SetActive(true);
        AboutHolder.SetActive(false);
        HowToPlayHolder.SetActive(false);
    }

    public void AboutButton()
    {
        MenuHolder.SetActive(false);
        AboutHolder.SetActive(true);
        HowToPlayHolder.SetActive(false);
    }

    public void HowToPlayButton()
    {
        MenuHolder.SetActive(false);
        AboutHolder.SetActive(false);
        HowToPlayHolder.SetActive(true);
    }

    public void Play()
    {

    }

    public void Quit()
    {

    }
}
