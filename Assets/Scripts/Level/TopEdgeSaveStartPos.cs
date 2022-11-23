using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopEdgeSaveStartPos : MonoBehaviour
{

    public Vector3 pos;

    public void ResetPos()
    {
        transform.localPosition = pos;
    }
}
