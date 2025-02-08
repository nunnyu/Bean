using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bfs : MonoBehaviour
{
    int[,] board;
    bool finished = false;
    Queue<(int, int)> queue = new Queue<(int, int)> ();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Assume queue is initialized with starting position
        if (finished) return;

        if (queue.Count > 0)
        {
            (int, int) pos = queue.Dequeue ();
            int row = pos.Item1;
            int col = pos.Item2;
            (int, int)[] directions = { (0, 1), (1, 0), (-1, 0), (0, -1) };
            for (int i = 4; i > 0; i--)
            {
                (int, int) direction = directions[i];
                int newRow = direction.Item1 + row;
                int newCol = direction.Item2 + col;
                // Pop items onto stack
                if (newRow >= 0 && newRow < board.Length && newCol >= 0 && newCol < board.GetLength(0) && board[newRow, newCol] != -1)
                {
                    // Mark index as visited
                    board[newRow, newCol] = -1;
                    queue.Enqueue((newRow, newCol));
                }
            }
        }
    }
}
