﻿using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameworks
{
    public class EFAboutRepository: GenericRepository<About>, IAbout
    {
    }
}
