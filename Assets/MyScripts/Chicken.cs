using Unity.VisualScripting;
using UnityEngine;

public class Chicken : Animal
{
    private int eggs;
    public int Eggs
    {
        get => eggs;
        private set => eggs = (value <= 0) ? 0 : value;
    }

    public override void Init(string newName, int newHunger, int newHappy) 
    {
        base.Init(newName, newHunger, newHappy);
        Eggs = 0;
    }

    public override void MakeSound(string dialogue)
    {
        base.MakeSound("B'kawk!");
    }

    public void Sleep()
    {
        Debug.Log($"{Name} slept. Hunger increased by 2 and Happiness increased by 5!");
        base.AdjustHunger(-2);
        base.AdjustHappiness(5);
    }
    
    public override void GetStatus()
    {
        base.GetStatus();
        Debug.Log($" Eggs: {Eggs}");
    }
}
