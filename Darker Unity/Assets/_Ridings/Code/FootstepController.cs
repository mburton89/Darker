using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioSource footstepPrefab;
    private float duration;
    private float pitch;
    private float volumeMax;
    private float volumeMin;
    public float stepDelay;

    private void Awake()
    {
        volumeMax = 1;
        volumeMin = 0.75f;
        duration = footstepPrefab.GetComponent<AudioSource>().clip.length;
        pitch = Random.Range(0.95f, 1.05f);
        footstepPrefab.GetComponent<AudioSource>().pitch = pitch;
        footstepPrefab.GetComponent<AudioSource>().volume = Random.Range(volumeMin, volumeMax);
        StartCoroutine("Step");
    }

    IEnumerator Step()
    {
        yield return new WaitForSeconds(duration + stepDelay);
        Destroy(gameObject);
    }

}
