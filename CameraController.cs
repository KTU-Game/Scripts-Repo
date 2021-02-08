using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float Sensitivity = 2.2f;

    [SerializeField]
    private Transform PlayerBody;

    private float _xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float delta = Sensitivity * Time.deltaTime * 100f;
        float mouseX = Input.GetAxis("Mouse X") * delta;
        float mouseY = Input.GetAxis("Mouse Y") * delta;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
