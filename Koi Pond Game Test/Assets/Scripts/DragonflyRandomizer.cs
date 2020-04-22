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
        currentAnim = Random.Range(1, 4);
        RandomAnim();
    }

    void RandomAnim()
    {
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
        Debug.Log("Anim1");
        dragonfly.Play(0);
        dragonflyAnimator.SetTrigger("Anim1");
        yield return new WaitForSeconds(15);
        dragonflyAnimator.ResetTrigger("Anim1");
        dragonfly.Pause();
        yield return new WaitForSeconds(20);
        while (currentAnim == 1)
        {
            currentAnim = Random.Range(1, 4);
        }
        RandomAnim();
    }
    IEnumerator Anim2()
    {
        Debug.Log("Anim2");
        dragonfly.Play(0);
        dragonflyAnimator.SetTrigger("Anim2");
        yield return new WaitForSeconds(15);
        dragonflyAnimator.ResetTrigger("Anim2");
        dragonfly.Pause();
        yield return new WaitForSeconds(20);
        while (currentAnim == 2)
        {
            currentAnim = Random.Range(1, 4);
        }
        RandomAnim();
    }
    IEnumerator Anim3()
    {
        Debug.Log("Anim3");
        dragonfly.Play(0);
        dragonflyAnimator.SetTrigger("Anim3");
        yield return new WaitForSeconds(15);
        dragonflyAnimator.ResetTrigger("Anim3");
        dragonfly.Pause();
        yield return new WaitForSeconds(20);
        while (currentAnim == 3)
        {
            currentAnim = Random.Range(1, 4);
        }
        RandomAnim();
    }
}
