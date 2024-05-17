using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{

    [Header("GameObject")]
    [SerializeField] private GameObject thiss;
    [SerializeField] private GameObject baseThing;

    [Header("\nAnimation")]
    [SerializeField] Animator anim;
    [SerializeField] Animator trailAnim;

    [Header("\nParticleSystem")]
    [SerializeField] private ParticleSystem sparks;
    [SerializeField] private ParticleSystem trails;

    
    void Start()
    {
        anim.SetBool("collected", false);
        baseThing.SetActive(false);
        sparks.Stop();
        trails.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Player":
                StartCoroutine(CollectingAnimation());
                Collider c = thiss.GetComponent<Collider>();
                c.enabled = false;
                break;
        }
    }

    IEnumerator CollectingAnimation()
    {
        FindFirstObjectByType<AudioManager>().Play("Collected");
        sparks.Play();
        trails.Play();
        yield return new WaitForSeconds(3);
        sparks.Stop();
        trailAnim.SetBool("Exploaded", true);
        baseThing.SetActive(true);
        yield return new WaitForSeconds(5.3f);
        trailAnim.SetBool("Endend", true);
        anim.SetBool("collected", true);
        Destroy(thiss, 1);
    }
}
