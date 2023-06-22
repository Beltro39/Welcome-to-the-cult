using Get;
using Lean.Gui;
using System.Collections.Generic;
using UnityEngine;

public class ManagerExchange : MonoBehaviour
{
    private UserExchange leftUserExchange;
    private UserExchange rightUserExchange;
    private GameController gameController;


    public void VerifiedExchange()
    {
        if (leftUserExchange.GetIsAcceptExchange() && rightUserExchange.GetIsAcceptExchange())
        {
            Dictionary<string, int> leftResource = leftUserExchange.TransferResourceExchenge();
            Dictionary<string, int> rightResource = rightUserExchange.TransferResourceExchenge();
            leftUserExchange.SetResourceExchange(rightResource);
            rightUserExchange.SetResourceExchange(leftResource);
        }
    }
}
