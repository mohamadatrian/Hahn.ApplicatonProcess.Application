﻿using System;

namespace Hahn.ApplicatonProcess.July2021.Domain.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
            Name = name;
            Key = key;
        }

        public string Name { get; }
        public object Key { get; }
    }
}
