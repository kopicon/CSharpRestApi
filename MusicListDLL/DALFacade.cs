using List.Repositories;
using List.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DALFacade
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }
        }
    }
}
