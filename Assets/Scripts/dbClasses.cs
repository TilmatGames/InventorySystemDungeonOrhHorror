using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite;

namespace dbClasses
{
    // Определяем структуру для таблицы 
    public class Monstr
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int DMG { get; set; }
        public int HP { get; set; }
        public int Dodge { get; set; }
        public string Ability { get; set; }
    }

 
}