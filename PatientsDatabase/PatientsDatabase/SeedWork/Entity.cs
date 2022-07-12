﻿namespace PatientsDatabase.Domain.SeedWork
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public Entity(int id)
        {
            Id = id;
        }
    }
}
