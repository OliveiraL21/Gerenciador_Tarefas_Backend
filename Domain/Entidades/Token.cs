﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Token
    {
        public string Value { get; }

        public Token(string value)
        {
            Value = value;
        }
    }
}