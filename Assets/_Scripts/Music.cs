using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource[] sources;
    [SerializeField] private AudioMixerSnapshot[] snaps;


    public void ChangeToCreepy()
    {
        sources[1].PlayDelayed(.5f);
        StartCoroutine(StopDelayed(sources[0], 1f));
        snaps[0].TransitionTo(2f);
    }

    IEnumerator StopDelayed(AudioSource source, float delay)
    {
        yield return new WaitForSeconds(delay);
        source.Stop();
    }
}
