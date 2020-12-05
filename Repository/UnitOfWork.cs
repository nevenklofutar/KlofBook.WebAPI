using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository {
    public class UnitOfWork : IUnitOfWork {

        public IUserRepository Users { get; }
        public IPostRepository Posts { get; }
        public ICommentRepository Comments { get; }
        public IPostLikeRepository PostLikes { get; }

        public UnitOfWork(IUserRepository userRepository, IPostRepository postRepository, ICommentRepository commentRepository, IPostLikeRepository postLikeRepository) {
            Users = userRepository;
            Posts = postRepository;
            Comments = commentRepository;
            PostLikes = postLikeRepository;
        }


    }
}
