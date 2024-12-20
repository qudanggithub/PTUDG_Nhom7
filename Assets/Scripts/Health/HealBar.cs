using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealBar : MonoBehaviour
{
    public Image RedBar;
    public TextMeshProUGUI TextValue;

    public void UpdateBar(int CurentValue, int MaxValue)
    {
        RedBar.fillAmount = (float)CurentValue / (float)MaxValue;
        TextValue.text = CurentValue.ToString() + " / " + MaxValue.ToString();
    }

}
