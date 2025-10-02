using UnityEngine;
using UnityEngine.UI;
using System;

public static class NAB_Player_Controller
{
    [Header("Main Nails And Boards Parameters")]
    [SerializeField] private static int NAB_Amount = 0;
    [SerializeField] private static int maxNAB_Amount = 10;
    [SerializeField] public static Text NAB_AmountText;
    public static void AddNAB()
    {
        if (NAB_Amount < maxNAB_Amount)
        {
            NAB_Amount++;
            updateNABUI();
        }
    }

    public static int getNAB_Amount()
    {
        return NAB_Amount;
    }

    public static void updateNABUI()
    {
        NAB_AmountText.text = Convert.ToString(NAB_Amount);
    }

    public static void removeNAB(int NAB_Required) {
        if (NAB_Amount > NAB_Required)
        {
            NAB_Amount -= NAB_Required;
        }
    }
}
