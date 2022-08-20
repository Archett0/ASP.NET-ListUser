using System;
using ListUser_net6.Models;

namespace ListUser_net6.DB
{
    public class DBManager
    {
        private DBContext dbContext;

        public DBManager(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Seed()
        {
            SeedPersonsTable();
        }

        public void SeedPersonsTable()
        {
            dbContext.Add(new Person
            {
                LastName = "Tan",
                FirstName = "Jerry",
                JobTitle = "Software Engineer",
                YearsExperience = 12
            });

            dbContext.Add(new Person
            {
                LastName = "Wong",
                FirstName = "Hogan",
                JobTitle = "Data Scientist",
                YearsExperience = 5
            });

            dbContext.Add(new Person
            {
                LastName = "Lee",
                FirstName = "Jean",
                JobTitle = "Consultant",
                YearsExperience = 15
            });

            dbContext.Add(new Person
            {
                LastName = "Lai",
                FirstName = "Kelly",
                JobTitle = "Software Engineer",
                YearsExperience = 8
            });

            dbContext.Add(new Person
            {
                LastName = "John",
                FirstName = "Tan",
                JobTitle = "Consultant",
                YearsExperience = 10
            });

            dbContext.Add(new Person
            {
                LastName = "Kim",
                FirstName = "Tan",
                JobTitle = "Data Scientist",
                YearsExperience = 8
            });

            dbContext.Add(new Person
            {
                LastName = "Larry",
                FirstName = "Wong",
                JobTitle = "Consultant",
                YearsExperience = 5
            });

            dbContext.SaveChanges();
        }
    }
}

