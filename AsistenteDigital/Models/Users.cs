﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsistenteDigital.Models
{
    public class Users
    {
        public int ID { get; set; }       
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Sexo { get; set; }
    }
}