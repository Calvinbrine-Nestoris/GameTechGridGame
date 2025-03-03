using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawning : MonoBehaviour
{
    public GameObject fireball;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private Vector2Int _gridPos;
    float maxCountdown = 2f;
    float countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = maxCountdown;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown >= maxCountdown)
        {
            _gridPos.x = Random.Range(0, _gridManager.numColumns);
            _gridPos.y = Random.Range(0, _gridManager.numRows);
            GameObject tile = _gridManager.GetTile(_gridPos.x, _gridPos.y);
            transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, -5f);
            Instantiate(fireball, transform.position, transform.rotation);
            countdown = 0;
            if (maxCountdown > 0.2f)
            {
                maxCountdown -= 0.2f;
            }
        }
        else
        {
            countdown += Time.deltaTime;
        }
    }
}
