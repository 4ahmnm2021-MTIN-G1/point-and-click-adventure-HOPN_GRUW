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
    public InteractableObject activeObject;


    public void InvestigateObject()
    {
        speakText.text = hoverObject.investigateText;
        commandMenu.gameObject.SetActive(false);
        Invoke("ResetSpeakText", 3f);
    }

    public void UseObject()
    {
        speakText.text = activeObject.useText;
        commandMenu.gameObject.SetActive(false);
        Invoke("ResetSpeakText", 3f);
        activeObject.useEvent.Invoke();
    }

    public void ResetSpeakText()
    {
        speakText.text = "";
    }

}
