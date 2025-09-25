using System;
using UnityEngine;
public enum FoodType { Hay, Seeds, Slop };
public abstract class Animal : MonoBehaviour
{
    private int maxHappy = 100;
    private int maxHunger = 100;
    private int timesFed = 0;

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
        private set => happiness = (value <= 0) ? 0 : (value > 100) ? 100 : value;
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

    public abstract void Produce();
   
    public void Feed(int amount)
    {
        int happinessVal = amount / 2;
        Debug.Log($" {amount} of food was fed to {Name}. Hunger decreased by {amount} and Happiness increased by {happinessVal}!");
        AdjustHunger(amount);
        AdjustHappiness(happinessVal);
    }

    public void Feed(FoodType preferredFood, int amount)
    {
        int happinessVal = amount / 2;

        if (timesFed == 2)
        {
            timesFed = 0;
            Debug.Log($" {amount} of {preferredFood} was fed to {Name}. Looks like {Name} is starting to get bored of {preferredFood}... Hunger decreased by {amount} and Happiness decreased by 5!");
            AdjustHunger(amount);
            AdjustHappiness(-5);
            Debug.Log(timesFed);
        }

        if (PreferredFood == preferredFood)
        {
            timesFed++;
            if (timesFed != 2)
            {
                Debug.Log($" {amount} of {preferredFood} was fed to {Name}. Looks like {Name} really liked the {preferredFood}! Hunger decreased by {amount} and Happiness increased by {happinessVal}!");
                AdjustHunger(amount);
                AdjustHappiness(happinessVal);
                Debug.Log(timesFed);
            }
            else
            {
                timesFed = 0;
                Debug.Log($" {amount} of {preferredFood} was fed to {Name}. Looks like {Name} is starting to get bored of {preferredFood}... Hunger decreased by {amount} and Happiness decreased by 5!");
                AdjustHunger(amount);
                AdjustHappiness(-5);
                Debug.Log(timesFed);
            }
        }
        else
        {
            timesFed = 0;
            Debug.Log($"{amount} of {preferredFood} was fed to {Name}. Looks like {Name} didn't like it much... Hunger decreased by {amount} but Happiness decreased by {happinessVal}!");
            AdjustHunger(amount);
            AdjustHappiness(-happinessVal);
            Debug.Log(timesFed);
        }
    }

    public virtual void GetStatus()
    {
        Debug.Log($"Name: {Name} Hunger: {Hunger} Happiness: {Happiness}");
    }
}
