using System;
using System.Collections.Generic;

namespace SchoolAdmin
{
    class StudentenVolgensNaamComparerOplopend : IComparer<Student>
    {
        public int Compare(Student a, Student b) {
            return a.Naam.CompareTo(b.Naam);
        }
    }
      class StudentenVolgensNaamComparerAflopend : IComparer<Student>
    {
        public int Compare(Student a, Student b) {
            return (-1)*a.Naam.CompareTo(b.Naam);
        }
    }
}