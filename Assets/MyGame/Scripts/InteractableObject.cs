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
    }

    void OnMouseExit()
    {
        ui.commandLineText.text = "-----------------";
    }

    void OnMouseDown()
    {

    }
}
