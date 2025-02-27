using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private int numRows;
    [SerializeField] private int numColumns;
    [SerializeField] private int minRows;
    [SerializeField] private int minColumns;
    [SerializeField] private Vector2 tilesize = Vector2.one;
    [SerializeField] private Vector2 padding = new Vector2(0.1f,0.1f);
    private List<GameObject> _tiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        _tiles.Capacity = numRows * numColumns;
        for (int row = minRows; row < numRows; row++)
        {
            for (int col = minColumns; col < numColumns; col++)
            {
                Vector2 pos = new Vector2(col * (tilesize.x + padding.x), row * (tilesize.y + padding.y));
                GameObject tile = Instantiate(_tilePrefab, pos, Quaternion.identity,transform);
                _tiles.Add(tile);
            }
        }
    }

    public GameObject GetTile(int column, int row)
    {
        if (column < 0 || row < 0 || column >= numColumns || row >= numRows)
        {
            Debug.LogError($"Invalid tile coordinate({column},{row})");
            return null;
        }
        else
        {
            return _tiles[row * numColumns + column];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
