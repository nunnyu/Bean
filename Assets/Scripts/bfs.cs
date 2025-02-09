using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class bfs : MonoBehaviour
{
    private int[,] board;
    private Queue<(int, int)> queue = new Queue<(int, int)>();
    private bool finished = false;
    public Transform movepoint;
    public Transform road;
    public HashSet<(int, int)> visited = new HashSet<(int, int)>();
    BoardGen script;
    
    private (int, int) pos;    
    void Start() {
        Invoke("initialize", 0.25f); // delay everything so the board is created nicely 
    }

    void initialize() {
        pos = (0, 5);
        script = FindObjectOfType<BoardGen>();
        board = script.level_1;
        movepoint.parent = null;
        visited.Add((pos.Item1, pos.Item2));
        Debug.Log(board);

        queue.Enqueue(pos);
    }

    void Update() {
        if (Vector2.Distance(transform.position, movepoint.position) < 0.05f) {
            Instantiate(road, movepoint.position, Quaternion.identity);
            Call();
        }
    }

    // Update is called once per frame
    void Call()
    {
        if (finished) {
            Debug.Log("2");
            return;
        }

        List<(int, int)> directionsList = new List<(int, int)>();

        (int, int) current = pos;
        if (queue.Count > 0)
        {
            movepoint.position = new Vector3(current.Item2, current.Item1);
            if (script.getBoardRowCol(current.Item1, current.Item2) == 2) {
                Debug.Log("1");
                finished = true;
                return;
            }

            // check if pos is the goal, if so break out and say we are finished
            // finished = true;

            int row = current.Item1;  
            int col = current.Item2;
            (int, int)[] directions = { (0, 1), (1, 0), (-1, 0), (0, -1) };

            for (int i = 0; i < 4; i++)  // iterating over directions
            {
                (int, int) direction = directions[i];
                int newRow = direction.Item1 + row;
                int newCol = direction.Item2 + col;

                // Pop items onto stack
                // Check bounds and if not visited
                if (newRow >= 0 && newRow < board.GetLength(0) && newCol >= 0 && newCol < board.GetLength(1) && !visited.Contains((newRow, newCol)) && script.getBoardRowCol(newRow, newCol) != 1)
                {   
                    // Mark index as visited
                    queue.Enqueue((newRow, newCol));
                    directionsList.Add((newCol, newRow));
                    visited.Add((newRow, newCol));
                }
            }
        }

        // Debug log the list of directions (output coordinates)
        // Debug.Log("Directions List:");
        // int k = 1;
        // foreach (var dir in directionsList)
        // {
        //     Debug.Log(k + ".     " + dir);
        //     k++;
        // }
    }
}