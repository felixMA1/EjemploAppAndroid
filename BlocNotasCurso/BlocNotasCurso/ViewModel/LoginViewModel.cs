using System;
using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    public class LoginViewModel:GeneralViewModel
    {
        public ICommand CmdLogin { get; set; }
        public ICommand CmdAlta { get; set; }

        public LoginViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            CmdLogin = new Command(IniciarSesion);
            CmdAlta = new Command(NuevoUsuario);
        }

        public String TituloIniciar { get { return "Iniciar sesion"; } }
        public String TituloRegistro { get { return "Nuevo usuario"; } }
        public String TituloLogin { get { return "Nombre de usuario"; } }
        public String TituloPassword{ get { return "Contraseña"; } }

        private Usuario _usuario = new Usuario();
        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }


        private async void IniciarSesion()
        {
            try
            {
                IsBusy = true;
                var us = await _servicio.ValidarUsuario(_usuario);
                if (us != null)
                {
                    await _navigator.PopToRootAsync();
                    await _navigator.PushAsync<PrincipalViewModel>(ViewModel =>
                    {
                        Titulo = "Pantalla principal";
                    });
                }
                else
                {
                    var xxx = "";
                }
                
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void NuevoUsuario()
        {
            //await _navigator.PopToRootAsync();
            await _navigator.PushModalAsync<RegistroViewModel>(viewModel =>
            {
                Titulo = "Nuevo Usuario";
            });
        }

        
    }
}