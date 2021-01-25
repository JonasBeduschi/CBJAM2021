using UnityEngine;

public class Eye : MonoBehaviour
{
    private Transform target;
    private const int frameUpdateInterval = 10;
    private int count;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
        if (target == null) {
            Debug.LogError("Did not find Player");
            Destroy(this);
            return;
        }
        count = Random.Range(0, frameUpdateInterval);
    }

    private void Update()
    {
        count++;
        if (count >= frameUpdateInterval) {
            count = 0;
            transform.LookAt(target);
        }
    }
}