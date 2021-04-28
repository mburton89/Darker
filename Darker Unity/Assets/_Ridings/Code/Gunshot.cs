using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : MonoBehaviour
{
    public GameObject gunFireSound;
    private float duration;
    private float pitch;

    private void Awake()
    {
        duration = gunFireSound.GetComponent<AudioSource>().clip.length;
        pitch = Random.Range(0.85f, 1.15f);
        gunFireSound.GetComponent<AudioSource>().pitch = pitch;
        StartCoroutine("FireSound");


    }

    IEnumerator FireSound()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gunFireSound);
    }
}
