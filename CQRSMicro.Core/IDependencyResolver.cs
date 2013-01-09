using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMicro.Core
{
	public interface IDependencyResolver
	{
		T Get<T>();
		object Get(Type type);
		void Bind<Interface, Implementation>() where Implementation : Interface;
	}
}
