using UnityEngine;

public class LightBlink : MonoBehaviour
{
    public Light lights;
    public float blink = 0.5f;//thoi gian nhap nhay
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("BlinkLight", 0, blink);
    }
    void BlinkLight()
    {
        lights.enabled = !lights.enabled;
    }
}
