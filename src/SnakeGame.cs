using System;
using System.Collections.Generic;
using System.Threading;

public class SnakeGame
{
    private List<(int x, int y)> snake;
    private (int x, int y) food;
    private string direction;
    private bool gameOver;
    private int width = 20;
    private int height = 10;

    public SnakeGame()
    {
        snake = new List<(int x, int y)>();
        snake.Add((width / 2, height / 2));
        direction = "RIGHT";
        gameOver = false;
        GenerateFood();
    }

    public void Run()
    {
        while (!gameOver)
        {
            Draw();
            Input();
            Logic();
            Thread.Sleep(200); // Like a Muay Thai rest between rounds
        }
    }

    private void Draw()
    {
        Console.Clear();

        for (int i = 0; i < width + 2; i++)
            Console.Write("#");
        Console.WriteLine();

        for (int y = 0; y < height; y++)
        {
            Console.Write("#");
            for (int x = 0; x < width; x++)
            {
                if (snake.Count > 0 && snake[0].x == x && snake[0].y == y)
                {
                    Console.Write("O");
                }
                else if (snake.Exists(s => s.x == x && s.y == y))
                {
                    Console.Write("o");
                }
                else if (food.x == x && food.y == y)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine("#");
        }

        for (int i = 0; i < width + 2; i++)
            Console.Write("#");
        Console.WriteLine();
    }

    private void Input()
    {
        // T9 input handling would be integrated here
    }

    private void Logic()
    {
        var head = snake[0];
        (int x, int y) newHead = head;

        switch (direction)
        {
            case "LEFT":
                newHead.x--;
                break;
            case "RIGHT":
                newHead.x++;
                break;
            case "UP":
                newHead.y--;
                break;
            case "DOWN":
                newHead.y++;
                break;
        }

        if (newHead.x < 0 || newHead.x >= width || newHead.y < 0 || newHead.y >= height)
        {
            gameOver = true;
            return;
        }

        if (snake.Exists(s => s.x == newHead.x && s.y == newHead.y))
        {
            gameOver = true;
            return;
        }

        snake.Insert(0, newHead);

        if (newHead.x == food.x && newHead.y == food.y)
        {
            GenerateFood();
        }
        else
        {
            snake.RemoveAt(snake.Count - 1);
        }
    }

    private void GenerateFood()
    {
        Random random = new Random();
        do
        {
            food.x = random.Next(0, width);
            food.y = random.Next(0, height);
        } while (snake.Exists(s => s.x == food.x && s.y == food.y));
    }

    public void MoveLeft()
    {
        direction = "LEFT";
    }

    public void MoveRight()
    {
        direction = "RIGHT";
    }

    public void MoveUp()
    {
        direction = "UP";
    }

    public void MoveDown()
    {
        direction = "DOWN";
    }

    public void Pause()
    {
        Thread.Sleep(1000);
    }
}
