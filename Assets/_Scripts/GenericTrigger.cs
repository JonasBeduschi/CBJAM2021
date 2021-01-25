using UnityEngine;
using UnityEngine.Events;

[SelectionBase]
public class GenericTrigger : MonoBehaviour
{
    [SerializeField] private bool destroyOnLeave = true;
    [SerializeField] private UnityEvent OnPlayerEnter;
    [SerializeField] private UnityEvent OnPlayerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            OnPlayerEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) {
            OnPlayerExit?.Invoke();
            if (destroyOnLeave)
                Destroy(GetComponent<Collider>());
        }
    }
}