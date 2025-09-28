using OpenCover.Framework.Model;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Chicken chicken;
    public Cow cow;
    public Pig pig;
    public List<Animal> animals = new List<Animal>();
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chicken.Init("KFC");
        cow.Init("Burger King");
        pig.Init("Porkshop");
        animals.Add(chicken);
        animals.Add(cow);
        animals.Add(pig);

        Debug.Log($"Welcome to the farm! There are {animals.Count} animals here!");

        foreach (Animal animal in animals)
        {
            animal.GetStatus();
        }

        foreach (Animal animal in animals)
        {
            animal.MakeSound();
            animal.Feed(5);
        }

        chicken.Feed(FoodType.Seeds, 30);
        chicken.Produce();
        chicken.GetStatus();

        pig.Feed(FoodType.RottenFood, 20);
        pig.GetStatus();

        pig.Feed(100000000);
        pig.GetStatus();
    }
}
