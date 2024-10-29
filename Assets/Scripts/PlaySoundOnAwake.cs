using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnAwake : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    AudioSource source;

    private void Awake()
    {

        source = GetComponent<AudioSource>();
        source.clip = audioClips[Random.Range(0, audioClips.Length)];
    }
    private void Start()
    {
        source.Play();
    }

}
