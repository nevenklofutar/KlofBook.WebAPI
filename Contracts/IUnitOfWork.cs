using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts {
    public interface IUnitOfWork {

        IUserRepository Users { get; }
        IPostRepository Posts { get; }
        ICommentRepository Comments { get; }
        IPostLikeRepository PostLikes { get; }
    }
}
