using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonflyRandomizer : MonoBehaviour
{
    public Animator dragonflyAnimator;
    int currentAnim;
    public AudioSource dragonfly;

    void Start()
    {
        dragonflyAnimator = GetComponent<Animator>();
        AudioSource dragonfly = GetComponent<AudioSource>();
        RandomAnim();
    }

    void RandomAnim()
    {
        currentAnim = Random.Range(1, 4);
        if (currentAnim == 1)
        {
            StartCoroutine(Anim1());
        }
        if (currentAnim == 2)
        {
            StartCoroutine(Anim2());
        }
        if (currentAnim == 3)
        {
            StartCoroutine(Anim3());
        }
    }

    IEnumerator Anim1()
    {
        dragonfly.Play(0);
        dragonflyAnimator.SetTrigger("Anim1");
        yield return new WaitForSeconds(3);
        dragonfly.Pause();
        yield return new WaitForSeconds(20);
        RandomAnim();
    }
    IEnumerator Anim2()
    {
        dragonfly.Play(0);
        dragonflyAnimator.SetTrigger("Anim2");
        yield return new WaitForSeconds(3);
        dragonfly.Pause();
        yield return new WaitForSeconds(20);
        RandomAnim();
    }
    IEnumerator Anim3()
    {
        dragonfly.Play(0);
        dragonflyAnimator.SetTrigger("Anim3");
        yield return new WaitForSeconds(3);
        dragonfly.Pause();
        yield return new WaitForSeconds(20);
        RandomAnim();
    }
}
