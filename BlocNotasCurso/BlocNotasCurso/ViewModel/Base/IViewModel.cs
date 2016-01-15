using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocNotasCurso.ViewModel.Base
{
    public interface IViewModel:INotifyPropertyChanged
    {
        string Titulo { get; set; }

        void SetState<T>(Action<T> action) where T : class, IViewModel;

    }
}
