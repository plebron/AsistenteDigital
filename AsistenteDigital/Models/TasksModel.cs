using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsistenteDigital.Models
{
    public class TasksModel
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}