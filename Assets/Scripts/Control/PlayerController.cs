using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isHaveKey = false;

    public void TakeKey()
    {
        isHaveKey = true;
    }

    public bool IsHaveKey()
    {
        return isHaveKey;
    }

}


