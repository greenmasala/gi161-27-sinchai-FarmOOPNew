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

    public void Init(string newName) 
    {
        base.Init(newName);
        PreferredFood = FoodType.Seeds;
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
    /*public override string Produce()
    {
        if (Happiness > 70)
        {
            int amount = Happiness / 20;
            Eggs += amount;
            result = $"{Name} produced {amount} of milk!";
            Debug.Log(result);
        }
    }*/

    public override string Produce()
    {
        if (Happiness <= 50)
        {
            Debug.Log($"{Name} produced nothing due to not being happy enough.");
        }
        else if (Happiness >= 51 && Happiness <= 79)
        {
            Eggs += 2;
            Debug.Log($"{Name} is quite happy and laid 2 eggs!");
        }
        else if (Happiness >= 80)
        {
            Eggs += 3;
            Debug.Log($"{Name} is VERY happy and laid 3 eggs!");
        }
        return $"Total eggs: {Eggs}";
    }

    public override void GetStatus()
    {
        base.GetStatus();
        Debug.Log($" Eggs: {Eggs}");
    }
}
