using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForwardText : MonoBehaviour
{
    public Text fastForwardText;
    private bool isFast = true;
    public void TextChange()
    {
        if (isFast)
        {
            isFast = false;
            fastForwardText.text = "Normal Speed";
        }else if (!isFast)
        {
            isFast = true;
            fastForwardText.text = "Fast Forward";
        }
    }
}
