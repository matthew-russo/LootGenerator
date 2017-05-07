using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour
{
    public RectTransform rectTransform;
    public bool timeToFadeOut;
    public bool timeToFadeIn;

    void Start ()
	{
	    rectTransform = GetComponent<RectTransform>();
	    rectTransform.localScale = Vector3.zero;
	}

    public IEnumerator PopUpFadeIn()
    {
        while (rectTransform.localScale.x < .98f)
        {
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, Vector3.one, .2f);
            if (timeToFadeOut)
            {
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
        rectTransform.localScale = Vector3.one;
    }

    public IEnumerator PopUpFadeOut()
    {
        while (rectTransform.localScale.x > .02f)
        {
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, Vector3.zero, .2f);
            if (timeToFadeIn)
            {
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
        rectTransform.localScale = Vector3.zero;
    }
}
