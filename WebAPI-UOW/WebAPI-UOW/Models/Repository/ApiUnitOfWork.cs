using System;
using System.Data.Entity;

namespace WebAPI_UOW.Models.Repository {
    public class ApiUnitOfWork : UnitOfWork, IApiUnitOfWork {
        public ApiUnitOfWork(DbContext context) : base(context) {
        }
    }
}