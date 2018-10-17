using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace ProfileQuiz.Model
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int User_Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string ProfilePic { get; set; }
    }
}
