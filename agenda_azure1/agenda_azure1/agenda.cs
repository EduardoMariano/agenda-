using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agenda_azure1
{
    class agenda
    {
        string id;
        string nombre;
        string apellido;
        string telefono;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "Name")]
        public string Name
        {
            get { return nombre; }
            set { nombre = value; }
        }
        [JsonProperty(PropertyName = "LastName")]
        public string LastNAme
        {
            get { return apellido; }
            set { apellido = value; }
        }

        [JsonProperty(PropertyName = "Cellphone")]
        public string Cellphone
        {
            get { return telefono; }
            set { telefono = value; }
        }



        [Version]
        public string Version { get; set; }
    }
}
