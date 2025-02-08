using UnityEngine;

public class BoardGen : MonoBehaviour
{
    public Transform road; // prefab to instantiate 
    private int[,] currentLevel;
    
    public int[,] level_1 = { { 0, 1, 1 ,1, 1, 0, 1, 1, 0},
                              { 0, 0, 0, 0, 1, 0, 0, 0, 0},
                              { 0, 1, 0, 1, 1, 0, 1, 1, 0},
                              { 1, 1, 0, 1, 0, 0, 1, 0, 0},
                              { 0, 0, 0, 0, 0, 1, 1, 1, 0},
                              { 0, 1, 0, 1, 0, 0, 0, 1, 1},
                              { 0, 1, 0, 0, 0, 1, 0, 0, 0},
                              { 0, 0, 1, 0, 1, 1, 0, 1, 1},
                              { 1, 0, 0, 0, 0, 0, 0, 0, 0} };

    void Start() {
        createLevel(level_1);
        currentLevel = level_1;
    }

    void spawnRoad(int x, int y) {
        Vector3 d = new Vector3(x, y, 0f);
        
        Quaternion r = Quaternion.identity;
        Instantiate(road, d, r);
    }

    void createLevel(int[,] matrix) {
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i, j] == 0) {
                    spawnRoad(i, j);
                }
            }
        }
    }

    public int[,] getCurrentLevel() {
        return currentLevel;
    }
}