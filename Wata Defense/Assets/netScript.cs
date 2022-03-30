using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netScript : MonoBehaviour
{
    public float fadeouttime;

    public int hitstaken = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOutMaterial(fadeouttime));
    }

    // Update is called
    
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
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
