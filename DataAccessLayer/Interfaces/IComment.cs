﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IComment:IGeneric<Comment>
    {
        List<Comment> GetListWithBlog();
    }
}
