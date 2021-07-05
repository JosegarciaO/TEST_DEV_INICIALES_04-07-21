using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webbackend3.Modelos;

namespace WebApplication3.Controllers
{
    public class PersonasFisicasController : ApiController
    {
        [HttpGet]
        public string get(int id)
        {
            string valor;
            switch (id)
            {
                case 1:
                    valor = "ivan";
                    break;
                case 2:
                    valor = "armando";
                    break;
                default:
                    valor = "Valor incorrecto";
                    break;

            }
            return valor;
        }

        [HttpGet]
        public List<PersonaFisica> get()
        {
            List<PersonaFisica> abd = new List<PersonaFisica>();

            return abd;
        }

        [HttpPost]
        public PersonaFisica PostAdd(PersonaFisica person)
        {
            person.InsertarPersona();
            return person;
        }

        [HttpPut]
        public PersonaFisica Putupdate(PersonaFisica persona)
        {
            persona.ActualizarPersona();
            return persona;
        }

        [HttpDelete]
        public PersonaFisica delete(PersonaFisica persona)
        {
            persona.EliminarPersona();
            return persona;
        }
    }
}
