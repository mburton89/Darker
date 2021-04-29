using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedSound : MonoBehaviour
{
    public GameObject playerDetectedSound;
    private float duration;
    private float pitch;


    private void Awake()
    {
        duration = playerDetectedSound.GetComponent<AudioSource>().clip.length;
        pitch = Random.Range(0.85f, 1.15f);
        playerDetectedSound.GetComponent<AudioSource>().pitch = pitch;
        StartCoroutine("PlayerDetected");
    }

    IEnumerator PlayerDetected()
    {
        yield return new WaitForSeconds(duration);
        Destroy(playerDetectedSound);
    }
}
