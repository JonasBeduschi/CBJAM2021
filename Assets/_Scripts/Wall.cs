using UnityEngine;

public class Wall : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (player.position.x > transform.position.x + 6 || player.position.x < transform.position.x)
            transform.Translate(player.position.x - transform.position.x - 6, 0, 0);

    }
}