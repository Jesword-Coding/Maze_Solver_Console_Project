using System;

namespace Maze_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Creating the variables used within the main program
             * Choice -> getting the user input for the menu
             * maze -> initial maze (the beginning)
             * goalState -> creating the goal maze for the AI
             */

            char[,] goalState = new char[20, 20];
            int choice;

            
            char[,] maze = new char[20,20] {
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
                { 'X', '-', 'X', '-', 'X', '-', '-', 'X', '-', 'X', 'X', 'X', 'X', 'X', 'X', '-', 'X', '-', 'X', 'X'},
                { 'E', '-', '-', '-', 'X', 'X', '-', '-', '-', '-', 'X', 'X', 'X', '-', '-', '-', 'X', '-', '-', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', 'X', '-', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', '-', 'X'},
                { 'X', 'X', '-', '-', 'X', '-', '-', '-', '-', '-', 'X', '-', 'X', 'X', 'X', '-', '-', '-', '-', 'X'},
                { 'X', '-', '-', 'X', 'X', '-', 'X', 'X', 'X', 'X', 'X', '-', '-', '-', '-', 'X', 'X', '-', 'X', 'X'},
                { 'X', 'X', '-', 'X', 'X', '-', 'X', '-', 'X', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X', '-', '-', 'X'},
                { 'X', '-', '-', '-', '-', '-', 'X', '-', '-', '-', '-', '-', '-', '-', '-', 'X', 'X', 'X', '-', 'X'},
                { 'X', '-', 'X', '-', 'X', '-', '-', '-', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', '-', '-', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', '-', 'X', '-', 'X', 'X', 'X', 'X', '-', 'X', 'X'},
                { 'X', '-', 'X', '-', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', '-', '-', '-', '-', 'X', '-', 'X', 'X'},
                { 'X', '-', 'X', '-', 'X', '-', 'X', '-', '-', 'X', 'X', 'X', 'X', 'X', 'X', '-', '-', '-', '-', 'X'},
                { 'X', '-', '-', '-', 'X', '-', '-', 'X', '-', '-', 'X', '-', '-', '-', 'X', '-', 'X', 'X', '-', 'X'},
                { 'X', 'X', '-', 'X', 'X', '-', 'X', 'X', '-', 'X', 'X', '-', 'X', 'X', '-', '-', 'X', '-', '-', 'X'},
                { 'X', '-', '-', '-', '-', '-', 'X', '-', '-', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', '-', 'X', 'X'},
                { 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', '-', '-', 'X', '-', 'X', '-', 'X', 'X'},
                { 'X', '-', 'X', '-', 'X', '-', '-', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', '-', '-', '-', 'X'},
                { 'X', '-', '-', '-', 'X', '-', 'X', '-', 'X', '-', '-', '-', 'X', '-', 'X', 'X', '-', 'X', '-', 'X'},
                { 'X', '-', 'X', '-', '-', '-', 'X', '-', 'X', 'X', '-', 'X', 'X', '-', '-', '-', '-', 'X', 'X', 'X'},
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'C', 'X', 'X', 'X'}
            };
            
            // A test maze to make sure it solves for the optimal path
            /*
            char[,] maze = new char[20, 20] {
                { 'X', 'E', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'},
                { 'X', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', 'X', 'X', 'X', 'X'},
                { 'X', '-', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', '-', '-', 'X', '-', '-', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', '-', 'X', '-', '-', '-', 'X', '-', '-', '-', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { '-', '-', '-', '-', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { '-', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', '-', 'X', 'X', 'X', 'X'},
                { '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', 'X', 'X', 'X', 'X'},
                { 'X', 'X', 'X', 'C', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'}
            };
            */

            // generating the goal maze by replacing the original maze 'E' with 'C' and the 'C' with '-'
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if(maze[i,j] == 'E')
                    {
                        goalState[i,j] = 'C';
                    }
                    else if(maze[i,j] == 'C')
                    {
                        goalState[i,j] = '-';
                    }
                    else
                    {
                        goalState[i,j] = maze[i,j];
                    }
                }
            }
            

	        choice = GetInput();
           
	        Console.WriteLine("\n************ Start ************");
            if(choice == 1)
            {
                Maze m = new Maze(maze);
                Artificial_Intelligence ai = new Artificial_Intelligence();
                ai.SetGoalState(goalState);
                ai.BFS(m);
            }
            else if(choice == 2)
            {
                Maze m = new Maze(maze);
                Artificial_Intelligence ai = new Artificial_Intelligence();
                ai.SetGoalState(goalState);
                ai.UFS(m);
            }
            else if(choice == 3)
            {
                Maze m = new Maze(maze);
                Artificial_Intelligence ai = new Artificial_Intelligence();
                ai.SetGoalState(goalState);
                ai.AStar(m);
            }
            else
            {
                Console.WriteLine("Error with Choice");    
            }
        }

        public static int GetInput()
        {
            int choice = 0;
            bool isAccepted = false;

            // looping until an input is valid and returns the valid input
            while(!isAccepted)
            {
                // Main menu for the user to choose which search method they want to use
                Console.WriteLine("** Choose how to solve the maze** \n"); 	
                Console.WriteLine("1: Breadth First Search");
                Console.WriteLine("2: Uniform Cost Search");
                Console.WriteLine("3: A Star Search");

                // Making sure that the input is an integer
                while(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("\nERROR: Invalid input. Please Input an Integer");
                }

                // checking to see if the integer is one of the menu options
                if(choice < 4 && choice > 0)
                {
                    isAccepted = true;
                }
                else
                {
                    Console.WriteLine("\nERROR: Choice " + choice + " is unavailable. Please choose again from the following.\n");
                }

            }

            return choice;
        }
	}
}

