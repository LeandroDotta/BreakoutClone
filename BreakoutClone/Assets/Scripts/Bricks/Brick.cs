using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour 
{
    protected virtual void DestroyBrick()
    {
        Destroy(gameObject);
    }
}
