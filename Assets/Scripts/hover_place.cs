using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering;

public class hover_place : MonoBehaviour
{
    public GameObject manager; // Board gen script  
    BoardGen referencedScript;
    int[,] board;
    int curRow = 0;
    int curCol = 0;

    bool acceptInput = true;
    public Transform hover_select;
    public Transform hover_bean;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        referencedScript = manager.GetComponent<BoardGen>();
        board = referencedScript.level_1;
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
        hover_bean.position = new Vector3(curCol, curRow, 0);
        print(curRow + "," + curCol + " " + referencedScript.getBoardRowCol(curRow, curCol));
    }
}
