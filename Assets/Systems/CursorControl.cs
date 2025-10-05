using UnityEngine;

public class CursorControl
{
    public static void CursorActivate()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public static void CursorDeactivate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
