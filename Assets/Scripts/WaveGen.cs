using UnityEngine;
using System.Collections;

public class WaveGen : MonoBehaviour
{

    private Vector3[] newVertices;
    private Vector3[] oldVerties;
  //  [Range(1.0f, 20.0f)]
    public float scale;
    //[Range(1.0f, 20.0f)]
    public float speed;
    public float noiseStrength = 1.0f;
    public float noiseWalk = 1.0f;
    //[Range(1.0f,20.0f)]
    public float freq;
    private Vector3[] baseHeight;
    public float scaleSliderValue;
    public float speedSliderValue;
    public float freqSliderValue;
    //GUIStyle style;
    void Start()
    {
        //style.normal.textColor = Color.black;
        scaleSliderValue = 1.3f;
        speedSliderValue = 1.0f;
        freqSliderValue = 1.0f;
    }

    void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 5, 100, 30), "Scale: " + scale);
        scaleSliderValue = GUI.HorizontalSlider(new Rect(Screen.width/2,Screen.height/2,100,30), scaleSliderValue, 0.0f,20.0f);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 100, 30), "Speed: " + speed);
        speedSliderValue = GUI.HorizontalSlider(new Rect(Screen.width / 2, Screen.height / 2 + 30, 100, 30), speedSliderValue, 1.0f, 20.0f);
        GUI.Label(new Rect(Screen.width / 2 - 140, Screen.height / 2 + 55, 100, 30), "Frequency: " + freq);
        freqSliderValue = GUI.HorizontalSlider(new Rect(Screen.width / 2, Screen.height / 2 + 60, 100, 30), freqSliderValue, 1.0f, 20.0f);
    }


    void Update()
    {
        scale = scaleSliderValue;
        speed = speedSliderValue;
        freq = freqSliderValue;
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        if (baseHeight == null)
            baseHeight = mesh.vertices;

        Vector3[] vertices = new Vector3[baseHeight.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = baseHeight[i];
            vertex.y += Mathf.Sin((Time.time * speed + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z)*freq) * scale;
            vertex.y += Mathf.PerlinNoise(baseHeight[i].x + noiseWalk, baseHeight[i].y + Mathf.Sin(Time.time * 0.1f)) * noiseStrength;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}