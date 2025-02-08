using System.Collections.Generic;
using UnityEngine;

public class dfs : MonoBehaviour
{
    int[,] board;

    Stack<(int, int)> stack;

    bool finished = false;
    public Transform movepoint;
        
    void Start() {
        BoardGen boardGenScript = FindObjectOfType<BoardGen>();
        board = boardGenScript.getCurrentLevel();
    }

    void Update() {
        if (transform.position == movepoint.position) {
            Call((((int)transform.position.x, (int)transform.position.y)));
        }
        // movepoint.position += new Vector3(1, 0);
    }

    // Update is called once per frame
    void Call((int, int) pos)
    {
        if (finished) {
            return;
        }

        if (stack.TryPop(out pos))
        {
            // check if pos is the goal, if so break out and say we are finished
            finished = true;

            int row = pos.Item1;
            int col = pos.Item2;
            (int, int)[] directions = { (0, 1), (1, 0), (-1, 0), (0, -1) };
            for (int i = 3; i >= 0; i--)
            {
                (int, int) direction = directions[i];
                movepoint.position += new Vector3(direction.Item1, direction.Item2);
                Debug.Log(direction);
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