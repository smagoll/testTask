using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WindowManager : MonoBehaviour, ISwitch
{
    public virtual void Disable()
    {
        gameObject.SetActive(false);
    }
    public virtual void Enable()
    {
        gameObject.SetActive(true);
    }

}
