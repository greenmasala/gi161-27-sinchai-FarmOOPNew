using Unity.VisualScripting;
using UnityEngine;

public class Pig : Animal
{
    public override void Init(string newName, int newHunger, int newHappy) 
    {
        base.Init(newName, newHunger, newHappy);
    }

    public override void MakeSound(string dialogue)
    {
        base.MakeSound("Snorts!");
    }

    public override void GetStatus()
    {
        base.GetStatus();
    }
}
