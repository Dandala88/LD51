using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Image image = GetComponent<Image>();
        Text[] texts = GetComponentsInChildren<Text>();
        while(image.color.a > 0)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime * 0.1f));
            foreach(Text t in texts)
            {
                t.color = new Color(t.color.r, t.color.b, t.color.g, t.color.a - (Time.deltaTime * 0.1f));
            }
            yield return null;
        }
        Destroy(gameObject);
    }
}
