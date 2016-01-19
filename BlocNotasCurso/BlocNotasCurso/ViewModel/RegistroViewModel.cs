using System.Windows.Input;
using BlocNotasCurso.Factorias;
using BlocNotasCurso.Model;
using BlocNotasCurso.Service;
using Xamarin.Forms;

namespace BlocNotasCurso.ViewModel
{
    public class RegistroViewModel:GeneralViewModel
    {
        public ICommand CmdRegistro { get; set; }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario,value); }
        }
   
        private Usuario _usuario = new Usuario();

        public RegistroViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            CmdRegistro = new Command(GuardarUsuario);
        }

        private async void GuardarUsuario()
        {
            _usuario.Foto = "";
            try
            {
                IsBusy = true;
                var r = await _servicio.AddUsuario(_usuario);
                if (r != null)
                {
                    await _navigator.PushModalAsync<PrincipalViewModel>();
                }
                else
                {
                    var a = "";
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}