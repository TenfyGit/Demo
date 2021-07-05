using Demo.Xunit.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Xunit.IRepository
{
    public interface IStudentRepository
    {
        bool Add(Student student);
    }
}
