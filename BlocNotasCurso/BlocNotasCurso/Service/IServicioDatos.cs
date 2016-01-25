using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocNotasCurso.Model;

namespace BlocNotasCurso.Service
{
    public interface IServicioDatos
    {

        #region Usuario

        Task<Usuario> ValidarUsuario(Usuario us);
        Task<Usuario> AddUsuario(Usuario us);
        Task<Usuario> UpdateUsuario(Usuario us, String id);
        Task<Usuario> DeleteUsuario(String id);

        #endregion

        #region Bloc

        Task AddBloc(Bloc bloc);
        Task<List<Bloc>> GetBlocs(String usuario);
        Task DeleteBloc(Bloc bloc);
        Task UpdateBloc(Bloc bloc);

        #endregion

    }
}
