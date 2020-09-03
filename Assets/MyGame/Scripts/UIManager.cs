using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CharacterController character;
    public GameObject commandMenu;
    public Text speakText;
    public Text commandLineText;

    public InteractableObject hoverObject;

    public void InvestigateObject()
    {
        speakText.text = hoverObject.investigateText;
        commandMenu.gameObject.SetActive(false);
    }

}
