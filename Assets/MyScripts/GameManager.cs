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

        chicken.Feed(FoodType.Hay, 10);
        chicken.GetStatus();

        chicken.Produce();
        chicken.Feed(FoodType.Seeds, 10);
        chicken.GetStatus();

        chicken.Produce();
        chicken.GetStatus();

        pig.Feed(FoodType.Slop, 10000);
        pig.Produce();
        pig.GetStatus();

        /*chicken.Feed(FoodType.Hay, 1000);
        chicken.Sleep();
        chicken.GetStatus();

        cow.Feed(FoodType.Hay, 5);
        cow.Moo();
        cow.GetStatus();

        pig.Feed(FoodType.Hay, 15);
        pig.GetStatus();*/
    }
}
