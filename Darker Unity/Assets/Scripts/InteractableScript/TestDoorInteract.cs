using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDoorInteract : MonoBehaviour
{
    public GameObject Door;
    public bool switched = false;

    public void Interaction()
    {
        if (!switched)
        {
            Door.transform.Translate(-8f, 0f, 0f);
            switched = true;
        }
        else if (switched)
        {
            Door.transform.Translate(8f, 0f, 0f);
            switched = false;
        }
    }
}
