﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMicro.Core
{
	public interface IApplicationService
	{
		void Handle(IMessage message);
	}
}
