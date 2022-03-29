using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soapScript : MonoBehaviour
{
    public float fadeouttime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOutMaterial(fadeouttime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FadeOutMaterial(float fadeSpeed)
    {
        Renderer rend = gameObject.transform.GetComponent<Renderer>();
        Color matColor = rend.material.color;
        float alphaValue = rend.material.color.a;

        while (rend.material.color.a > 0f)
        {
            alphaValue -= Time.deltaTime / fadeSpeed;
            rend.material.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }
        rend.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
        Destroy(gameObject);
    }
}
