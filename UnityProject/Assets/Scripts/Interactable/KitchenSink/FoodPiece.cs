using System;
using UnityEngine;

public class FoodPiece : MonoBehaviour
{
    public int Health = 10;
    
    public bool Invincible = false;

    public void RemoveHealth()
    {
        Health--;
    }

    public void SayMyFamilyILovedThem()
    {
        gameObject.GetComponentInParent<Plate>().AddDestroyedPiece();
        Destroy(gameObject);
    }
}
