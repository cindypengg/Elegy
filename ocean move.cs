using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float amplitude = 0.5f; // How far it moves left and right
    public float frequency = 1f;   // Speed of the horizontal movement
    public float xAmplitude = 0.5f; // How high it moves up and down
    public float xFrequency = 1f;   // Speed of vertical movement

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float xOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        float yOffset = Mathf.Sin(Time.time * xFrequency) * xAmplitude;
        transform.position = startPos + new Vector3(yOffset, xOffset, 0);
    }
}
