using ConsoleAppHW0702Dapper.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ConsoleAppHW0702Dapper;

 class Program
{
    static void Main()
    {
        string connectionString = GetConnectionString();
        TaskRepository taskRepository = new TaskRepository(connectionString);
        // Создаем несколько задач
        //TaskModel task1 = new TaskModel
        //{
        //    Title = "Задача 1",
        //    Description = "Ознакомление с темой",
        //    DueDate = DateTime.Now.AddDays(3),
        //    IsCompleted = false
        //};
        //TaskModel task2 = new TaskModel
        //{
        //    Title = "Задача 2",
        //    Description = "Выполнение домашего задания",
        //    DueDate = DateTime.Now.AddDays(5),
        //    IsCompleted = false
        //};
        //// Добавляем задачи в базу данных
        //taskRepository.AddTask(task1);
        //taskRepository.AddTask(task2);
        // Выводим список всех задач
        //Console.WriteLine("Список всех задач:");
        //var allTasks = taskRepository.GetAllTasks();
        //foreach (var task in allTasks)
        //{
        //    Console.WriteLine($"ID: {task.Id}, Название: {task.Title}, Описание: {task.Description}, Дата завершения: {task.DueDate}, Завершена: {task.IsCompleted}");
        //}
        // Обновляем одну из задач
        //var taskToUpdate = taskRepository.GetTaskById(1);
        //if (taskToUpdate != null)
        //{
        //    taskToUpdate.IsCompleted = true;
        //    taskRepository.UpdateTask(taskToUpdate);
        //    Console.WriteLine($"Задача с ID {taskToUpdate.Id} обновлена.");
        //}
        //else
        //{
        //    Console.WriteLine("Задача не найдена.");
        //}
        // Удаляем одну из задач
        //int taskIdToDelete = 2;
        //taskRepository.DeleteTask(taskIdToDelete);
        //Console.WriteLine($"Задача с ID {taskIdToDelete} удалена.");
        // Проверяем список задач после удаления и обновления
        //Console.WriteLine("Список задач после удаления и обновления:");
        //var updatedTasks = taskRepository.GetAllTasks();
        //foreach (var task in updatedTasks)
        //{
        //    Console.WriteLine($"ID: {task.Id}, Название: {task.Title}, Описание: {task.Description}, Дата завершения: {task.DueDate}, Завершена: {task.IsCompleted}");
        //}

    }

    private static string GetConnectionString()
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        var config = builder.Build();
        return config.GetConnectionString("DefaultConnection");
    }
}
