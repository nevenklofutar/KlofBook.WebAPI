using Contracts;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.ServiceExtensions {
    public static class Repositories {

        public static void AddRepositories(this IServiceCollection services) {

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IPostLikeRepository, PostLikeRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
