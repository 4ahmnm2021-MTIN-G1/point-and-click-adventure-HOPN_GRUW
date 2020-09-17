using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UIManager ui;
    public float interactionDistance = 5f;
    public int investigateTextID = 0;
    public string[] investigateText;
    public string useText;
    public UnityEvent useEvent;

    void OnMouseOver()
    {
        ui.commandLineText.text = this.gameObject.name;
        ui.hoverObject = this;
    }

    void OnMouseExit()
    {
        ui.commandLineText.text = "-----------------";
        ui.hoverObject = null;
    }

    void OnMouseDown()
    {
        if (!ui.commandMenu.activeSelf)
        {
            ui.commandMenu.SetActive(true);
            ui.commandMenu.transform.position = GetMousePos();
            Vector3 vec = ui.commandMenu.GetComponent<RectTransform>().localPosition;
            ui.commandMenu.GetComponent<RectTransform>().localPosition = new Vector3(vec.x, vec.y, 0f);
            ui.activeObject = this;
        } 
    }

    private Vector2 GetMousePos()
    {
        // Die Pixelwerte der Maus werden in die Weltposition umgerechnet
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Wir ziehen aus der 3D Position die für uns relevanten 2D Werte der X und Y Achse
        Vector3 mousePosWorld3D = new Vector3(mousePosWorld.x, mousePosWorld.y, mousePosWorld.z);

        return mousePosWorld3D;
    }

    
}
