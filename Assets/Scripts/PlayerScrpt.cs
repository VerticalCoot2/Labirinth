using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerScrpt : MonoBehaviour
{
    [Header("Collectable assets")]
    [SerializeField] private int collectibles = 0;

    [Header("EndAnim")]
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject canvas;

    [SerializeField] private Animator WinTextAnim1;
    [SerializeField] private Animator WinTextAnim2;
    [SerializeField] private Animator WinTextAnim3;


    [Header("End Gate Assets")]
    [SerializeField] GameObject endGateHolder;
    [SerializeField] GameObject[] gs = new GameObject[4];
    [SerializeField] GameObject[] doorz = new GameObject[4];

    bool enterMenu = false;


    void Awake()
    {
        enterMenu = false;

        canvas.SetActive(false);

        anim.SetBool("finishedGame", false);
        WinTextAnim1.SetBool("fade", false);
        WinTextAnim2.SetBool("fade", false);
        WinTextAnim3.SetBool("fade", false);

        for (int i = 0; i < gs.Length; i++)
        {
            GameObject parent = endGateHolder.transform.GetChild(i).gameObject;
            doorz[i] = parent.transform.GetChild(0).gameObject;
            gs[i] = parent.transform.GetChild(1).gameObject;

            doorz[i].SetActive(true);
            gs[i].SetActive(false);            
        }
    }
    void Update()
    {
        if (collectibles == 8)
        {
            collectibles++;
            int rand = Random.Range(0, 3);
            gs[rand].SetActive(true);
            doorz[rand].SetActive(false);
            AudioSource au = gs[rand].GetComponent<AudioSource>();
            if(au != null)
            {
                au.Play();
            }            
        }
        switch(enterMenu)
        {
            case true:
                if(Input.GetKeyUp(KeyCode.Return))
                {
                    SceneManager.LoadScene(0);
                }
                break;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Collectible":
                collectibles++;
                break;

            case "Finish":
                StartCoroutine(ending());
                break;
        }
    }

    IEnumerator ending()
    {
        canvas.SetActive(true);
        anim.SetBool("finishedGame", true);
        yield return new WaitForSeconds(4);
        
        WinTextAnim1.SetBool("fade", true);
        yield return new WaitForSeconds(2);
        WinTextAnim2.SetBool("fade", true);
        yield return new WaitForSeconds(3);
        WinTextAnim3.SetBool("fade", true);
        enterMenu = true;
    }
}