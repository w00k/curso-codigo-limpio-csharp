using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                switch ((Menu)menuSelected)
                {
                    case Menu.Add:
                        ShowMenuAdd();
                        break;
                    case Menu.Remove:
                        ShowMenuRemove();
                        break;
                    case Menu.List:
                        ShowMenuTaskList();
                        break;
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            ShowLine();
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string numberOption = Console.ReadLine();
            return Convert.ToInt32(numberOption);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                ShowTaskList();
                ShowLine();

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                if (indexToRemove > -1)
                {
                    if (TaskList.Count > 0)
                    {
                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            }
            else
            {
                ShowLine();
                ShowTaskList();
                ShowLine();
            }
        }

        private static void ShowTaskList()
        {
            TaskList.Select((task, index) => $"{index + 1}. {task}").ToList().ForEach(Console.WriteLine);
        }

        private static void ShowLine()
        {
            Console.WriteLine("----------------------------------------");
        }

        private enum Menu {
            Add = 1,
            Remove = 2,
            List = 3,
            Exit = 4
        }
    }
}
