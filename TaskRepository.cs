using ConsoleAppHW0702Dapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHW0702Dapper
{
    public class TaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<TaskModel>("SELECT * FROM Tasks");
            }
        }

        public TaskModel GetTaskById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.QueryFirstOrDefault<TaskModel>("SELECT * FROM Tasks WHERE Id = @Id", new { Id = id });
            }
        }

        public void AddTask(TaskModel task)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Tasks (Title, Description, DueDate, IsCompleted) 
                             VALUES (@Title, @Description, @DueDate, @IsCompleted)";
                db.Execute(query, task);
            }
        }

        public void UpdateTask(TaskModel task)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Tasks 
                             SET Title = @Title, Description = @Description, DueDate = @DueDate, IsCompleted = @IsCompleted
                             WHERE Id = @Id";
                db.Execute(query, task);
            }
        }

        public void DeleteTask(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"DELETE FROM Tasks WHERE Id = @Id";
                db.Execute(query, new { Id = id });
            }
        }
    }
}


