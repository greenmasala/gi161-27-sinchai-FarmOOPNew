using UnityEngine;

public class Cow : Animal
{
    private float milk;
    public float Milk
    {
        get => milk;
        private set => milk = (value <= 0) ? 0 : value;
    }

    public void Init(string newName) 
    {
        base.Init(newName);
        PreferredFood = FoodType.Hay;
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

    public override string Produce()
    {
        if (Happiness > 70)
        {
            int amount = Happiness / 10;
            Milk += amount;
            Debug.Log($"{Name} produced {amount} of milk!");
        }
        return $"Total milk: {Milk}"; 
    }

    public override void GetStatus()
    {
        base.GetStatus();
        Debug.Log($" Milk: {Milk}");
    }
}
