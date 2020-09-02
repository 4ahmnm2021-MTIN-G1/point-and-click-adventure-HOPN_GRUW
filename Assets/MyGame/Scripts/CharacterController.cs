using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    void Update()
    {
        // Die Pixelwerte der Maus werden in die Weltposition umgerechnet
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Wir ziehen aus der 3D Position die für uns relevanten 2D Werte der X und Y Achse
        Vector2 mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

        this.gameObject.transform.position = mousePosWorld2D;
    }
}
