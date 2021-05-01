using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioSource footstepPrefab;
    public AudioClip[] audioClips;
    private AudioClip clipToPlay;
    private float duration;
    private float pitch;
    private float volumeMax;
    private float volumeMin;
    public float stepDelay;
    private float nextFootstep = 0;

    private void Awake()
    {
        volumeMax = 1;
        volumeMin = 0.75f;
    }

    /*
    private void OnEnable()
    {
        clipToPlay = audioClips[Random.Range(0, audioClips.Length)];
        footstepPrefab.clip = clipToPlay;
        duration = footstepPrefab.GetComponent<AudioSource>().clip.length;
        pitch = Random.Range(0.95f, 1.05f);
        footstepPrefab.GetComponent<AudioSource>().pitch = pitch;
        footstepPrefab.GetComponent<AudioSource>().volume = Random.Range(volumeMin, volumeMax);
        StartCoroutine("Step");

    }

    IEnumerator Step()
    {
        footstepPrefab.Play();
        yield return new WaitForSeconds(duration + stepDelay);
        gameObject.SetActive(false);
    }
    */

    private void Update()
    {
       if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
       {
            nextFootstep -= Time.deltaTime;
            if (nextFootstep <= 0)
            {
                clipToPlay = audioClips[Random.Range(0, audioClips.Length)];
                footstepPrefab.clip = clipToPlay;
                duration = footstepPrefab.GetComponent<AudioSource>().clip.length;
                pitch = Random.Range(0.95f, 1.05f);
                footstepPrefab.GetComponent<AudioSource>().pitch = pitch;
                footstepPrefab.GetComponent<AudioSource>().volume = Random.Range(volumeMin, volumeMax);
                footstepPrefab.Play();
                nextFootstep += stepDelay;
            }
       }
    }
}
