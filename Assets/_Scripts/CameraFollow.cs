using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private const float minDistance = .05f;
    [SerializeField] private Transform target;
    private Vector3 difference;
    [SerializeField] private float speed = 1f;
    public static CameraFollow Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
        difference = target.position - transform.position;
        if (Vector3.SqrMagnitude(difference) > minDistance * minDistance) {
            transform.Translate(difference * Time.deltaTime * speed);
        }
    }
}