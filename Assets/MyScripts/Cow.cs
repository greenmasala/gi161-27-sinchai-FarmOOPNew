using UnityEngine;

public class Cow : Animal
{
    private float milk;
    public float Milk
    {
        get => milk;
        private set => milk = (value <= 0) ? 0 : value;
    }

    public void Init(string newName, FoodType preferredFood) 
    {
        base.Init(newName, preferredFood);
        Milk = 0;
    }

    public override void MakeSound()
    {
        Debug.Log($"{Name} said Mooo!");
    }

    public void Moo()
    {
        Debug.Log($"{Name} mooed very loudly! Looks like someone's in a good mood. Happiness increased by 10!");
        base.AdjustHappiness(10);
    }

    public override void Produce()
    {
        Milk += 2;
        Debug.Log($"{Name} produced 2 milk!");
    }

    public override void GetStatus()
    {
        base.GetStatus();
        Debug.Log($" Milk: {Milk}");
    }
}
