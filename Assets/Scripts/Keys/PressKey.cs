using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKey : MonoBehaviour
{
    public Sprite newSprite; // The sprite to change to
    public KeyCode ChangeKey; // The key to change the sprite

    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite; // The original sprite

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite; // Get the original sprite
    }

    void Update()
    {
        if (Input.GetKeyDown(ChangeKey))
        {
            spriteRenderer.sprite = newSprite; // Change the sprite to new sprite
        }

        if (Input.GetKeyUp(ChangeKey))
        {
            spriteRenderer.sprite = originalSprite; // Change the sprite back to original sprite
        }
    }
}