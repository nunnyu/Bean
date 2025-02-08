using System.Collections.Generic;
using UnityEngine;

public class dfs : MonoBehaviour
{
    int[,] board;

    Stack<(int, int)> stack;

    bool finished = false;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (finished) return;
        (int, int) pos = (0, 0);
        if (stack.TryPop(out pos))
        {
            // check if pos is the goal, if so break out and say we are finished
            finished = true;

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
                    stack.Push((newRow, newCol));
                }
            }
        }
    }
}