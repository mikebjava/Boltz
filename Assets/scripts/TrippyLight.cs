using UnityEngine;
using System.Collections;

public class TrippyLight : MonoBehaviour
{

    #region Editor Variables
    public float LerpSpeed = 0.01f;
    #endregion

    private Light light;
    private float targetR;
    private float targetG;
    private float targetB;
    private float targetA;

    void Start()
    {
        light = GetComponent<Light>();
        targetR = Random.Range(0, 1.0f);
        targetG = Random.Range(0, 1.0f);
        targetB = Random.Range(0, 1.0f);
        targetA = Random.Range(0, 1.0f);
    }

    void Update()
    {
        if (light.color.r == targetR)
        {
            targetR = Random.Range(0, 1.0f);
        }
        if (light.color.g == targetG)
        {
            targetG = Random.Range(0, 1.0f);
        }
        if (light.color.b == targetB)
        {
            targetB = Random.Range(0, 1.0f);
        }
        if (light.color.a == targetA)
        {
            targetA = Random.Range(0, 1.0f);
        }

        SetLightColor(Mathf.MoveTowards(light.color.r, targetR, LerpSpeed * Time.time), Mathf.MoveTowards(light.color.g, targetG, LerpSpeed * Time.time), Mathf.MoveTowards(light.color.b, targetB, LerpSpeed * Time.time), 1.0f);
    }

    private void SetLightColor(float r, float g, float b, float a)
    {
        Color color = new Color(r, g, b, a);
        light.color = color;
    }
}
