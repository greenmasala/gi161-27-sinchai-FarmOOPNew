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
    public void Init(string newName, FoodType preferredFood) 
    {
        base.Init(newName, preferredFood);
        Dirt = 0;
    }

    public override void MakeSound()
    {
        Debug.Log($"{Name} said Snorts!");
    }

    public override void Produce()
    {
        Dirt += 2;
        Debug.Log($"{Name} produced 2 dirt!");
    }

    public override void GetStatus()
    {
        base.GetStatus();
    }
}
