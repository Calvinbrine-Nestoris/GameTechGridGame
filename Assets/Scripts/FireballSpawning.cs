using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawning : MonoBehaviour
{
    public GameObject fireball;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private Vector2Int _gridPos;
    float maxCountdown = 1.8f;
    float countdown;
    public static float speed = 3.0f;
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
            if (speed < 5)
            {
                speed += 0.2f;
            }
            else if (speed < 9)
            {
                speed += 0.02f;
            }
            Instantiate(fireball, transform.position, transform.rotation);
            countdown = 0;
            if (maxCountdown > 0.3f)
            {
                maxCountdown -= 0.1f;
            }
            if (maxCountdown > 0.1f)
            {
                maxCountdown -= 0.005f;
            }
        }
        else
        {
            countdown += Time.deltaTime;
        }
    }
}
