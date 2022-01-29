using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : BaseSingletonBehaviour<UIController>
{
    public DialogueController dialogue;
    public GoldDisplay goldDisplay;
    public InventoryScreen inventory;
    public BattleScreen battle;

    public void OpenInventoryScreen()
    {
        inventory.OpenInventoryScreen();
    }

    public void CloseInventoryScreen()
    {
        inventory.CloseInventoryScreen();
    }

    public void OpenBattleScreen(bool isTrainerBattle)
    {
        battle.OpenBattleScreen(isTrainerBattle);
    }

    public void CloseBattleScreen()
    {
        battle.CloseBattleScreen();
    }
}
