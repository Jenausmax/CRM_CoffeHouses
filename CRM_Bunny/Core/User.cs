using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRM_Bunny.Core
{
    public class User
    {
        [Key]
        /// <summary>
        /// Id User.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// User Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User password.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// role User.
        /// </summary>
        public bool Role { get; set; }
    }
}
