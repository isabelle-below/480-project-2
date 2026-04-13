using UnityEngine;

public class FogColor : MonoBehaviour
{
    public Material fogPlane;
    private Color startColor = new Color(136f/255f, 178f/255f, 202f/255f);
    private Color endColor = new Color(60f/255f, 78f/255f, 89f/255f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fogPlane.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time*0.1f, 1));
    } 
}
