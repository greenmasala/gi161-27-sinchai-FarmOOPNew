using OpenCover.Framework.Model;
using System;
using UnityEngine;
public enum FoodType { Hay, Seeds, Slop, RottenFood, AnimalFood };
public abstract class Animal : MonoBehaviour
{
    private int maxHappy = 100;
    private int maxHunger = 100;

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
        private set => hunger = (value <= 0) ? 0 : (value > 100) ? 100 : value;
    }

    private int happiness;
    public int Happiness
    {
        get => happiness;
        protected set => happiness = (value <= 0) ? 0 : (value > 100) ? 100 : value;
    }

    private FoodType preferredFood;
    public FoodType PreferredFood { get; private set; }

    public void Init(string newName, FoodType preferredFood)
    {
        Name = newName;
        Hunger = 50;
        Happiness = 50;
        PreferredFood = preferredFood;
    }

    /*public void Init(string newName, int newHunger, int newHappy)
    {
        newHunger = 50;
        newHappy = 50;

        Name = newName;
        Hunger = newHunger;
        Happiness = newHappy;
    }*/

    public void AdjustHunger(int hungerChange)
    {
        Hunger = Mathf.Clamp(Hunger - hungerChange, 0, maxHunger);
    }

    public void AdjustHappiness(int happinessChange)
    {
        Happiness = Mathf.Clamp(Happiness + happinessChange, 0, maxHappy);
    }

    public abstract void MakeSound();

    public abstract string Produce();
   
    public void Feed(int amount)
    {
        int happinessVal = amount / 2;
        Debug.Log($" {amount} of food was fed to {Name}. Hunger decreased by {amount} and Happiness increased by {happinessVal}!");
        AdjustHunger(amount);
        AdjustHappiness(happinessVal);
    }

    public void Feed(FoodType chosenFood, int amount)
    {
        if (chosenFood == PreferredFood)
        {
            Debug.Log($" {amount} of {chosenFood} was fed to {Name}. Looks like {Name} really liked the {chosenFood}! Hunger decreased by {amount} and Happiness increased by 15!");
            AdjustHunger(amount);
            AdjustHappiness(15);
        }
        else if (chosenFood == FoodType.RottenFood)
        {
            Debug.Log($" {amount} of {chosenFood} was fed to {Name}. Looks like {Name} really didn't like that! Hunger decreased by {amount} but Happiness decreased by 20!");
            AdjustHunger(amount);
            AdjustHappiness(-20);
        }
        else
        {
            Debug.Log($"{amount} of {chosenFood} was fed to {Name}. Looks like {Name} didn't like it that much, but still ate it... Hunger decreased by {amount} but Happiness decreased by 5!");
            AdjustHunger(amount);
            AdjustHappiness(-5);
        }
    }

    public virtual void GetStatus()
    {
        Debug.Log($"Name: {Name} Hunger: {Hunger} Happiness: {Happiness}");
    }
}
