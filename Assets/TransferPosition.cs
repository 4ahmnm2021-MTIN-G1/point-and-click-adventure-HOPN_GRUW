using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferPosition : MonoBehaviour
{
    public Transform trans;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = trans.position;
    }
}
