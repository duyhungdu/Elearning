﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Core.IPresentation
{
    public interface ICookieStorageService
    {
        void Save(string key, string value);
        string Retrieve(string key);
    }
}
