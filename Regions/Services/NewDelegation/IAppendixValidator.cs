﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regions.Services.NewDelegation
{
  public  interface IAppendixValidator
    {
        bool IsAppendixValid(string Appendix);
    }
}
