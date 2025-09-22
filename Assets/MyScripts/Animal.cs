using UnityEngine;

public class Animal : MonoBehaviour
{
    private string name;
    public string Name
    {
        get => name;
        private set => name = string.IsNullOrEmpty(value) ? "Unknown" : value; 
    }
    
    private int hunger;
    public int Hunger
    {
        get => hunger;
        private set => hunger = (value <= 0) ? 0 : (value >= 50) ? 50 : value;
    }

    private int happiness;
    public int Happiness
    {
        get => happiness;
        private set => happiness = (value <= 0) ? 0 : (value >= 50) ? 50 : value;
    }

    public virtual void Init(string newName, int newHunger, int newHappy) 
    {
        Name = newName;
        Hunger = newHunger;
        Happiness = newHappy;
    }

    public void AdjustHunger(int hungerChange) 
    {
        Hunger -= hungerChange;
    }

    public void AdjustHappiness(int happinessChange)
    {
        Happiness += happinessChange;
    }

    public virtual void MakeSound(string dialogue)
    {
        Debug.Log($"{Name} said {dialogue}");
    }
    public void Feed(int amount) 
    {
        Debug.Log($"{amount} of food was fed to {Name}. Hunger decreased by {amount}!");
        AdjustHunger(amount);
    }

    public void Feed(string food, int amount) 
    {
        Debug.Log($" {amount} of {food} was fed to {Name}. Hunger decreased by {amount} and Happiness increased by 5!");
        AdjustHunger(amount);
        AdjustHappiness(5);
    }

    public virtual void GetStatus()
    {
        Debug.Log($"Name: {Name} Hunger: {Hunger} Happiness: {Happiness}");
    }
}
