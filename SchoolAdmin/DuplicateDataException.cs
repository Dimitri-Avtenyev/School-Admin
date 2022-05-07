using System;

namespace SchoolAdmin
{
    class DuplicateDataException : Exception 
    {   /* -> ApplicationException Class doc
        Important
        You should derive custom exceptions from the Exception class rather than the ApplicationException class.
        */
        private System.Object waarde1;
        public System.Object Waarde1 {
            get {return this.waarde1;}
        }
        private System.Object waarde2;
        public System.Object Waarde2 {
            get {return this.waarde2;}
        }
        public DuplicateDataException(string message, System.Object waarde1, System.Object waarde2):base(message) {
            this.waarde1 = waarde1;
            this.waarde2 = waarde2;
        }
    }
}