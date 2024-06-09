using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGames : MonoBehaviour
{
    public GameObject square;
    public GameObject glowingArea;
    public KeyCode actionKey = KeyCode.Space;
    public float moveSpeed = 2f;
    public float speedIncrement = 0.5f;
    public List<Vector3> glowingAreaPositions;
    public int maxAttempts = 10;
    public GameObject winScreen;

    private int currentGlowingAreaIndex = 0;
    private int attempts = 0;
    private Renderer squareRenderer;
    private Renderer glowingAreaRenderer;
    private bool movingUp = true;

    void Start()
    {
        squareRenderer = square.GetComponent<Renderer>();
        glowingAreaRenderer = glowingArea.GetComponent<Renderer>();

        // Ensure initial position is set correctly
        if (glowingAreaPositions.Count > 0)
        {
            glowingArea.transform.position = glowingAreaPositions[currentGlowingAreaIndex];
        }

        winScreen.SetActive(false); // Hide the win screen initially
    }

    void Update()
    {
        if (attempts < maxAttempts)
        {
            MoveSquare();
            CheckForInput();
        }
        else
        {
            //ShowWinScreen();
            Debug.Log("Udah 10x");
        }
    }

    void MoveSquare()
    {
        Vector3 position = square.transform.position;
        if (movingUp)
        {
            position.y += moveSpeed * Time.deltaTime;
            if (position.y >= 5f) // Set your upper bound
            {
                movingUp = false;
            }
        }
        else
        {
            position.y -= moveSpeed * Time.deltaTime;
            if (position.y <= -5f) // Set your lower bound
            {
                movingUp = true;
            }
        }
        square.transform.position = position;
    }

    void CheckForInput()
    {
        if (Input.GetKeyDown(actionKey))
        {
            if (IsSquareInGlowingArea())
            {
                Debug.Log("Success! The square is in the glowing area.");
                // Add your logic here for what happens when the player successfully presses the button.
            }
            else
            {
                Debug.Log("Miss! The square is not in the glowing area.");
                // Add your logic here for what happens when the player misses.
            }

            // Move the glowing area to the next position
            MoveToNextGlowingArea();
            attempts++;
            moveSpeed += speedIncrement; // Increase speed after each attempt
        }
    }

    bool IsSquareInGlowingArea()
    {
        Bounds squareBounds = squareRenderer.bounds;
        Bounds glowingAreaBounds = glowingAreaRenderer.bounds;
        return squareBounds.Intersects(glowingAreaBounds);
    }

    void MoveToNextGlowingArea()
    {
        currentGlowingAreaIndex++;
        if (currentGlowingAreaIndex >= glowingAreaPositions.Count)
        {
            currentGlowingAreaIndex = 0; // Loop back to the first glowing area
        }

        glowingArea.transform.position = glowingAreaPositions[currentGlowingAreaIndex];
    }

    /*void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }*/
}

