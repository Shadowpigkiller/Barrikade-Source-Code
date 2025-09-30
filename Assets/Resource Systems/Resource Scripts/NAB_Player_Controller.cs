using UnityEngine;
using UnityEngine.UI;
using System;

public class NAB_Player_Controller : MonoBehaviour
{
    [Header("Main Nails And Boards Parameters")]
    [SerializeField] private int NAB_Amount = 0;
    [SerializeField] private int maxNAB_Amount = 10;
    [SerializeField] public Text NAB_AmountText;
    public void AddNAB()
    {
        if (NAB_Amount < maxNAB_Amount)
        {
            NAB_Amount++;
            updateNABUI();
        }
    }

    public int getNAB_Amount()
    {
        return NAB_Amount;
    }

    public void updateNABUI()
    {
        NAB_AmountText.text = Convert.ToString(NAB_Amount);
    }
}
