using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalAgenda.Models
{
   public class Agenda
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public bool isChecked { get; set; }

        public static implicit operator Agenda(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
