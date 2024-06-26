﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IGiftCommentRepository
    {
        IEnumerable<GiftComment> GetAll();
        GiftComment AddGiftComment(GiftComment GiftComment);
        GiftComment RemoveGiftComment(int id);
        GiftComment UpdateGiftComment(GiftComment GiftComment);

    }
}
