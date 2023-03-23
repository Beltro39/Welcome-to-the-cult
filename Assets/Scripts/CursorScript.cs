using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Texture2D cursorArrowRed;
    public Texture2D cursorArrowWhite;
    // Start is called before the first frame update

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorArrowRed, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseExit(){
        Cursor.SetCursor(cursorArrowWhite, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Start(){
        Cursor.SetCursor(cursorArrowWhite, Vector2.zero, CursorMode.ForceSoftware);
    }

}
