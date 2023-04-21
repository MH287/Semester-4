using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs _starterAssetsInputs;

    public void LockMouse()
    {
        _starterAssetsInputs.cursorInputForLook = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void FreeMouse()
    {
        _starterAssetsInputs.cursorInputForLook = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
