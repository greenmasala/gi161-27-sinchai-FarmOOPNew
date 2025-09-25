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

    public void Init(string newName, FoodType preferredFood) 
    {
        base.Init(newName, preferredFood);
        Eggs = 0;
    }

    public override void MakeSound()
    {
        Debug.Log($"{Name} said B'kawk!");
    }

    public void Sleep()
    {
        Debug.Log($"{Name} slept. Hunger increased by 2 and Happiness increased by 5!");
        base.AdjustHunger(-2);
        base.AdjustHappiness(5);
    }
    public override void Produce()
    {
        Eggs += 2;
        Debug.Log($"{Name} produced 2 eggs!");
    }

    public override void GetStatus()
    {
        base.GetStatus();
        Debug.Log($" Eggs: {Eggs}");
    }
}
