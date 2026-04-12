using UnityEngine;
using TMPro;

public class DistanceDotUI : MonoBehaviour
{

    public Transform player;
    public Camera camera;
    public Transform exit;

    public RectTransform compassArrow;
    public TextMeshProUGUI distanceText;

    public float rotationSpeed = 10f;
    public float exitDistance = 1.5f;

    public float arrowAngle = 0f;

    // Update is called once per frame
    void Update()
    {
        if (player == null || exit == null || camera ==null || compassArrow == null) 
            return;

        Vector3 distanceVector = exit.position - player.position;
        float distance = distanceVector.magnitude;

        if (distance < 0.001f) 
            return;
        
        Vector3 direction = distanceVector.normalized;

        Vector3 cameraRight = camera.transform.right;
        Vector3 cameraUp = camera.transform.up;

        float x = Vector3.Dot(direction, cameraRight);
        float y = Vector3.Dot(direction, cameraUp);

        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        float targetAngle = angle - 90f + arrowAngle;
        float currentAngle = compassArrow.localEulerAngles.z;
        float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
        compassArrow.localEulerAngles = new Vector3(0f, 0f, newAngle);

        if (distanceText != null)
        {
            if (distance <= exitDistance)
                distanceText.text = "Exit Reached";
            else 
                distanceText.text = $"Exit: {distance:F1} m";
        }
    }
}
