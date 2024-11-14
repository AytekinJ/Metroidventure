using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    private Vector2 cursorHotSpot;

    void Start()
    {
        cursorHotSpot = new Vector2 (cursorTexture.width, cursorTexture.height);
        Cursor.SetCursor(cursorTexture, cursorHotSpot, CursorMode.Auto);
    }
}
