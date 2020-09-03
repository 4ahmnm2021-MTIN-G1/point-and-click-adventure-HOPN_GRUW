using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public Vector3 target;
    public Collider moveColider;
    public NavMeshAgent agent;

    [Header("Scale Managment")]
    public float characterMinSize;
    public float characterMaxSize;
    public float x;
    public float scaleModifier;
    public float screenAmount = 0.7f;

    void Update()
    {
        // Die Pixelwerte der Maus werden in die Weltposition umgerechnet
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Wir ziehen aus der 3D Position die für uns relevanten 2D Werte der X und Y Achse
        Vector2 mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);

        // Wenn unsere linke Maustaste gedrückt wird
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            // Wir machen den Raycast in die Szene an der Stelle wo unsere Maus sich befindet
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                //target = hit.point;
                agent.SetDestination(hit.point);

                if (hit.collider == moveColider)
                {
                    // Wir setzen die ZielPosition unseres Characters an die getroffene Stelle
                    
                }
            }
            



        }

        /*
        if (target.x != 0 && target.y != 0)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target, step); // Wir bewegen unseren Character an die gewünschte Stelle 
        }
        */

        // Die Skalierung des Characters anhand der Position
        x = Mathf.InverseLerp((Screen.height * screenAmount), 0f, Camera.main.WorldToScreenPoint(transform.position).y);
        scaleModifier = Mathf.Lerp(characterMinSize, characterMaxSize, x);
        this.transform.localScale = new Vector3(scaleModifier, scaleModifier);

    }
}
