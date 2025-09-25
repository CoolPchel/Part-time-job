using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAmUi : MonoBehaviour
{
    public void UnBlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
