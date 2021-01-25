using UnityEngine;

public class EndCamera : MonoBehaviour
{
    [SerializeField] private float speedZ;
    [SerializeField] private float speedY;
    [SerializeField] private float end;

    private void LateUpdate()
    {
        transform.Translate(0, speedY * Time.deltaTime, speedZ * Time.deltaTime);
        if (transform.position.z > end)
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}