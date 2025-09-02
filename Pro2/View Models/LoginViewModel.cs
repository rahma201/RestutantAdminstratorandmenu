﻿using System.ComponentModel.DataAnnotations;

namespace Pro2.View_Models
{
    public class LoginViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
