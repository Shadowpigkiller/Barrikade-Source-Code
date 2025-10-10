using UnityEngine;
using UnityEngine.UI;
using System;
public class NABObjectController : MonoBehaviour
{
    [SerializeField] public Text NAB_AmountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void UpdatePlayerNAB()
    {
        NAB_Player_Controller.AddNAB();
        NAB_AmountText.text = Convert.ToString(NAB_Player_Controller.getNAB_Amount());
    }
}
