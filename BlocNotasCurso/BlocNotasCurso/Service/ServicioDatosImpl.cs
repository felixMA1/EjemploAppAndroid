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

        public async Task<Usuario> ValidarUsuario(Usuario us)
        {
            //GetTable : devuelve la referencia una tabla
            var tabla = client.GetTable<Usuario>();
            var data = await tabla.CreateQuery().Where(o => o.Login == us.Login && o.Password == us.Password).ToListAsync();

            if (data.Count == 0)
                return null;

            return data[0];
        }

        public async Task<Usuario> AddUsuario(Usuario us)
        {
            var tabla = client.GetTable<Usuario>();
            var data = await tabla.CreateQuery().Where(o => o.Login == us.Login).ToListAsync();

            if(data.Count > 0)
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
    }
}
