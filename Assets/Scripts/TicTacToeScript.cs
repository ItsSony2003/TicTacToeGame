using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    bool checker;
    int plusOne;
    private bool gameOver = false; // Flag to track if the game is over
    private bool isComputerMode = false; // Flag for mode selection

    public Text btnTL = null;
    public Text btnTM = null;
    public Text btnTR = null;
    public Text btnML = null;
    public Text btnMM = null;
    public Text btnMR = null;
    public Text btnBL = null;
    public Text btnBM = null;
    public Text btnBR = null;
    public Text btnComputer = null;

    public Text btnResetGame = null;
    public Text btnNewGame = null;

    public Text message = null;
    public Text gameMode = null;
    public Text lblPlayerO = null; // text to change between player O and Computer mode

    public Text txtPlayerX;
    public Text txtPlayerO;

    private bool IsAllButtonsFilled()
    {
        return !string.IsNullOrEmpty(btnTL.text) &&
               !string.IsNullOrEmpty(btnTM.text) &&
               !string.IsNullOrEmpty(btnTR.text) &&
               !string.IsNullOrEmpty(btnML.text) &&
               !string.IsNullOrEmpty(btnMM.text) &&
               !string.IsNullOrEmpty(btnMR.text) &&
               !string.IsNullOrEmpty(btnBL.text) &&
               !string.IsNullOrEmpty(btnBM.text) &&
               !string.IsNullOrEmpty(btnBR.text);
    }

    private void HighlightWinningLine(Text btn1, Text btn2, Text btn3)
    {
        btn1.color = Color.red;
        btn2.color = Color.red;
        btn3.color = Color.red;
    }

    private void WinningPlayerX()
    {
        gameOver = true;
        message.text = "Player X Wins!!";
        plusOne = int.Parse(txtPlayerX.text);
        txtPlayerX.text = Convert.ToString(plusOne + 1);
    }

    private void WinningPlayerO()
    {
        gameOver = true;
        if(isComputerMode)
        {
            message.text = "Computer Wins!!";
        }
        else
        {
            message.text = "Player O Wins!!";
        }
        plusOne = int.Parse(txtPlayerO.text);
        txtPlayerO.text = Convert.ToString(plusOne + 1);
    }

    public void Score()
    {
        // Player X Checks (Win Condition)
        if (btnTL.text == "X" && btnTM.text == "X" && btnTR.text == "X")
        {
            HighlightWinningLine(btnTL, btnTM, btnTR);
            WinningPlayerX();
        }
        if (btnML.text == "X" && btnMM.text == "X" && btnMR.text == "X")
        {
            HighlightWinningLine(btnML, btnMM, btnMR);
            WinningPlayerX();
        }
        if (btnBL.text == "X" && btnBM.text == "X" && btnBR.text == "X")
        {
            HighlightWinningLine(btnBL, btnBM, btnBR);
            WinningPlayerX();
        }
        if (btnTL.text == "X" && btnMM.text == "X" && btnBR.text == "X")
        {
            HighlightWinningLine(btnTL, btnMM, btnBR);
            WinningPlayerX();
        }
        if (btnTR.text == "X" && btnMM.text == "X" && btnBL.text == "X")
        {
            HighlightWinningLine(btnTR, btnMM, btnBL);
            WinningPlayerX();
        }
        if (btnTL.text == "X" && btnML.text == "X" && btnBL.text == "X")
        {
            HighlightWinningLine(btnTL, btnML, btnBL);
            WinningPlayerX();
        }
        if (btnTM.text == "X" && btnMM.text == "X" && btnBM.text == "X")
        {
            HighlightWinningLine(btnTM, btnMM, btnBM);
            WinningPlayerX();
        }
        if (btnTR.text == "X" && btnMR.text == "X" && btnBR.text == "X")
        {
            HighlightWinningLine(btnTR, btnMR, btnBR);
            WinningPlayerX();
        }

        //===========================================================
        // Player O Checks (Win Condition)
        if (btnTL.text == "O" && btnTM.text == "O" && btnTR.text == "O")
        {
            HighlightWinningLine(btnTL, btnTM, btnTR);
            WinningPlayerO();
        }
        if (btnML.text == "O" && btnMM.text == "O" && btnMR.text == "O")
        {
            HighlightWinningLine(btnML, btnMM, btnMR);
            WinningPlayerO();
        }
        if (btnBL.text == "O" && btnBM.text == "O" && btnBR.text == "O")
        {
            HighlightWinningLine(btnBL, btnBM, btnBR);
            WinningPlayerO();
        }
        if (btnTL.text == "O" && btnMM.text == "O" && btnBR.text == "O")
        {
            HighlightWinningLine(btnTL, btnMM, btnBR);
            WinningPlayerO();
        }
        if (btnTR.text == "O" && btnMM.text == "O" && btnBL.text == "O")
        {
            HighlightWinningLine(btnTR, btnMM, btnBL);
            WinningPlayerO();
        }
        if (btnTL.text == "O" && btnML.text == "O" && btnBL.text == "O")
        {
            HighlightWinningLine(btnTL, btnML, btnBL);
            WinningPlayerO();
        }
        if (btnTM.text == "O" && btnMM.text == "O" && btnBM.text == "O")
        {
            HighlightWinningLine(btnTM, btnMM, btnBM);
            WinningPlayerO();
        }
        if (btnTR.text == "O" && btnMR.text == "O" && btnBR.text == "O")
        {
            HighlightWinningLine(btnTR, btnMR, btnBR);
            WinningPlayerO();
        }

        // Draw Condition (All buttons filled and no winner)
        if (!gameOver && IsAllButtonsFilled()) // Only check draw if no one won
        {
            message.text = "It's A Draw!";
            gameOver = true;
        }
    }

    // Click btnComputer
    public void btnComputer_Click()
    {
        if (!isComputerMode)
        {
            btnComputer.text = "Switch To\n2-Player Mode";
            isComputerMode = true;
            gameMode.text = "TicTacToe Computer Mode";
            lblPlayerO.text = "Computer:";
            btnResetGame_Click();
            txtPlayerO.text = "0";
            txtPlayerX.text = "0";
            gameOver = false;
        }
        else
        {
            btnComputer.text = "Switch To\nComputer Mode";
            isComputerMode = false;
            gameMode.text = "TicTacToe 2-Player Mode";
            lblPlayerO.text = "Player O:";
            btnResetGame_Click();
            txtPlayerO.text = "0";
            txtPlayerX.text = "0";
            gameOver = false;
        }
    }

    // Click TL grid
    public void btnTL_Click()
    {
        // Prevent actions if the game is over or grid is already occupied
        if (gameOver || !string.IsNullOrEmpty(btnTL.text))
        {
            return;
        }
        if (!isComputerMode) // 2-Player Mode
        {
            if (!checker) // Player X's turn
            {
                btnTL.text = "X";
                checker = true;
            }
            else // Player O's turn
            {
                btnTL.text = "O";
                checker = false;
            }
            Score();
        }
        else // Computer Mode
        {
            if (!checker) // Player X's turn
            {
                btnTL.text = "X";
                checker = true; // Switch to Computer
                Score();

                // Trigger computer's move immediately after Player X in Computer Mode
                if (isComputerMode && !gameOver)
                {
                    ComputerMove();
                    Score();
                }
            }
        }
    }

    // Click TM grid
    public void btnTM_Click()
    {
        // Prevent actions if the game is over or grid is already occupied
        if (gameOver || !string.IsNullOrEmpty(btnTM.text))
        {
            return;
        }

        if (!isComputerMode) // 2-Player Mode
        {
            if (checker == false)
            {
                btnTM.text = "X";
                checker = true;
            }
            else
            {
                btnTM.text = "O";
                checker = false;
            }
            Score();
        }
        else // Computer Mode
        {
            if (!checker) // Player X's turn
            {
                btnTM.text = "X";
                checker = true; // Switch to Computer
                Score();

                // Trigger computer's move immediately after Player X in Computer Mode
                if (isComputerMode && !gameOver)
                {
                    ComputerMove();
                    Score();
                }
            }
        }
    }

    // Click TR grid
    public void btnTR_Click()
    {
        // Prevent actions if the game is over or grid is already occupied
        if (gameOver || !string.IsNullOrEmpty(btnTR.text))
        {
            return;
        }

        if (!isComputerMode) // 2-Player Mode
        {
            if (checker == false)
            {
                btnTR.text = "X";
                checker = true;
            }
            else
            {
                btnTR.text = "O";
                checker = false;
            }
            Score();
        }
        else // Computer Mode
        {
            if (!checker) // Player X's turn
            {
                btnTR.text = "X";
                checker = true; // Switch to Computer
                Score();

                // Trigger computer's move immediately after Player X in Computer Mode
                if (isComputerMode && !gameOver)
                {
                    ComputerMove();
                    Score();
                }
            }
        }
    }

    // Click MR grid
    public void btnMR_Click()
    {
        // Prevent actions if the game is over or grid is already occupied
        if (gameOver || !string.IsNullOrEmpty(btnMR.text))
        {
            return;
        }

        if (!isComputerMode) // 2-Player Mode
        {
            if (checker == false)
            {
                btnMR.text = "X";
                checker = true;
            }
            else
            {
                btnMR.text = "O";
                checker = false;
            }
            Score();
        }
        else // Computer Mode
        {
            if (!checker) // Player X's turn
            {
                btnMR.text = "X";
                checker = true; // Switch to Computer
                Score();

                // Trigger computer's move immediately after Player X in Computer Mode
                if (isComputerMode && !gameOver)
                {
                    ComputerMove();
                    Score();
                }
            }
        }
    }

    // Click MM grid
    public void btnMM_Click()
    {
        // Prevent actions if the game is over or grid is already occupied
        if (gameOver || !string.IsNullOrEmpty(btnMM.text))
        {
            return;
        }

        if (!isComputerMode) // 2-Player Mode
        {
            if (checker == false)
            {
                btnMM.text = "X";
                checker = true;
            }
            else
            {
                btnMM.text = "O";
                checker = false;
            }
            Score();
        }
        else // Computer Mode
        {
            if (!checker) // Player X's turn
            {
                btnMM.text = "X";
                checker = true; // Switch to Computer
                Score();

                // Trigger computer's move immediately after Player X in Computer Mode
                if (isComputerMode && !gameOver)
                {
                    ComputerMove();
                    Score();
                }
            }
        }
    }

    // Click ML grid
    public void btnML_Click()
    {
        // Prevent actions if the game is over or grid is already occupied
        if (gameOver || !string.IsNullOrEmpty(btnML.text))
        {
            return;
        }

        if (!isComputerMode) // 2-Player Mode
        {
            if (checker == false)
            {
                btnML.text = "X";
                checker = true;
            }
            else
            {
                btnML.text = "O";
                checker = false;
            }
            Score();
        }
        else // Computer Mode
        {
            if (!checker) // Player X's turn
            {
                btnML.text = "X";
                checker = true; // Switch to Computer
                Score();

                // Trigger computer's move immediately after Player X in Computer Mode
                if (isComputerMode && !gameOver)
                {
                    ComputerMove();
                    Score();
                }
            }
        }
    }

    // Click BL grid
    public void btnBL_Click()
    {
        // Prevent actions if the game is over or grid is already occupied
        if (gameOver || !string.IsNullOrEmpty(btnBL.text))
        {
            return;
        }

        if (!isComputerMode) // 2-Player Mode
        {
            if (checker == false)
            {
                btnBL.text = "X";
                checker = true;
            }
            else
            {
                btnBL.text = "O";
                checker = false;
            }
            Score();
        }
        else // Computer Mode
        {
            if (!checker) // Player X's turn
            {
                btnBL.text = "X";
                checker = true; // Switch to Computer
                Score();

                // Trigger computer's move immediately after Player X in Computer Mode
                if (isComputerMode && !gameOver)
                {
                    ComputerMove();
                    Score();
                }
            }
        }
    }

    // Click BM grid
    public void btnBM_Click()
    {
        // Prevent actions if the game is over or grid is already occupied
        if (gameOver || !string.IsNullOrEmpty(btnBM.text))
        {
            return;
        }

        if (!isComputerMode) // 2-Player Mode
        {
            if (checker == false)
            {
                btnBM.text = "X";
                checker = true;
            }
            else
            {
                btnBM.text = "O";
                checker = false;
            }
            Score();
        }
        else // Computer Mode
        {
            if (!checker) // Player X's turn
            {
                btnBM.text = "X";
                checker = true; // Switch to Computer
                Score();

                // Trigger computer's move immediately after Player X in Computer Mode
                if (isComputerMode && !gameOver)
                {
                    ComputerMove();
                    Score();
                }
            }
        }
    }

    // Click BR grid
    public void btnBR_Click()
    {
        // Prevent actions if the game is over or grid is already occupied
        if (gameOver || !string.IsNullOrEmpty(btnBR.text))
        {
            return;
        }

        if (!isComputerMode) // 2-Player Mode
        {
            if (checker == false)
            {
                btnBR.text = "X";
                checker = true;
            }
            else
            {
                btnBR.text = "O";
                checker = false;
            }
            Score();
        }
        else // Computer Mode
        {
            if (!checker) // Player X's turn
            {
                btnBR.text = "X";
                checker = true; // Switch to Computer
                Score();

                // Trigger computer's move immediately after Player X in Computer Mode
                if (isComputerMode && !gameOver)
                {
                    ComputerMove();
                    Score();
                }
            }
        }
    }

    public void btnResetGame_Click()
    {
        btnTL.text = "";
        btnTM.text = "";
        btnTR.text = "";
        btnML.text = "";
        btnMM.text = "";
        btnMR.text = "";
        btnBL.text = "";
        btnBM.text = "";
        btnBR.text = "";

        btnTL.color = Color.white;
        btnTM.color = Color.white;
        btnTR.color = Color.white;
        btnML.color = Color.white;
        btnMM.color = Color.white;
        btnMR.color = Color.white;
        btnBL.color = Color.white;
        btnBM.color = Color.white;
        btnBR.color = Color.white;

        message.text = "";
        gameOver = false;
        checker = false;  // Reset starting player to X
    }

    public void btnNewGame_Click()
    {
        btnResetGame_Click();
        txtPlayerO.text = "0";
        txtPlayerX.text = "0";
        gameOver = false;
    }

    private void ComputerMove()
    {
        if (gameOver) return; // Exit early if the game is over

        List<Text> availableButtons = new List<Text> { btnTL, btnTM, btnTR, btnML, btnMM, btnMR, btnBL, btnBM, btnBR };

        // Filter to get empty buttons
        availableButtons.RemoveAll(button => !string.IsNullOrEmpty(button.text));

        // Step 1: Check for a winning move for the computer (if Possible)
        foreach (var line in GetWinningLines()) // Iterate through all potential winning lines
        {
            if (line.Count(button => button.text == "O") == 2)
            {
                // Find the empty button in the line
                Text emptyButton = line.FirstOrDefault(button => string.IsNullOrEmpty(button.text));
                if (emptyButton != null && availableButtons.Contains(emptyButton))
                {
                    emptyButton.text = "O"; // Computer wins by completing the line
                    checker = false; // Switch to Player X
                    return; // Exit after making the winning move
                }
            }
        }

        // Step 2: Block Player X's winning move (if possible)
        foreach (var line in GetWinningLines()) // Iterate through all potential winning lines
        {
            // Find which line has two 'X's and a blank spot
            if (line.Count(button => button.text == "X") == 2)
            {
                // Find the empty button in the line
                Text emptyButton = line.FirstOrDefault(button => string.IsNullOrEmpty(button.text));
                if (emptyButton != null && availableButtons.Contains(emptyButton))
                {
                    emptyButton.text = "O"; // Block the move by placing an 'O'
                    checker = false; // Switch to Player X
                    return; // Exit after blocking
                }
            }
        }

        // Step 3: Handle the first move scenario
        // Scenario 1: Player X moved in the center (btnMM)
        if (!string.IsNullOrEmpty(btnMM.text))
        {
            // 60% chance to go for a corner (btnTL, btnTR, btnBL, btnBR)
            List<Text> cornerButtons = new List<Text> { btnTL, btnTR, btnBL, btnBR };
            cornerButtons.RemoveAll(button => !availableButtons.Contains(button));
            if (cornerButtons.Count > 0 && UnityEngine.Random.value < 0.4f) // 40% chance
            {
                Text selectedButton = cornerButtons[UnityEngine.Random.Range(0, cornerButtons.Count)];
                selectedButton.text = "O";
                checker = false; // Switch to Player X's turn
                return; // Exit function after making the first move
            }
            else // Else take random available
            {
                Text selectedButton = availableButtons[UnityEngine.Random.Range(0, availableButtons.Count)];
                selectedButton.text = "O";
                checker = false; // Switch back to Player X
                return;
            }
        }

        // Scenario 2: Player X go anywhere else except in the middle
        else // If Player X started anywhere other than the center, computer takes the center with 40% chance
        {
            if (availableButtons.Contains(btnMM) && UnityEngine.Random.value < 0.4f) // 40% chance
            {
                btnMM.text = "O"; // Computer takes the center
                checker = false; // Switch to Player X's turn
                return;
            }
        }

        // Step 4: If it's not the Step 1-3, pick a random available button
        if (availableButtons.Count > 0)
        {
            Text selectedButton = availableButtons[UnityEngine.Random.Range(0, availableButtons.Count)];
            selectedButton.text = "O";
            checker = false; // Switch back to Player X
            return;
        }
    }

    // Function to define all possible winning lines for the Computer (rows, columns, diagonals)
    private List<List<Text>> GetWinningLines()
    {
        return new List<List<Text>>()
        {
            new List<Text> { btnTL, btnTM, btnTR }, // Top row
            new List<Text> { btnML, btnMM, btnMR }, // Middle row
            new List<Text> { btnBL, btnBM, btnBR }, // Bottom row
            new List<Text> { btnTL, btnML, btnBL }, // Left column
            new List<Text> { btnTM, btnMM, btnBM }, // Middle column
            new List<Text> { btnTR, btnMR, btnBR }, // Right column
            new List<Text> { btnTL, btnMM, btnBR }, // Diagonal (Top-left to Bottom-right)
            new List<Text> { btnTR, btnMM, btnBL }  // Diagonal (Top-right to Bottom-left)
        };
    }
}
