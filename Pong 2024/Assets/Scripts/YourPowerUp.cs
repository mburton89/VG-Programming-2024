using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPowerUp : Powerup
{
    public override void GetCollected()
    {
         float colorChangeSpeed = 9.0f;
        SpriteRenderer spriteRenderer;
        Color targetColor;

        spriteRenderer = GetComponent<SpriteRenderer>();
        targetColor = GetRandomColor();

        spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, colorChangeSpeed * Time.deltaTime);

        if(Vector4.Distance(spriteRenderer.color, targetColor) < 0.1f)
        {
            targetColor = GetRandomColor();
        }


    }

   public Color GetRandomColor()
    {
        return new Color(Random.value,Random.value, Random.value);
    }
}
