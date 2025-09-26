using Unity.VisualScripting;
using UnityEngine;

public class Pig : Animal
{
    private float dirt;
    public float Dirt
    {
        get => dirt;
        private set => dirt = (value <= 0) ? 0 : value;
    }
    public void Init(string newName) 
    {
        base.Init(newName, FoodType.Slop);
        Dirt = 0;
    }

    public override void MakeSound()
    {
        Debug.Log($"{Name} said Snorts!");
    }

    public override string Produce()
    {
        string defaultText = $"{Name} produced nothing due to not being happy enough.";
        if (Happiness >= 50)
        {
            int amount = Happiness*1/2;
            Dirt += amount;
            Debug.Log($"{Name} produced {amount} dirt!");
        }
        return defaultText;
    }

    public override void GetStatus()
    {
        base.GetStatus();
        Debug.Log($" Dirt: {Dirt}");
    }
}
