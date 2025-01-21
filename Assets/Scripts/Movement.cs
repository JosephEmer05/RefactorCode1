using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Horizontal Speed")]
    [SerializeField] private float moveSpeed;
    [Tooltip("Rate of Change for Move Speed")]
    [SerializeField] private float acceleration;
    [Tooltip("Deceleration rate when no input is provided")]
    [SerializeField] private float deceleration;

    private Vector3 inputVector;
    private float currentSpeed;
    private CharacterController characterController;
    private float initialYPosition;
    private Controls controls;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        controls = GetComponent<Controls>();
        initialYPosition = transform.position.y;
    }

    private void Update()
    {
        controls.HandleInput();
        Move(inputVector);
    }

    private void Move(Vector3 inputVector)
    {
        if (inputVector == Vector3.zero)
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= deceleration * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0);
            }
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, Time.deltaTime * acceleration);
        }

        Vector3 movement = inputVector.normalized * currentSpeed * Time.deltaTime;
        characterController.Move(movement);
        transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
    }

    public void SetInputVector(Vector3 input)
    {
        inputVector = input;
    }
}
