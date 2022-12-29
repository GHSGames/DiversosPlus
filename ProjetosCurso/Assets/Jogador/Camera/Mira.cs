using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    public Texture2D mira;

    private void OnGUI() {
        GUI.DrawTexture(
            new Rect(
                Screen.width / 2 - mira.width / 2,
                Screen.height / 2 - mira.height / 2,
                mira.width,
                mira.height
            ), mira
        );
    }
}
