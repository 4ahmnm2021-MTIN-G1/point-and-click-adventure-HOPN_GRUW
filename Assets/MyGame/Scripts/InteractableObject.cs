using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public UIManager ui;
    public string investigateText;


    void OnMouseOver()
    {
        ui.commandLineText.text = this.gameObject.name;
        ui.hoverObject = this;
    }

    void OnMouseExit()
    {
        ui.commandLineText.text = "-----------------";
    }

    void OnMouseDown()
    {
        ui.commandMenu.SetActive(true);
        ui.commandMenu.transform.position = GetMousePos();
    }

    private Vector2 GetMousePos()
    {
        // Die Pixelwerte der Maus werden in die Weltposition umgerechnet
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Wir ziehen aus der 3D Position die für uns relevanten 2D Werte der X und Y Achse
        Vector2 mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

        return mousePosWorld2D;
    }

    
}
