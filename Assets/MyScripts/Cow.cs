using UnityEngine;

public class Cow : Animal
{
    private float milk;
    public float Milk
    {
        get => milk;
        private set => milk = (value <= 0) ? 0 : value;
    }

    public override void Init(string newName, int newHunger, int newHappy) 
    {
        base.Init(newName, newHunger, newHappy);
        Milk = 0;
    }

    public override void MakeSound(string dialogue)
    {
        Debug.Log("Mooo!");
    }

    public void Moo()
    {
        Debug.Log($"{Name} mooed very loudly! Looks like someone's in a good mood. Happiness increased by 10!");
        base.AdjustHappiness(10);
    }

    public override void GetStatus()
    {
        base.GetStatus();
        Debug.Log($" Milk: {Milk}");
    }
}
