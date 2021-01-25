using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Star : MonoBehaviour
{
    private float speed = 20;
    [SerializeField] bool collectable = true;
    [SerializeField] int score = 1;
    [SerializeField] int timesToCollect = 1;

    AudioSource source;
    Animator anim;
    Transform childTransform;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        childTransform = transform.GetChild(0);
    }

    void Update()
    {
        childTransform.Rotate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && collectable) {
            timesToCollect -= 1;
            source.pitch = Random.Range(.9f, 1.1f);
            source.Play();
            Score.AddScore(score);
            if (timesToCollect <= 0) {
                GetComponent<Collider>().enabled = false;
                speed *= 2;
                anim.SetTrigger("Play");
                Destroy(gameObject, 2f);
            }
        }
    }
}
