using System;
using Unity.VisualScripting;
using UnityEngine;

public class Sponge : MonoBehaviour
{
    private bool _isDragged = false;

    private void Update()
    {
        if (_isDragged)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 converted = Camera.main.ScreenToWorldPoint(mousePos);
            converted.z = 0;

            transform.position = converted;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FoodPiece"))
        {
            var foodPiece = collision.gameObject.GetComponent<FoodPiece>();
            
            if (!(foodPiece.Invincible))
            {
                foodPiece.RemoveHealth();
                foodPiece.Invincible = true;

                if (foodPiece.Health <= 0)
                {
                    foodPiece.SayMyFamilyILovedThem();
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FoodPiece"))
        {
            var foodPiece = collision.gameObject.GetComponent<FoodPiece>();
            
            if (!!(foodPiece.Invincible))
            {
                foodPiece.Invincible = false;
            }
        }
    }

    private void OnMouseDown()
    {
        _isDragged = true;
    }
    
    private void OnMouseUp()
    {
        _isDragged = false;
    }
}
