using System.Collections;
using UnityEngine;

public class Stones : MonoBehaviour
{
    private ParticleSystem particles;
    private MeshRenderer meshRenderer;
    private bool isOn = false;
    private bool crumbled = false;

    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (isOn) {
            if (particles.isStopped) {
                Destroy(gameObject);
            }
        }
    }

    public void Crumble()
    {
        if (crumbled)
            return;
        crumbled = true;
        if (particles != null)
            particles.Play();
        meshRenderer.enabled = false;
        isOn = true;
    }
}