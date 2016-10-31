﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo.Core.Interfaces
{
    public interface IDialogService
    {
       Task<bool> Show(string message, string title);
       Task<bool> Show(string message, string title, string confirmButton);
    }
}
