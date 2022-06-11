using System;
using System.Collections.Generic;

namespace SchoolAdmin
{
    class CursusVolgensTitelOplopendComparer : IComparer<Cursus>
    {
        public int Compare(Cursus a, Cursus b) {
            return a.Titel.CompareTo(b.Titel);
        }
    }
    class CursusVolgensStudiepuntenOplopendComparer : IComparer<Cursus>
    {
        public int Compare(Cursus cursus1, Cursus cursus2) {
            if (cursus1.Studiepunten < cursus2.Studiepunten) {
                return -1;
            } else if (cursus1.Studiepunten > cursus2.Studiepunten) {
                return +1;
            } else {
                return 0;
            }
        }
    }
}