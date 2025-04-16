using UnityEngine;

public class Control : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] float rotationSpeed = 1;
    [SerializeField] float boostSpeed = 50f;
    [SerializeField] float baseSpeed = 20f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }
    private void Update()
    {
        if (canMove) {
            PlayerControl();
            RespondToBoost();
        }
        
    }

    public void DisableControl()
    {
        canMove = false;

    }

    private void PlayerControl()
    {
        if (Input.GetKey(KeyCode.A)) {
            rb2d.AddTorque(rotationSpeed);
        } else if (Input.GetKey(KeyCode.D)) {
            rb2d.AddTorque(-rotationSpeed);
        }
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.W)) {
            surfaceEffector2D.speed = boostSpeed;
        } else {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}
