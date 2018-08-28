﻿using System;

namespace BecaDotNet.UI.MVC.RazorView.Models.ViewModel
{
    public class UserListViewModel  : UserAccountViewModel
    {
        public string NomeSuperior { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool UsuarioAtivo { get; set; }
        public string DescTipoUsuario { get; set; }
    }
}