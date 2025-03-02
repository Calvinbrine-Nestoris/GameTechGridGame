using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private Vector2Int _gridPos;
    public const float maxCountdown = 0.4f;
    float movementCooldown = maxCountdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject tile = _gridManager.GetTile(_gridPos.x, _gridPos.y);
        transform.position = tile.transform.position;
        if (movementCooldown < maxCountdown)
        {
            movementCooldown += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) && movementCooldown >= maxCountdown)
        {
            if ((_gridPos.x + 1) >= 0 && (_gridPos.x + 1) < _gridManager.numColumns)
            {
                _gridPos.x += 1;
            }
            else if ((_gridPos.x + 1) < 0)
            {
                _gridPos.x = _gridManager.numColumns - 1;
            }
            else if ((_gridPos.x + 1) >= _gridManager.numColumns)
            {
                _gridPos.x = 0;
            }
            movementCooldown = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && movementCooldown >= maxCountdown)
        {
            if ((_gridPos.x - 1) >= 0 && (_gridPos.x - 1) < _gridManager.numColumns)
            {
                _gridPos.x -= 1;
            }
            else if ((_gridPos.x - 1) < 0)
            {
                _gridPos.x = _gridManager.numColumns - 1;
            }
            else if ((_gridPos.x - 1) >= _gridManager.numColumns)
            {
                _gridPos.x = 0;
            }
            movementCooldown = 0;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && movementCooldown >= maxCountdown)
        {
            if ((_gridPos.y + 1) >= 0 && (_gridPos.y + 1) < _gridManager.numColumns)
            {
                _gridPos.y += 1;
            }
            else if ((_gridPos.y + 1) < 0)
            {
                _gridPos.y = _gridManager.numColumns - 1;
            }
            else if ((_gridPos.y + 1) >= _gridManager.numColumns)
            {
                _gridPos.y = 0;
            }
            movementCooldown = 0;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && movementCooldown >= maxCountdown)
        {
            if ((_gridPos.y - 1) >= 0 && (_gridPos.y - 1) < _gridManager.numColumns)
            {
                _gridPos.y -= 1;
            }
            else if ((_gridPos.y - 1) < 0)
            {
                _gridPos.y = _gridManager.numColumns - 1;
            }
            else if ((_gridPos.y - 1) >= _gridManager.numColumns)
            {
                _gridPos.y = 0;
            }
            movementCooldown = 0;
        }
    }
}
