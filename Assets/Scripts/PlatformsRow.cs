using UnityEngine;

public class PlatformsRow
{
    private const float MaxDeltaX = 4.1f;
    private GameObject _left;
    private GameObject _right;
    public float posY;

    private float _defaultX;

    public PlatformsRow(GameObject left, GameObject right, float defaultX)
    {
        _left = left;
        _right = right;
        posY = left.transform.position.y;
        _defaultX = defaultX;
    }

    public void Rebuild(float yPos, bool needChangeX)
    {
        Vector3 newPos = _left.transform.position;
        newPos.y = yPos;
        newPos.x = needChangeX ? -_defaultX + Random.Range(0f, MaxDeltaX) : -_defaultX;
        _left.transform.position = newPos;
        
        newPos = _right.transform.position;
        newPos.y = yPos;
        newPos.x = needChangeX ? _defaultX - Random.Range(0f, MaxDeltaX) : _defaultX;
        _right.transform.position = newPos;
        
        posY = yPos;
        
        
    }
}