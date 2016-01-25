using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocNotasCurso.Model;
using BlocNotasCurso.Util;
using Microsoft.WindowsAzure.MobileServices;

namespace BlocNotasCurso.Service
{
    public class ServicioDatosImpl:IServicioDatos
    {
        private MobileServiceClient client;

        public ServicioDatosImpl()
        {
            client = new MobileServiceClient(Cadenas.urlServicio,Cadenas.TokenServicio);
        }

        #region Usuario

        public async Task<Usuario> ValidarUsuario(Usuario us)
        {
            //GetTable : devuelve la referencia una tabla
            var tabla = client.GetTable<Usuario>();
            var data =
                await tabla.CreateQuery().Where(o => o.Login == us.Login && o.Password == us.Password).ToListAsync();

            if (data.Count == 0)
                return null;

            return data[0];
        }

        public async Task<Usuario> AddUsuario(Usuario us)
        {
            var tabla = client.GetTable<Usuario>();
            var data = await tabla.CreateQuery().Where(o => o.Login == us.Login).ToListAsync();

            if (data.Count > 0)
                throw new Exception("Usuario ya registrado");

            try
            {
                await tabla.InsertAsync(us);
            }
            catch (Exception e)
            {
                throw new Exception("Error al registrar el usuario");
            }

            return us;
        }

        public Task<Usuario> UpdateUsuario(Usuario us, string id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> DeleteUsuario(string id)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Bloc

        public async Task AddBloc(Bloc bloc)
        {
            var table = client.GetTable<Bloc>();
            await table.InsertAsync(bloc);
            
        }

        public async Task<List<Bloc>> GetBlocs(string usuario)
        {
            var table = client.GetTable<Bloc>();
            var data = await table.CreateQuery().Where(o => o.IdUsuario == usuario).ToListAsync();
            return data;
        }

        public async Task DeleteBloc(Bloc bloc)
        {
            var table = client.GetTable<Bloc>();
            await table.DeleteAsync(bloc);
        }

        public async Task UpdateBloc(Bloc bloc)
        {
            var table = client.GetTable<Bloc>();
            await table.UpdateAsync(bloc);
        }

        #endregion


    }
}
