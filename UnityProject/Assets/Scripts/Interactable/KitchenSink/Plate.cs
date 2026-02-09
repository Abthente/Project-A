using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Plate : MonoBehaviour
{
    public GameObject PiecePrefab;
        
    private int _amountOfPieces = 10;
    private int _amountOfDestroyedPieces = 0;
    
    private void Start()
    {
        float radius = this.gameObject.GetComponent<CircleCollider2D>().radius;
        
        for (int i = 0; i < _amountOfPieces - 1; i++)
        {
            Vector3 randomPoint = (Random.insideUnitCircle * radius * 2);
            randomPoint = randomPoint + transform.position;

            GameObject created = Instantiate(PiecePrefab, randomPoint, Quaternion.identity);
            created.transform.parent = transform;
            
            float randomScaleX = Random.Range(0.3f, 0.7f);
            float randomScaleY = Random.Range(0.3f, 0.7f);
            float randomScaleZ = Random.Range(0.3f, 0.7f);
            
            created.transform.localScale = new Vector3(randomScaleX, randomScaleY, randomScaleZ);
        }
    }

    public void AddDestroyedPiece()
    {
        _amountOfDestroyedPieces += 1;
        WinCondition();
    }

    private void WinCondition()
    {
        if (_amountOfDestroyedPieces >= _amountOfPieces)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
