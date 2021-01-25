using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Random = UnityEngine.Random;

[SelectionBase]
[RequireComponent(typeof(AudioSource))]
public class Word : MonoBehaviour
{

    string myWord;

    private Stones[] stones;
    private AudioSource source;
    private const float distanceBetweenCharacters = 1.1f;
    [SerializeField] private UnityEvent OnPlayerEnter;
    [SerializeField] private UnityEvent OnPlayerExit;


    private void Awake()
    {
        stones = GetComponentsInChildren<Stones>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            OnPlayerEnter?.Invoke();
            Crumble();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) {
            OnPlayerExit?.Invoke();
            Destroy(GetComponent<BoxCollider>());
            Destroy(gameObject, 10
                );
        }
    }

    private void Crumble()
    {
        StartCoroutine(Crumbling());
        source.pitch = Random.Range(.9f, 1.1f);
        source.PlayDelayed(1f);
    }

    IEnumerator Crumbling()
    {
        for (int i = 0; i < stones.Length; i++) {
            stones[i].Crumble();
            if (i % 4 == 0)
                yield return new WaitForSeconds(.01f);
        }
    }

    [ContextMenu("Create and Organize")]
    public void Create()
    {
        Alphabet alphabet = GameObject.FindObjectOfType<Alphabet>();
        for (int i = transform.GetChild(0).childCount - 1; i >= 0; i--) {
            DestroyImmediate(transform.GetChild(0).GetChild(i).gameObject);
        }

        myWord = gameObject.name;

        for (int i = 0; i < myWord.Length; i++) {
            Instantiate(alphabet.GetObjectFor(myWord[i]), transform.GetChild(0));
        }

        BoxCollider box = GetComponent<BoxCollider>();
        Vector3 size = box.size;
        size.x = myWord.Length;
        box.size = size;

        Organize();
    }

    [ContextMenu("Organize")]
    public void Organize()
    {
        float startAt = (transform.GetChild(0).childCount - 1) * -.55f;
        for (int i = 0; i < transform.GetChild(0).childCount; i++) {
            transform.GetChild(0).GetChild(i).localPosition = new Vector3(startAt + distanceBetweenCharacters * i, 0, 0);
        }
    }
}