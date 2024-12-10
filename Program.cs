using System;

class Program // Класс программы
{
    // Массив с лабиринтом # - стены, ' ' - проходимые ячейки, E - выход
    static char[,] maze = {
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
        {'#', ' ', ' ', ' ', ' ', '#', ' ', ' ', 'E', '#'},
        {'#', '#', '#', ' ', '#', '#', ' ', '#', '#', '#'},
        {'#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#'},
        {'#', ' ', ' ', '#', '#', '#', '#', '#', ' ', '#'},
        {'#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#'},
        {'#', '#', '#', ' ', '#', '#', ' ', '#', '#', '#'},
        {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
        {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
    };

    static int playerX = 1, playerY = 1; // Начальные координаты игрока

    static void Main() // Начало самой программы
    {
        while (true) // Цикл, повторяющийся до победы игрока
        {
            DisplayMaze(); // Вызывает функцию 
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Читает нажатую клавишу
            MovePlayer(keyInfo.Key); // Передаёт нажатую клавишу в функцию

            if (maze[playerX, playerY] == 'E') // Условия для выхода
            {
                Console.Clear(); // Отчистка консоли
                Console.WriteLine("Ура, победа!"); // Вывод победной фразы
                break; // Конец цикла
            }
        }
    }

    static void DisplayMaze() // Функция для отображения лабиринта и игрока
    {
        Console.Clear(); // Отчистка консоли
        for (int i = 0; i < maze.GetLength(0); i++) // Проверка массива
        {
            for (int j = 0; j < maze.GetLength(1); j++) // Проверка массива
            {
                if (i == playerX && j == playerY) // Определение нахождения игрока
                    Console.Write("P"); // Игрок
                else
                    Console.Write(maze[i, j]); // Вывод изначального массива
            }
            Console.WriteLine();
        }
    }

    static void MovePlayer(ConsoleKey key) // Функция перемещения игрока
    {
        int newX = playerX, newY = playerY; // Копирует координаты игрока 

        switch (key) // Оператор выбора для определения движения
        {
            case ConsoleKey.W: newX--; break; // Вверх
            case ConsoleKey.S: newX++; break; // Вниз
            case ConsoleKey.A: newY--; break; // Влево
            case ConsoleKey.D: newY++; break; // Вправо
        }

        if (maze[newX, newY] != '#') // Проверка на стену
        {
            playerX = newX; // Обновление координат игрока, если нет стены
            playerY = newY;
        }
    }
}
