using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public static bool uiOpen;

    [SerializeField] private float interactRange = 3f;
    private Terminal current;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        CheckInteractable();

        if (uiOpen) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

    }

    void CheckInteractable()
    {
        Terminal target = null;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactRange))
        {
            target = hit.collider.GetComponentInParent<Terminal>();
        }

        if (target != current)
        {
            if (current != null) current.SetInRange(false);
            current = target;
            if (current != null) current.SetInRange(true);
        }
    }
}