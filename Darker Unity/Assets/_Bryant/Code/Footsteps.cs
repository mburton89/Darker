using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private AudioSource footstep_Sound;


    [SerializeField]
    private AudioClip[] footstep_Clip;

    private CharacterController character_Controller;

    public float volume_Min, voluime_Max;

    public float accumulated_Distance;

    public float step_Distance;


    void Awake()
    {
        footstep_Sound = GetComponent<AudioSource>();

        character_Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckToPlayFootStepSound();
        if (Input.GetKeyDown(KeyCode.W))
        {
            accumulated_Distance += 1;
        }
    }

    void CheckToPlayFootStepSound()
    {
        if (!character_Controller.isGrounded)
            return;

        if(character_Controller.velocity.sqrMagnitude > 0)
        {
            

            if (accumulated_Distance > step_Distance)
            {
                footstep_Sound.volume = Random.Range(volume_Min, voluime_Max);
                footstep_Sound.clip = footstep_Clip[Random.Range(0, footstep_Clip.Length)];
                footstep_Sound.Play();

                accumulated_Distance = 0f;
            }
        }
    }
}
