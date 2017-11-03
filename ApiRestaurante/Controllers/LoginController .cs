using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ApiRestaurante.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestauranteApi.Models;

namespace ApiRestaurante.Controllers
{
    public class LoginController : Controller
    {
        public string Index(string usuario, string senha)

        {
            Login.USUARIO = usuario;
            Login.SENHA = senha;
            if(string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                string json = JsonConvert.SerializeObject(new Retorno()
                {
                    retorno = "Dados incorretos",
                    sucesso = false
                });
                return json;
            }

            if (SessaoSite.Funcionario != null)
            {
                string json = JsonConvert.SerializeObject(new Retorno()
                {
                    retorno = "Usuário já está logado.",
                    sucesso = true
                });
                return json;
            }

            //valida login
                if (Login.Logar())
            {
                SessaoSite.Funcionario = new Funcionario()
                {
                    id = Int32.Parse(Login.ID_FUNC),
                    login = Login.USUARIO,
                    funcao = Login.NIVEL_ACESSO
                };
                string json = JsonConvert.SerializeObject(new Retorno()
                {
                    retorno = "Logado  com sucesso.",
                    sucesso = true
                });
                return json;
            }
            else
            {
                return JsonConvert.SerializeObject(new Retorno()
                {
                    retorno = "Login invalido",
                    sucesso = false
                });
            }

        }
        }
    }  
  
