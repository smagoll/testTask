using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : WindowManager
{
    public override void Disable()
    {
        gameObject.SetActive(false);
    }

    public override void Enable()
    {
        gameObject.SetActive(true);
    }
}
