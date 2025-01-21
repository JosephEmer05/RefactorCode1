using UnityEngine;

public class Controls : MonoBehaviour
{
    [Header("Controls")]
    [Tooltip("Use WASD to move")]
    [SerializeField] private KeyCode forwardKey = KeyCode.W;
    [SerializeField] private KeyCode backwardKey = KeyCode.S;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;

    private Movement movement;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    public void HandleInput()
    {
        float xInput = 0;
        float zInput = 0;

        if (Input.GetKey(forwardKey)) zInput++;
        if (Input.GetKey(backwardKey)) zInput--;
        if (Input.GetKey(leftKey)) xInput--;
        if (Input.GetKey(rightKey)) xInput++;

        Vector3 inputVector = new Vector3(xInput, 0, zInput);
        movement.SetInputVector(inputVector);
    }
}
