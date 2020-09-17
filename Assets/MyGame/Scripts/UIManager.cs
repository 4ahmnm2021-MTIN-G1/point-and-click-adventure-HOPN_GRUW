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


    public float distance;

    public void InvestigateObject()
    {
        CancelInvoke();

        distance = DistanceCharacterAndInteractableObject();

        if (distance < activeObject.interactionDistance)
        {
            speakText.text = activeObject.investigateText[activeObject.investigateTextID];
            // Nur die ID hochsetzen wenn die Laenge des Arrays noch nicht erreicht ist
            if ((activeObject.investigateTextID + 1) < activeObject.investigateText.Length)
            {
                activeObject.investigateTextID += 1;
            }

            commandMenu.gameObject.SetActive(false); 
        }
        else
        {
            speakText.text = "Ich bin nicht nah genug dran";
            commandMenu.gameObject.SetActive(false);
        }

        Invoke("ResetSpeakText", 3f);
    }

    public void UseObject()
    {
        CancelInvoke();

        distance = DistanceCharacterAndInteractableObject();

        if (distance < activeObject.interactionDistance)
        {
            speakText.text = activeObject.useText;
            commandMenu.gameObject.SetActive(false);
            activeObject.useEvent.Invoke();
        }
        else
        {
            speakText.text = "Ich bin nicht nah genug dran";
            commandMenu.gameObject.SetActive(false);
        }

        Invoke("ResetSpeakText", 3f);
        
    }

    public void ResetSpeakText()
    {
        speakText.text = "";
    }

    public float DistanceCharacterAndInteractableObject()
    {
        Vector2 playerPos = new Vector2(character.gameObject.transform.position.x, character.gameObject.transform.position.y);
        Vector2 ioPos = new Vector2(activeObject.gameObject.transform.position.x, activeObject.gameObject.transform.position.y);

        return Vector2.Distance(playerPos,ioPos);
    }
}
