using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProfileQuiz.Model
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(50)]
        public string UserEmail { get; set; }
        [MaxLength(50)]
        public int CellNo { get; set; }
        [MaxLength(11)]

    public string ProfilePic { get; set; }
    }
}
