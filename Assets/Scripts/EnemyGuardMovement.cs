using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> checkPoints = new List<GameObject>();
    [SerializeField] private float epsilon = 1.2f;
    [SerializeField] private float speed = 0.07f;
    [SerializeField] private float delayTime = 0.01f;
    private Vector2 movement = Vector2.zero;
    private int currentTargetIndex = 0;
    private Vector2 targetPosition;

    void Start()
    {
        StartCoroutine(MoveEnemyGuard());
    }
    void SelectCheckPoint()
    {
        int newTargetIndex;
        do
        {
            newTargetIndex = Random.Range(0, checkPoints.Count);
        } while (newTargetIndex == currentTargetIndex);

        currentTargetIndex = newTargetIndex;
        targetPosition = checkPoints[currentTargetIndex].transform.position;

        GetComponent<SpriteRenderer>().material.color = checkPoints[currentTargetIndex].GetComponent<SpriteRenderer>().color;
    }

    IEnumerator MoveEnemyGuard()
    {
        while (true)
        {
            if (Vector2.Distance(transform.position, targetPosition) < epsilon)
            {
                SelectCheckPoint();
            }

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
            yield return new WaitForSeconds(delayTime);
        }
    }
}


