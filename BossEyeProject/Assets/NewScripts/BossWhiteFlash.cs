using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWhiteFlash : MonoBehaviour
{
    public SpriteRenderer mySprite;

    void Update()
    {
        if (mySprite.color.a > 0)
        {
            float newAlpha = Mathf.Lerp(mySprite.color.a, 0, 0.01f);
            mySprite.color = new Color(mySprite.color.r, mySprite.color.g, mySprite.color.b, newAlpha);
        }
    }

    public void SetAlpha()
    {
        mySprite.color = new Color (mySprite.color.r, mySprite.color.g, mySprite.color.b, 0.80f);
    }
}
