using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    private Vector2 target;

    void Update()
    {
        // Die Pixelwerte der Maus werden in die Weltposition umgerechnet
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Wir ziehen aus der 3D Position die für uns relevanten 2D Werte der X und Y Achse
        Vector2 mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

        //this.gameObject.transform.position = mousePosWorld2D;

        // Wir machen den Raycast in die Szene an der Stelle wo unsere Maus sich befindet
        var hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);



        // Wenn unsere linke Maustaste gedrückt wird
        if (Input.GetMouseButtonDown(0))
        {
            // Wir setzen die ZielPosition unseres Characters an die getroffene Stelle
            target = hit.point;
        }

        float step = speed * Time.deltaTime; // calculate distance to move
        // Wir bewegen unseren Character an die gewünschte Stelle
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }
}
