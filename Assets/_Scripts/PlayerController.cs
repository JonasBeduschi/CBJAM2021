using UnityEngine;

[SelectionBase]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpForce;
    private Rigidbody rb;
    private bool onAir;
    private bool moving;
    private Ray ray;
    [SerializeField] private LayerMask objectsMask;
    [SerializeField] private Animator bodyAnim;
    [SerializeField] private Animator wingsAnim;
    private Transform body;
    private AudioSource source;
    public bool CanMove = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        body = transform.GetChild(0);
        //CanMove = false;
    }

    private void Update()
    {
        UpdateInputs();
        UpdateAnimator();
    }

    private void UpdateInputs()
    {
        if (Input.GetAxis("Jump") > 0 && !onAir) {
            StillOnAir();
            source.Play();
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetAxis("Horizontal") != 0) {
            if (Input.GetAxis("Horizontal") < 0 && body.rotation.eulerAngles.y != 180)
                body.rotation = Quaternion.Euler(0, 180, 0);
            else if (Input.GetAxis("Horizontal") > 0 && body.rotation.eulerAngles.y != 0)
                body.rotation = Quaternion.Euler(0, 0, 0);
            moving = true;
            if (!CanMove)
                return;
            Vector3 movement = new Vector3(Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0) * movementSpeed;
            transform.Translate(movement, Space.World);
        }
        else {
            moving = false;
        }
    }

    private void UpdateAnimator()
    {
        if (onAir) {
            bodyAnim.SetInteger("State", 2);
        }
        else if (moving) {
            bodyAnim.SetInteger("State", 1);
        }
        else {
            bodyAnim.SetInteger("State", 0);
        }
    }

    private void Land()
    {
        print("Landed");
        onAir = false;
        wingsAnim.SetBool("OnAir", false);
    }

    public void AllowMovement(bool b)
    {
        CanMove = b;
    }

    private void StillOnAir()
    {
        if (onAir)
            return;
        onAir = true;
        wingsAnim.SetBool("OnAir", true);
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y != 0) {
            ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, .75f, objectsMask))
                Land();
            else
                StillOnAir();
        }
    }

    public void TeleportTo(Transform target)
    {
        Vector3 difference = transform.position - CameraFollow.Instance.transform.position;
        CameraFollow.Instance.transform.position = target.position + difference;
        transform.position = target.position;
    }

    public void EndGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}