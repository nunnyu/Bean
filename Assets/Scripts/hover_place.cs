using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering;

public class hover_place : MonoBehaviour
{
    public GameObject manager;
    BoardGen referencedScript;
    int[,] board;
    int curRow = 0;
    int curCol = 0;

    bool acceptInput = true;
    public Transform hover_select;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        board = manager.GetComponent<BoardGen>().level_1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!acceptInput) return;
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            curRow = Math.Clamp(curRow + 1, 0, board.Length);
        } else if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            curRow = Math.Clamp(curRow - 1, 0, board.Length);
        } else if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            curCol = Math.Clamp(curCol - 1, 0, board.Length);
        } else if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            curCol = Math.Clamp(curCol + 1, 0, board.Length);
        }
        hover_select.position = new Vector3(curCol, curRow, 0);
        print(curCol + " " + curRow);
    }
}
