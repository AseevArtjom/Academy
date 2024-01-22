﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities.Group
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Group()
        {

        }

        public Group(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
