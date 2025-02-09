using UnityEngine;

public class BoardGen : MonoBehaviour
{
    public Transform road; // prefab to instantiate 
    private int[,] currentLevel;
    public Transform taco;
    public Transform hummus;
    public Transform sushi;
    public Transform wall;
    public Transform keurig;
    
    public int[,] level_1 = { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },  
                              { 1, 0, 0, 0, 1, 0, 0, 4, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },  
                              { 1, 5, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1 },  
                              { 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1 },  
                              { 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 2, 1 },  
                              { 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 },  
                              { 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 1 },  
                              { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1 },  
                              { 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 3, 1 },  
                              { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1 },  
                              { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1 },  
                              { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1 },  
                              { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1 },  
                              { 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1 },  
                              { 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1 },  
                              { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1 },  
                              { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };
                              
    void Start() {
        FindObjectOfType<ManageAudio>().PlayLoop("Background");
        createLevel(level_1);
        currentLevel = level_1;
    }

    void spawnPrefab(Transform p, int x, int y) {
        Vector3 d = new Vector3(x, y, 0f);
        
        Quaternion r = Quaternion.identity;
        Instantiate(p, d, r);
    }

    void createLevel(int[,] matrix) {
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i, j] == 0) {
                    spawnPrefab(road, j, matrix.GetLength(0) - 1 - i);
                } else if (matrix[i, j] == 2) {
                    spawnPrefab(taco, j, matrix.GetLength(0) - 1 - i);
                } else if (matrix[i, j] == 3) {
                    spawnPrefab(hummus, j, matrix.GetLength(0) - 1 - i);
                } else if (matrix[i, j] == 4) {
                    spawnPrefab(sushi, j, matrix.GetLength(0) - 1 - i);
                } else if (matrix[i, j] == 1) {
                    spawnPrefab(wall, j, matrix.GetLength(0) - 1 - i);
                } else if (matrix[i, j] == 5) {
                    spawnPrefab(keurig, j, matrix.GetLength(0) - 1 - i);
                }
            }
        }
    }

    public int[,] getCurrentLevel() {
        return currentLevel;
    }

    // Obtain the (visual) element at index row, col where 0,0 is the bottom left 
    public int getBoardRowCol(int row, int col)
    {
        return level_1[level_1.GetLength(0) - 1 - row, col];
    }

    public void setBoardRowCol(int row, int col, int val) {
        level_1[level_1.GetLength(0) - 1 - row, col] = val;
    }
}